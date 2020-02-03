'use strict';

angular.
  module('core.article').
  factory('ArticleService', ['$http',
    function($http) {
      return {
       items: [],
       API_URL: "http://localhost:63463/api/articles", // to do move to env consts 
    
      getArticles(offset, pageSize) {
        return $http({url:`${this.API_URL}/?o=${offset}&ps=${pageSize}`});
        },
    
        createArticle(model) {
           return $http.post(this.API_URL, model);
        },
    
        deleteArticle(id) {
         return $http.delete(`${this.API_URL}/${id}`);
        }
      }
    }
  ]);
