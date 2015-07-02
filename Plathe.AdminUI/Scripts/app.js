// datepicker
$('.datepicker').datepicker({

    language: 'nl',
    format: 'dd-mm-yyyy',
    endDate: '0',
    todayBtn: true,
    orientation: 'auto top',
    todayHighligh: true

}).on('changeDate', function (e) {
    var url = [location.protocol, '//', location.host, location.pathname].join('');
    var date = $('.datepicker').val();
    window.location.href = url + '?date=' + date;
});

// range datepicker
$(".input-daterange input").each(function () {
    $(this).datepicker({
        language: 'nl',
        format: 'd-m-yyyy 0:00:00',
        orientation: 'auto top',
        minViewMode: 'months',
        endDate: '0',
        todayHighligh: true
    });
});

// chart
Chart.defaults.global.animation = false;
var canvas = $("#occupationChart, #revenueChart");
var ctx = canvas.get(0).getContext("2d");


// pie chart data
var data = [
    {
        value: canvas.data('totalseats'),
        color: "#F7464A",
        highlight: "#FF5A5E",
        label: "Lege stoelen"
    },
    {
        value: canvas.data('totaloccupiedseats'),
        color: "#46BFBD",
        highlight: "#5AD3D1",
        label: "Bezette stoelen"
    }
];
var occupationChart = new Chart(ctx).Pie(data);


// line chart
if ('undefined' !== typeof revenueData) {
    var revenueChart = new Chart(ctx).Line(revenueData);
}