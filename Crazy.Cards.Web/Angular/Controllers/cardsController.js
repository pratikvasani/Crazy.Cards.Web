app.controller('cardsController', ['$scope', '$state', 'getOffersService', '$filter', function ($scope, $state, getOffersService, $filter) {
    $scope.editMode = true;
    getOffersService.AddSelectedCard(0, 0);

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
}]);