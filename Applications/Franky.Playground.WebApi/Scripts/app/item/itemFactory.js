(function () {
	'use strict';

	angular.module('factoryModule').factory('Items', [
		'$resource',
		function ($resource) {
			return $resource('Data/Item/:id');
		}
	]);
})();