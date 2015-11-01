'use strict';


var Module = angular.module('myApp.factories', []);


Module.factory("Student", ["$resource",
function ($resource) {
    var resource = $resource('http://localhost:3306/api/Student', {}, { get: { method: 'GET', isArray: true } });
    return resource;
}
]);

/* Controllers */
angular.module('myApp.controllers', [])
    .controller('MyCtrl1', ['$scope', 'Student', function ($scope, Student) {
        $scope.sttdents = [];
        Student.get(function (response) {
            $scope.stdents = response;
            //console.log(response);
        });
    }])
  .controller('MyCtrl2', ['$scope', 'Student', function ($scope, Student) {

      $scope.name = '';
      $scope.phone = '';
      $scope.address = '';
      //Student.save({ Name: "Amit", Phone: "0191", Address: "Rajahahi" }, function(response) {
      //    console.log(response);
      //});

      $scope.save = function() {
         
        Student.save({ Name: $scope.name, Phone: $scope.phone, Address: $scope.address }, function(response) {
            if (response) {
                $scope.name = '';
                $scope.phone = '';
                $scope.address = '';
                $scope.confirmation = "Data is saved";
            } else {
                $scope.confirmation = "Data is not saved";
            }
        });

    };

}]);
