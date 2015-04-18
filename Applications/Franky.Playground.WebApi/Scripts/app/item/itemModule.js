(function () {
	'use strict';

	angular.module('itemModule', [])
		.config([
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
						controller: 'ItemListController',
						controllerAs: 'itemListCtrl'
					})

					.state('item.detail', {
						url: '/Detail/:id',
						templateUrl: 'Template/Item/Detail',
						controller: 'ItemDetailController',
						controllerAs: 'itemDetailCtrl'
					});
			}
		]);
})();