(function () {
	'use strict';

	angular.module('mainModule').config([
		'$stateProvider',
		'$urlRouterProvider',
		'$locationProvider',
		function ($stateProvider, $urlRouterProvider, $locationProvider) {
			$urlRouterProvider.otherwise('/');

			$stateProvider
				.state('about', {
					url: '/About',
					templateUrl: 'Template/Home/About',
					data: { pageTitle: 'About' }
				});

			// use the HTML5 History API
			$locationProvider.html5Mode(true);
		}
	]);
})();