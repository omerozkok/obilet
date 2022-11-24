// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let today = moment().format("YYYY-MM-DDTHH:mm");
let tomorrow = moment().add(1, 'days').format("YYYY-MM-DDTHH:mm");
var selectedOrigin;
var selectedDestination;



$(document).ready(function () {

    $("#departureDate").attr("min", today);
    $("#departureDate").val(tomorrow)

    $('#origin').val(349).trigger('change')
    $('#destination').val(350).trigger('change')

    $("#origin").select2({
        theme: 'bootstrap4',
    });

    var busLocationArray = [];

    $("#origin > option").each(function () {
        busLocationArray.push({
            "id": this.value,
            "text": this.text
        });
    });

    $("#destination").select2({
        theme: 'bootstrap4',
    });

    $('#origin').on("select2:select", function (e) {
        if ($('#origin').val() === $('#destination').val()) {
            alert('aynı seçim yapılamaz')
            $('#origin').val(-1).trigger('change')
        }        
    });
    $('#destination').on("select2:select", function (e) {
        if ($('#origin').val() === $('#destination').val()) {
            alert('aynı seçim yapılamaz')
            $('#destination').val(-1).trigger('change')
        }    
    });

   

});

function validateForm() {
    var x = document.forms["indexForm"]["origin"].value;
    var y = document.forms["indexForm"]["destination"].value;

    if (x <= "0" || y <= "0") {
        alert("Başlangıç veya Varış noktası boş geçilemez..");
        return false;
    }
}

function getToday() {
    $("#departureDate").val(today);
    localStorage.setItem("departureDate", today);
}
function getTomorrow() {
    $("#departureDate").val(tomorrow);
    localStorage.setItem("departureDate", tomorrow);
}

function changeLocation() {

    selectedOrigin = $("#origin option:selected").val();
    selectedDestination = $("#destination option:selected").val();
    $('#destination').val(selectedOrigin).trigger('change')
    $('#origin').val(selectedDestination).trigger('change')
    

}

