(function () {
	'use strict';

	angular.module('itemModule')
		.controller('ItemDetailController', [
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