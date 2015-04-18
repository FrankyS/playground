(function () {
	'use strict';

	angular.module('dashboardModule').factory('Weather', [
		'$resource',
		function ($resource) {
			return $resource('Data/Weather/');
		}
	]);
})();