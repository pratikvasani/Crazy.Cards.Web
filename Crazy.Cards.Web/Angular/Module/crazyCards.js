var app = angular.module("crazyCards", ['ui.router']);

app.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise("/Home");
    $stateProvider
    .state('Home', {
        url: "/Home",
        templateUrl: "/Angular/Views/Home.html",
        controller: function ($scope) {
            $scope.start = function () {
                $scope.firstName = "";
                $scope.showError = true;
            }
        }
    })
    .state('About', {
        url: "/About",
        templateUrl: "/Angular/Views/About.html"
    })
    .state('Contact', {
        url: "/Contact",
        templateUrl: "/Angular/Views/Contact.html"
    })
     .state('Portfolio', {
         url: "/Portfolio",
         templateUrl: "/Angular/Views/portfolio.html"
     })
        .state('Cards', {
            url: "/Cards",
            templateUrl: "/Angular/Views/Cards.html",
            controller: function ($scope, $state, getOffersService, $filter) {
                $scope.editMode = true;
                getOffersService.AddSelectedCard(0,0);

                $scope.customer = getOffersService.customer;
                $scope.getOffers = function (customerForm) {
                    // check if form is valid before getting offers.
                    //"Cards.MyOffers"
                    angular.forEach(customerForm.$error.required, function (field) {
                        field.$setDirty();
                    });
                    if (customerForm.$valid) {
                        //Do something
                        $state.go("Cards.MyOffers");
                    }
                }
                $scope.employmentOptions = [{ Value: 1, Text: "Unemployed" }, { Value: 2, Text: "Student" }, { Value: 3, Text: "Part time" }, { Value: 4, Text: "Full time" }];
                $scope.titles = [{ Value: 1, Text: "Mr" }, { Value: 2, Text: "Mrs" }, { Value: 3, Text: "Miss" }, { Value: 4, Text: "Ms" }];

                $scope.titleChanged = function (newTitleId) {
                    $scope.titleDesc = $filter('filter')($scope.titles, {
                        Value: newTitleId
                    })[0].Text;
                }
                $scope.EmpStatusChanged = function (newStatus) {
                    $scope.EmpStatusDescription = $filter('filter')($scope.employmentOptions, {
                        Value: newStatus
                    })[0].Text;
                }
            }
        })
     .state('Cards.MyOffers', {
         url: "/MyOffers",
         templateUrl: "/Angular/Views/MyOffers.html",
         controller: function ($scope, getOffersService, $filter) {
             $scope.SelectedCount = 0;
             $scope.TotalCreditLimit = 0
             getOffersService.AddSelectedCard($scope.SelectedCount, $scope.TotalCreditLimit);

             $scope.OfferSelected = function (offer) {
                 $scope.SelectedRecords = $filter('filter')($scope.offers, {
                     Selected: true
                 });
                 $scope.SelectedCount = $scope.SelectedRecords.length;
                 $scope.TotalCreditLimit = 0;
                 for (var i = 0; i < $scope.SelectedRecords.length; i++) {
                     var product = $scope.SelectedRecords[i];
                     $scope.TotalCreditLimit += (product.CreditLimit);
                 }
                 getOffersService.AddSelectedCard($scope.SelectedCount, $scope.TotalCreditLimit);

             }

             getOffersService.getOffers().then(function (result) {
                 $scope.offers = result.data;
             });


         }

     })
    ;
});
app.run(function ($rootScope) {
    $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
        console.log('$stateChangeStart to ' + toState.to + '- fired when the transition begins. toState,toParams : \n', toState, toParams);
    });

    $rootScope.$on('$stateChangeError', function (event, toState, toParams, fromState, fromParams) {
        console.log('$stateChangeError - fired when an error occurs during transition.');
        console.log(arguments);
    });

    $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
        console.log('$stateChangeSuccess to ' + toState.name + '- fired once the state transition is complete.');
    });

    $rootScope.$on('$viewContentLoaded', function (event) {
        console.log('$viewContentLoaded - fired after dom rendered', event);
    });

    $rootScope.$on('$stateNotFound', function (event, unfoundState, fromState, fromParams) {
        console.log('$stateNotFound ' + unfoundState.to + '  - fired when a state cannot be found by its name.');
        console.log(unfoundState, fromState, fromParams);
    });
});
app.filter('ageFilter', function () {
    function calculateAge(birthday) { // birthday is a date
        var ageDifMs = Date.now() - new Date(birthday).getTime();
        var ageDate = new Date(ageDifMs); // miliseconds from epoch
        return Math.abs(ageDate.getUTCFullYear() - 1970);
    }
    function monthDiff(d1, d2) {
        if (d1 < d2) {
            var months = d2.getMonth() - d1.getMonth();
            return months <= 0 ? 0 : months;
        }
        return 0;
    }
    return function (birthdate) {
        if (birthdate == undefined) {
            return;
        }
        if (NaN == Date.parse(birthdate)) {
            return;
        }

        var age = calculateAge(birthdate);
        if (age == 0)
            return monthDiff(birthdate, new Date()) + ' Months';
        return age;
    };
});

app.service('getOffersService', ['$http', function ($http) {
    this.customer = {};
    this.offers = [];
    this.getOffers = function () {

        return $http.post('/api/Offers', this.customer);
    }
    this.AddSelectedCard = function (cards, totalCreditLimit) {
        this.customer.SelectedCards = cards;
        this.customer.TotalCreditLimit = totalCreditLimit;

    }

}]);
