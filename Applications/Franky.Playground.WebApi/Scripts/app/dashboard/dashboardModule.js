(function () {
	'use strict';

	angular.module('dashboardModule', [])
		.config([
			'$stateProvider',
			function ($stateProvider) {
				$stateProvider
					.state('dashboard', {
						url: '',
						abtract: true,
						templateUrl: 'Template/Dashboard',
						data: { pageTitle: 'Dashboard' }
					})

					.state('dashboard.index', {
						url: '/',
						views: {
							'weather': {
								templateUrl: 'Template/Dashboard/Weather',
								controller: 'WeatherController',
								controllerAs: 'weatherCtrl'
							},
							'calendar': {
								templateUrl: 'Template/Dashboard/Calendar'
							}
						}
					});
			}
		]);
})();