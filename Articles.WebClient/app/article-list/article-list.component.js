'use strict';

angular.
  module('articleList').
  component('articleList', {
    templateUrl: 'article-list/article-list.template.html',
    controller: ['$scope','ArticleService',
    function ArticleListController(scope,ArticleService) {
      this.offset = 0;
      this.pageSize = 10;
      this.makeAnotherRequest = true;
      this.articles = [];
      ArticleService.getArticles(this.offset, this.pageSize).then(function(resp) {
       scope.$ctrl.articles = resp.data;
      });
      
      scope.onDelButtonClick = function(id) {
        ArticleService.deleteArticle(id).then(function(resp) {
            scope.$ctrl.articles = scope.$ctrl.articles.filter(function(p){
              return p.Id !== id
            });
        });
      }

      scope.onLoadNewArticlesButtonClick = function() {
        if(scope.$ctrl.makeAnotherRequest) {
          ArticleService.getArticles(++scope.$ctrl.offset, scope.$ctrl.pageSize).then(function(resp) {
            if(resp.data.length < scope.$ctrl.pageSize) {
              scope.$ctrl.makeAnotherRequest = false;
            }
            scope.$ctrl.articles = scope.$ctrl.articles.concat(resp.data);
           });
        }
      }

      scope.onAddArticleButtonClick = function() {
        let title = scope.inputTitle;
        let description = scope.inputDescription;
        if(!title || !description) { // to do proper validation
          alert("fill all inputs"); //to do proper popup window
          return;
        }
        ArticleService.createArticle({Title: title, Description: description})
        .then(function(resp){
          console.log(resp);
          scope.$ctrl.articles.unshift(resp.data);
        });        
      }

      }
    ]
  });
