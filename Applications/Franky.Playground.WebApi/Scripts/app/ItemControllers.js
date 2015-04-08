(function () {
	'use strict';

	var itemControllers = angular.module('itemControllers', []);

	itemControllers.config([
		'$stateProvider',
		function ($stateProvider) {
			$stateProvider
				.state('item', {
					url: '/Item',
					abstract: true,
					template: '<div ui-view></div>',
					data: { pageTitle: 'Items' }
				})

				.state('item.list', {
					url: '',
					templateUrl: 'Template/Item/List',
					controller: 'itemListController',
					controllerAs: 'itemListCtrl'
				})

				.state('item.detail', {
					url: '/Detail/:id',
					templateUrl: 'Template/Item/Detail',
					controller: 'itemDetailController',
					controllerAs: 'itemDetailCtrl'
			});
		}
	]);

	itemControllers.controller('itemListController', [
		'$scope',
		'Items',
		function ($scope, Items) {
			var vm = this;

			vm.items = [{ id: 1, name: "Test", type: 0 }];
			return;
			Items.query(function (items) {
				vm.items = items;
			});
		}
	]);

	itemControllers.controller('itemDetailController', [
		'$scope',
		'$stateParams',
		'Items',
		function ($scope, $stateParams, Items) {
			var vm = this;
			Items.get({ id: $stateParams.id }, function (item) {
				vm.item = item;
			});
		}
	]);
})();