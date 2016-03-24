app.controller('offersController', ['$scope', 'getOffersService', '$filter', function ($scope, getOffersService, $filter) {
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


}]);