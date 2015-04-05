'use strict';

var itemControllers = angular.module('itemControllers', []);

itemControllers.config([
	'$stateProvider',
	function ($stateProvider) {
		$stateProvider
			.state('item', {
				url: '/Items',
				abstract: true,
				template: '<div ui-view></div>',
				data: { pageTitle: 'Items' }
			})

			.state('item.list', {
				url: '',
				templateUrl: '/Item/List',
				controller: 'itemListController',
			})	
	
			.state('item.detail', {
				url: '/Detail/:id',
				templateUrl: '/Item/Detail',
				controller: 'itemDetailController'
			});
	}
]);

itemControllers.controller('itemListController', [
	'$scope',
	'Items',
	function ($scope, Items) {
		Items.query(function(items) {
			$scope.items = items;
		});
	}
]);

itemControllers.controller('itemDetailController', [
	'$scope',
	'$stateParams',
	'Items',
	function ($scope, $stateParams, Items) {
		Items.get({ id: $stateParams.id }, function(item) {
			$scope.item = item;
		});
	}
]);
