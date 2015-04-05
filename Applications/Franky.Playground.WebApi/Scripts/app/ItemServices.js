var itemServices = angular.module('itemServices', ['ngResource']);

itemServices.factory('Items', ['$resource',
	function ($resource) {
		return $resource('/api/values', {}, {
			query: { method: 'GET', params: {}, isArray: true }
		});
	}]);