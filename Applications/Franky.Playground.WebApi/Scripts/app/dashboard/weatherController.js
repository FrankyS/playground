(function () {
	'use strict';

	angular.module('dashboardModule')
		.controller('WeatherController', [
			'$scope',
			'Weather',
			function ($scope, Weather) {
				var vm = this;
				Weather.get(function (weather) {
					vm.weather = weather;
				});
			}
		]);
})();