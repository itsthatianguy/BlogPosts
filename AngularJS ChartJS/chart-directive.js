angular.module('app').directive('chartDirective', function() {
  return {
    template: '<canvas id="currentChart" width="600" height="400"></canvas>',
    restrict: 'E',
    scope: {
            Options: '=options',
            Data: '=chartData',
            ChartType: '=chartType'
        },
    link: function(scope, element, attributes) {      
      // Need to set up for line, bar and pie charts
      // No mapchart available
      var createChart = function() { 
        var createdChart;
        var chartContext = document.getElementById("currentChart").getContext("2d");
        
        switch (scope.ChartType){
          case 'line':
            createdChart = new Chart(chartContext).Line(scope.Data, scope.Options);
            break;
          case 'pie':
            createdChart = new Chart(chartContext).Pie(scope.Data, scope.Options);
            break;
          case 'bar':
            createdChart = new Chart(chartContext).Bar(scope.Data, scope.Options);
            break;
          case 'radar':
            createdChart = new Chart(chartContext).Radar(scope.Data, scope.Options);
            break;
          case 'polarArea':
            createdChart = new Chart(chartContext).PolarArea(scope.Data, scope.Options);
            break;
          default:
            break;
        }
        return createdChart;
      }
      scope.currentChart = createChart();
    }
  }
});