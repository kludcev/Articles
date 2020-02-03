'use strict';

angular.
  module('articleApp').
  config(['$routeProvider',
    function config($routeProvider) {
      $routeProvider.
        when('/articles', {
          template: '<article-list></article-list>'
        })
        .otherwise({
          redirectTo:'/articles'
        });
    }
  ]);
