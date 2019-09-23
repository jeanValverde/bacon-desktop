(function($) {
  'use strict';
  $(function() {


    if ($("#customers-chart").length) {
      var customersChartCanvas = $("#customers-chart").get(0).getContext("2d");
      var customersChart = new Chart(customersChartCanvas, {
        type: 'bar',
        data: {
          labels: ["Jan", "Feb", "Mar", "Apr", "May","Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
          datasets: [{
              label: 'Profit',
              data: [15, 28, 14, 22, 38, 30, 40, 70, 85, 50, 23, 20],
              backgroundColor: '#6201ed'
            }
          ]
        },
        options: {
          responsive: true,
          maintainAspectRatio: true,
          layout: {
            padding: {
              left: 0,
              right: 0,
              top: 0,
              bottom: 0
            }
          },
          scales: {
            yAxes: [{
              display: false,
              gridLines: {
                drawBorder: false,
                color: '#f1f3f9',
                zeroLineColor: '#f1f3f9'
              },
              ticks: {
                display: false,
                fontColor: "#9fa0a2",
                padding: 0,
                stepSize: 20,
                min: 0,
                max: 100
              }
            }],
            xAxes: [{
              display: false,
              stacked: false,
              categoryPercentage: 1,
              ticks: {
                display: false,
                beginAtZero: false,
                display: true,
                padding: 10,
                fontSize: 11
              },
              gridLines: {
                color: "rgba(0, 0, 0, 0)",
                display: false
              },
              position: 'bottom',
              barPercentage: 0.7
            }]
          },
          legend: {
            display: false
          },
          elements: {
            point: {
              radius: 0
            }
          }
        }
      });
    }

    if ($('#revenue-chart').length) {
      var revenueCanvas = $("#revenue-chart").get(0).getContext("2d");
      var data = {
        labels: ["0", "1", "2", "3", "4", "5", "6", "7"],
        datasets: [
          {
            label: 'Revenue',
            data: [95, 90, 50, 60, 50 , 88, 82, 88],
            borderColor: [
              '#ff3366'
            ],
            borderWidth: 4,
            fill: true,
            backgroundColor: '#f5dde3'
          }
        ]
      };
      var options = {
        scales: {
          yAxes: [{
            display: false,
            gridLines: {
              drawBorder: false,
              lineWidth: 1,
              color: "#e9e9e9",
              zeroLineColor: "#e9e9e9",
            },
            ticks: {
              min: 0,
              max: 100,
              stepSize: 20,
              fontColor: "#6c7383",
              fontSize: 16,
              fontStyle: 300,
              padding: 15
            }
          }],
          xAxes: [{
            display: false,
            gridLines: {
              display: false,
              drawBorder: false,
              lineWidth: 1,
              color: "#e9e9e9",
            },
            ticks : {
              fontColor: "#6c7383",
              fontSize: 16,
              fontStyle: 300,
              padding: 15,
              mirror: true
            }
          }]
        },
        legend: {
          display: false
        },
        elements: {
          point: {
            radius: 0,
          },
          line :{
            tension: .4
          }
        },
        stepsize: 1,
        layout : {
          padding : {
            top: 0,
            bottom : -10,
            left : -10,
            right: 0
          }
        }
      };
      var revenue = new Chart(revenueCanvas, {
        type: 'line',
        data: data,
        options: options
      });
    }

    if ($('#revenue-chart-dark').length) {
      var revenueCanvas = $("#revenue-chart-dark").get(0).getContext("2d");
      var data = {
        labels: ["0", "1", "2", "3", "4", "5", "6", "7"],
        datasets: [
          {
            label: 'Revenue',
            data: [95, 90, 50, 60, 50 , 88, 82, 88],
            borderColor: [
              '#ff3366'
            ],
            borderWidth: 4,
            fill: true,
            backgroundColor: '#ecbdca'
          }
        ]
      };
      var options = {
        scales: {
          yAxes: [{
            display: false,
            gridLines: {
              drawBorder: false,
              lineWidth: 1,
              color: "#e9e9e9",
              zeroLineColor: "#e9e9e9",
            },
            ticks: {
              min: 0,
              max: 100,
              stepSize: 20,
              fontColor: "#6c7383",
              fontSize: 16,
              fontStyle: 300,
              padding: 15
            }
          }],
          xAxes: [{
            display: false,
            gridLines: {
              display: false,
              drawBorder: false,
              lineWidth: 1,
              color: "#e9e9e9",
            },
            ticks : {
              fontColor: "#6c7383",
              fontSize: 16,
              fontStyle: 300,
              padding: 15,
              mirror: true
            }
          }]
        },
        legend: {
          display: false
        },
        elements: {
          point: {
            radius: 0,
          },
          line :{
            tension: .4
          }
        },
        stepsize: 1,
        layout : {
          padding : {
            top: 0,
            bottom : -10,
            left : -10,
            right: 0
          }
        }
      };
      var revenue = new Chart(revenueCanvas, {
        type: 'line',
        data: data,
        options: options
      });
    }

    if ($('#conversion-chart').length) {
      var conversionCanvas = $("#conversion-chart").get(0).getContext("2d");
      var data = {
        labels: ["0", "1", "2", "3", "4"],
        datasets: [
          {
            label: 'Conversion',
            data: [30, 60, 40, 55, 30],
            borderColor: [
              'transparent'
            ],
            borderWidth: 0,
            fill: true,
            backgroundColor: 'rgba(251 ,188 ,6 ,.73)'
          },
          {
            label: 'Conversion',
            data: [70, 40, 80, 42, 69],
            borderColor: [
              'transparent'
            ],
            borderWidth: 0,
            fill: true,
            backgroundColor: 'rgba(251 ,188 ,6 ,.73)'
          }
        ]
      };
      var options = {
        scales: {
          yAxes: [{
            display: false,
            gridLines: {
              drawBorder: false,
              lineWidth: 1,
              color: "#e9e9e9",
              zeroLineColor: "#e9e9e9",
            },
            ticks: {
              min: 0,
              max: 100,
              stepSize: 20,
              fontColor: "#6c7383",
              fontSize: 16,
              fontStyle: 300,
              padding: 15
            }
          }],
          xAxes: [{
            display: false,
            gridLines: {
              display: false,
              drawBorder: false,
              lineWidth: 1,
              color: "#e9e9e9",
            },
            ticks : {
              fontColor: "#6c7383",
              fontSize: 16,
              fontStyle: 300,
              padding: 15,
              mirror: true
            }
          }]
        },
        legend: {
          display: false
        },
        elements: {
          point: {
            radius: 0,
          },
          line :{
            tension: .4
          }
        },
        stepsize: 1,
        layout : {
          padding : {
            top: 0,
            bottom : -10,
            left : -10,
            right: 0
          }
        }
      };
      var conversion = new Chart(conversionCanvas, {
        type: 'line',
        data: data,
        options: options
      });
    }

    if ($('#online-revenue-chart').length) {
      var onlineRevenueCanvas = $("#online-revenue-chart").get(0).getContext("2d");

      var gradient1 = onlineRevenueCanvas.createLinearGradient(0, 0, 0, 300);
      gradient1.addColorStop(0, 'rgba(5, 541, 186, .2)');
      gradient1.addColorStop(1, 'rgba(255,255,255,.2)');
      var gradient2 = onlineRevenueCanvas.createLinearGradient(0, 0, 0, 500);
      gradient2.addColorStop(0, '#dcd7ff');
      gradient2.addColorStop(1, 'rgba(255,255,255,0)');

      var data = {
        labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug"],
        datasets: [
          {
            label: 'Offline Revenue',
            data: [600, 620, 530, 610 , 540, 770, 700, 800],
            borderColor: [
              '#00dac5'
            ],
            borderWidth: 4,
            fill: true,
            backgroundColor: gradient1
          },
          {
            label: 'Online Revenue',
            data: [600, 800, 670, 930, 790 , 1100, 800, 920],
            borderColor: [
              '#6201ed'
            ],
            borderWidth: 4,
            fill: true,
            backgroundColor: gradient2
          }

        ]
      };
      var options = {
        scales: {
          yAxes: [{
            display: true,
            gridLines: {
              drawBorder: false,
              lineWidth: 1,
              color: "#f1f3f9",
              zeroLineColor: "#f1f3f9",
            },
            ticks: {
              min: 200,
              max: 1200,
              stepSize: 200,
              fontColor: "#979797",
              fontSize: 11,
              fontStyle: 400,
              padding: 15
            }
          }],
          xAxes: [{
            display: true,
            gridLines: {
              display: false,
              drawBorder: false,
              lineWidth: 1,
              color: "#e9e9e9",
            },
            ticks : {
              fontColor: "#979797",
              fontSize: 11,
              fontStyle: 400,
              padding: 15,
            }
          }]
        },
        legend: {
          display: false
        },
        legendCallback : function(chart) {
          var text = [];
          text.push('<div class="d-flex align-items-center">');
            text.push('<small class="text-muted">Online revenue</small>');
            text.push('<div class="ml-3" style="width: 12px; height: 12px; background-color: ' + chart.data.datasets[0].borderColor[0] +' "></div>');
          text.push('</div>');
          text.push('<div class="d-flex align-items-center mt-2">');
            text.push('<small class="text-muted">Offline revenue</small>');
            text.push('<div class="ml-3" style="width: 12px; height: 12px; background-color: ' + chart.data.datasets[1].borderColor[0] +' "></div>');
          text.push('</div>');
          return text.join('');
        },
        elements: {
          point: {
            radius: 2,
          },
          line :{
            tension: .35
          }
        },
        stepsize: 1,
        layout : {
          padding : {
            top: 30,
            bottom : 0,
            left : 0,
            right: 0
          }
        }
      };
      var onlineRevenue = new Chart(onlineRevenueCanvas, {
        type: 'line',
        data: data,
        options: options
      });
      document.getElementById('online-revenue-legend').innerHTML = onlineRevenue.generateLegend();
    }

    if ($('#online-revenue-chart-dark').length) {
      var onlineRevenueCanvas = $("#online-revenue-chart-dark").get(0).getContext("2d");

      var gradient1 = onlineRevenueCanvas.createLinearGradient(0, 0, 0, 350);
      gradient1.addColorStop(0, 'rgba(5, 541, 186, .5)');
      gradient1.addColorStop(1, 'rgba(0,0,0,0)');
      var gradient2 = onlineRevenueCanvas.createLinearGradient(0, 0, 0, 300);
      gradient2.addColorStop(0, 'rgba(98, 1, 237, .5)');
      gradient2.addColorStop(1, 'rgba(0,0,0,0)');

      var data = {
        labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug"],
        datasets: [
          {
            label: 'Offline Revenue',
            data: [600, 620, 530, 610 , 540, 770, 700, 800],
            borderColor: [
              '#00dac5'
            ],
            borderWidth: 4,
            fill: true,
            backgroundColor: gradient1
          },
          {
            label: 'Online Revenue',
            data: [600, 800, 670, 930, 790 , 1100, 800, 920],
            borderColor: [
              '#6201ed'
            ],
            borderWidth: 4,
            fill: true,
            backgroundColor: gradient2
          }

        ]
      };
      var options = {
        scales: {
          yAxes: [{
            display: true,
            gridLines: {
              drawBorder: false,
              lineWidth: 1,
              color: "rgba(46, 50, 74, .7)",
              zeroLineColor: "rgba(46, 50, 74, .7)",
            },
            ticks: {
              min: 200,
              max: 1200,
              stepSize: 200,
              fontColor: "#606A96",
              fontSize: 11,
              fontStyle: 400,
              padding: 15
            }
          }],
          xAxes: [{
            display: true,
            gridLines: {
              display: false,
              drawBorder: false,
              lineWidth: 1,
              color: "#e9e9e9",
            },
            ticks : {
              fontColor: "#606A96",
              fontSize: 11,
              fontStyle: 400,
              padding: 15,
            }
          }]
        },
        legend: {
          display: false
        },
        legendCallback : function(chart) {
          var text = [];
          text.push('<div class="d-flex align-items-center">');
            text.push('<small>Online revenue</small>');
            text.push('<div class="ml-3" style="width: 12px; height: 12px; background-color: ' + chart.data.datasets[0].borderColor[0] +' "></div>');
          text.push('</div>');
          text.push('<div class="d-flex align-items-center mt-2">');
            text.push('<small>Offline revenue</small>');
            text.push('<div class="ml-3" style="width: 12px; height: 12px; background-color: ' + chart.data.datasets[1].borderColor[0] +' "></div>');
          text.push('</div>');
          return text.join('');
        },
        elements: {
          point: {
            radius: 2,
          },
          line :{
            tension: .35
          }
        },
        stepsize: 1,
        layout : {
          padding : {
            top: 30,
            bottom : 0,
            left : 0,
            right: 0
          }
        }
      };
      var onlineRevenue = new Chart(onlineRevenueCanvas, {
        type: 'line',
        data: data,
        options: options
      });
      document.getElementById('online-revenue-legend').innerHTML = onlineRevenue.generateLegend();
    }    

    if ($("#online-sales-chart").length) {
      var areaData = {
        labels: ["Jan", "Feb", "Mar"],
        datasets: [{
            data: [30, 30, 40],
            backgroundColor: [
              "#4d83ff", "#6201ed", "#1ad5c3"
            ],
            borderColor: "rgba(0,0,0,0)"
          }
        ]
      };
      var areaOptions = {
        responsive: true,
        maintainAspectRatio: true,
        segmentShowStroke: false,
        cutoutPercentage: 55,
        elements: {
          arc: {
              borderWidth: 4
          }
        },      
        legend: {
          display: false
        },
        tooltips: {
          enabled: true
        }
      }
      var onlineSalesChartCanvas = $("#online-sales-chart").get(0).getContext("2d");
      var onlineSalesChart = new Chart(onlineSalesChartCanvas, {
        type: 'doughnut',
        data: areaData,
        options: areaOptions,
      });
    }

    if ($("#total-sales-chart").length) {
      var areaData = {
        labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov"],
        datasets: [{
            data: [30, 35, 20, 30, 26, 35 ,34 , 20, 25, 20, 28],
            backgroundColor: [
              '#1ad5c3'
            ],
            borderColor: [
              'transparent'
            ],
            borderWidth: 1,
            fill: 'origin',
            label: "purchases"
          },
          {
            data: [60, 55, 80, 50, 55, 52, 60, 52, 85, 75, 80],
            backgroundColor: [
              '#e3e3e3'
            ],
            borderColor: [
              'transparent'
            ],
            borderWidth: 1,
            fill: 'origin',
            label: "services"
          }
        ]
      };
      var areaOptions = {
        responsive: true,
        maintainAspectRatio: true,
        plugins: {
          filler: {
            propagate: false
          }
        },
        scales: {
          xAxes: [{
            display: false,
            ticks: {
              display: true
            },
            gridLines: {
              display: false,
              drawBorder: false,
              color: 'transparent',
              zeroLineColor: '#eeeeee'
            }
          }],
          yAxes: [{
            display: false,
            ticks: {
              display: true,
              autoSkip: false,
              maxRotation: 0,
              stepSize: 100,
              min: 0,
              max: 100
            },
            gridLines: {
              drawBorder: false
            }
          }]
        },
        legend: {
          display: false
        },
        tooltips: {
          enabled: true
        },
        elements: {
          line: {
            tension: .40
          },
          point: {
            radius: 0
          }
        }
      }
      var totalSalesCanvas = $("#total-sales-chart").get(0).getContext("2d");
      var totalSales = new Chart(totalSalesCanvas, {
        type: 'line',
        data: areaData,
        options: areaOptions
      });
    }

    if ($("#total-sales-chart-dark").length) {
      var areaData = {
        labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov"],
        datasets: [{
            data: [30, 35, 20, 30, 26, 35 ,34 , 20, 25, 20, 28],
            backgroundColor: [
              '#1ad5c3'
            ],
            borderColor: [
              'transparent'
            ],
            borderWidth: 1,
            fill: 'origin',
            label: "purchases"
          },
          {
            data: [60, 55, 80, 50, 55, 52, 60, 52, 85, 75, 80],
            backgroundColor: [
              '#6646ed'
            ],
            borderColor: [
              'transparent'
            ],
            borderWidth: 1,
            fill: 'origin',
            label: "services"
          }
        ]
      };
      var areaOptions = {
        responsive: true,
        maintainAspectRatio: true,
        plugins: {
          filler: {
            propagate: false
          }
        },
        scales: {
          xAxes: [{
            display: false,
            ticks: {
              display: true
            },
            gridLines: {
              display: false,
              drawBorder: false,
              color: 'transparent',
              zeroLineColor: '#eeeeee'
            }
          }],
          yAxes: [{
            display: false,
            ticks: {
              display: true,
              autoSkip: false,
              maxRotation: 0,
              stepSize: 100,
              min: 0,
              max: 100
            },
            gridLines: {
              drawBorder: false
            }
          }]
        },
        legend: {
          display: false
        },
        tooltips: {
          enabled: true
        },
        elements: {
          line: {
            tension: .40
          },
          point: {
            radius: 0
          }
        }
      }
      var totalSalesCanvas = $("#total-sales-chart-dark").get(0).getContext("2d");
      var totalSales = new Chart(totalSalesCanvas, {
        type: 'line',
        data: areaData,
        options: areaOptions
      });
    }

    if ($("#purchases-chart").length) {
      var purchasesChartCanvas = $("#purchases-chart").get(0).getContext("2d");
      var purchasesChart = new Chart(purchasesChartCanvas, {
        type: 'bar',
        data: {
          labels: ["Jan", "Feb", "Mar", "Apr", "May","Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
          datasets: [{
              label: 'Profit',
              data: [20, 23, 50, 85, 70, 40, 30, 26, 22, 18, 25, 19],
              backgroundColor: '#fbbc06'
            }
          ]
        },
        options: {
          responsive: true,
          maintainAspectRatio: true,
          layout: {
            padding: {
              left: 0,
              right: 0,
              top: 0,
              bottom: 0
            }
          },
          scales: {
            yAxes: [{
              display: true,
              gridLines: {
                drawBorder: false,
                color: '#f1f3f9',
                zeroLineColor: '#f1f3f9'
              },
              ticks: {
                display: false,
                fontColor: "#9fa0a2",
                padding: 0,
                stepSize: 20,
                min: 0,
                max: 100
              }
            }],
            xAxes: [{
              stacked: true,
              categoryPercentage: 1,
              ticks: {
                beginAtZero: true,
                display: true,
                padding: 10,
                fontSize: 11,
                fontColor: "#979797"
              },
              gridLines: {
                color: "rgba(0, 0, 0, 0)",
                display: true
              },
              position: 'bottom',
              barPercentage: 0.7
            }]
          },
          legend: {
            display: false
          },
          elements: {
            point: {
              radius: 0
            }
          }
        }
      });
    }

    if ($("#purchases-chart-dark").length) {
      var purchasesChartCanvas = $("#purchases-chart-dark").get(0).getContext("2d");
      var purchasesChart = new Chart(purchasesChartCanvas, {
        type: 'bar',
        data: {
          labels: ["Jan", "Feb", "Mar", "Apr", "May","Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
          datasets: [{
              label: 'Profit',
              data: [20, 23, 50, 85, 70, 40, 30, 26, 22, 18, 25, 19],
              backgroundColor: '#fbbc06'
            }
          ]
        },
        options: {
          responsive: true,
          maintainAspectRatio: true,
          layout: {
            padding: {
              left: 0,
              right: 0,
              top: 0,
              bottom: 0
            }
          },
          scales: {
            yAxes: [{
              display: true,
              gridLines: {
                drawBorder: false,
                borderWidth: 1,
                color: 'rgba(46, 50, 74, .7)',
                zeroLineColor: 'rgba(46, 50, 74, .7)'
              },
              ticks: {
                display: false,
                fontColor: "#606A96",
                padding: 0,
                stepSize: 20,
                min: 0,
                max: 80
              }
            }],
            xAxes: [{
              stacked: true,
              categoryPercentage: 1,
              ticks: {
                beginAtZero: true,
                display: true,
                padding: 10,
                fontSize: 11,
                fontColor: "#606A96"
              },
              gridLines: {
                color: "rgba(46, 50, 74, .7)",
                display: true
              },
              position: 'bottom',
              barPercentage: 0.7
            }]
          },
          legend: {
            display: false
          },
          elements: {
            point: {
              radius: 0
            }
          }
        }
      });
    }    

  });
})(jQuery);