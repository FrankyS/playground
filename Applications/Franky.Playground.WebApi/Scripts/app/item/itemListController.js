(function () {
	'use strict';

	angular.module('itemModule')
		.controller('ItemListController', [
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
})();