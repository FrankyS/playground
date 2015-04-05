var itemControllers = angular.module('itemControllers', []);

itemControllers.controller('itemListController', ['$scope', 'Items', function($scope, Items) {
	var items = [{ id: 1, name: 'Item1' }, { id: 2, name: 'Item2' }];
	$scope.items = items;
}]);
