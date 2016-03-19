var app = angular.module("crazyCards", ['ui.router']);

app.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise("/Home");
    $stateProvider
    .state('Home', {
        url: "/Home",
        templateUrl: "/Angular/Views/Home.html"
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
            controller: function ($scope) {
                //$scope.$watch('customer.DOB', function () {
                //    if ($scope.customer != null) {
                //        if ($scope.customer.DOB != null) {
                //            $scope.calculateAge($scope.customer.DOB)
                //        }
                //    }
                 
                //});

                //$scope.calculateAge = function calculateAge(birthday) { // birthday is a date
                //    if (isNaN(birthday.getTime())) {  // d.valueOf() could also work
                //        // date is not valid
                //        return "";
                //    }
                //    var ageDifMs = Date.now() - birthday.getTime();
                //    var ageDate = new Date(ageDifMs); // miliseconds from epoch
                //    return Math.abs(ageDate.getUTCFullYear() - 1970);
                //}
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
        return Math.abs(ageDate.getUTCFullYear() - 1970) ;
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