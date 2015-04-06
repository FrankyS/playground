'use strict';

var itemServices = angular.module('itemServices', ['ngResource']);

itemServices.factory('Items', [
	'$resource',
	function ($resource) {
		return $resource('Data/Item/:id');
	}
]);