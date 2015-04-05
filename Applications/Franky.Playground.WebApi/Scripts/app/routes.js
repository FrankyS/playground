'use strict';

mainApp.config([
	'$stateProvider',
	'$urlRouterProvider',
	'$locationProvider',
	function ($stateProvider, $urlRouterProvider, $locationProvider) {
		$urlRouterProvider.otherwise('/');

		$stateProvider
			.state('dashboard', {
				url: '/',
				templateUrl: '/Home/Dashboard',
				data: { pageTitle: 'Dashboard' }
			})

			.state('about', {
				url: '/About',
				templateUrl: '/Home/About',
				data: { pageTitle: 'About' }
			});

		// use the HTML5 History API
		// currently kills the reload feature :-)
		// $locationProvider.html5Mode(true);
	}
]);