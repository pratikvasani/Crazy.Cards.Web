var app = angular.module("crazyCards", ['ui.router']);

app.config(["$stateProvider", "$urlRouterProvider", function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise("/Home");
    $stateProvider
    .state('Home', {
        url: "/Home",
        templateUrl: "/Angular/Views/Home.html",
        controller: ["$scope", function ($scope) {
            $scope.start = function () {
                $scope.firstName = "";
                $scope.showError = true;
            }
        }]
    })
    .state('About', {
        url: "/About",
        templateUrl: "/Angular/Views/About.html"
    })
        .state('Cards', {
            url: "/Cards",
            templateUrl: "/Angular/Views/Cards.html",
            controller: 'cardsController'
        })
     .state('Cards.MyOffers', {
         url: "/MyOffers",
         templateUrl: "/Angular/Views/MyOffers.html",
         controller: 'offersController'

     })
    ;
}]);

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
app.run(["$rootScope", function ($rootScope) {
    $rootScope.$on('$stateChangeSuccess', function () {
        document.body.scrollTop = document.documentElement.scrollTop = 0;
    });
}]);