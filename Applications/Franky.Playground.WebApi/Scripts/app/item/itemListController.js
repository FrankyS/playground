(function () {
	'use strict';
	

	angular.module('itemModule')
		.controller('ItemListController', [
			'$scope',
			'$compile',
			'Items',
			function ($scope, $compile, Items) {
				var vm = this;

				function initDataTable() {
					$('#example').dataTable({
						'ajax': {
							'url': 'Data/Item',
							'dataSrc': ''
						},
						'processing': true,
						'serverSide': true,
						'stateSave': true,
						'columnDefs': [
							{ 'targets': -1, 'render': function(data) { return '<a ui-sref="item.detail({id: ' + data.id + '})">Edit</a>'; } }
						],
						'createdRow': function(row) {
							$compile(row)($scope);
						},
						'columns': [
							{ 'data': 'id' },
							{ 'data': 'name' },
							{ 'data': 'type' },
							{ 'data': 'rights' },
							{ 'data': 'dateTime' },
							{ 'data': null }
						]
					});
				}

				initDataTable();

				//Items.query(function (items) {
				//	vm.items = items;
				//});
			}
		]);
})();