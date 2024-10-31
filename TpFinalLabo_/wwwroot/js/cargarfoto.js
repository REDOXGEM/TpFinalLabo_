$(document).ready(function () {
    $("#seleccionImg").change(function () {
        var tam = this.files[0].size;
        if (tam > 5000000) {
            alert("El tamaño del archivo no debe ser mayor a 5 mb");
        }
        else {
            readURL(this);
        }
    });
});
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $("#imagen").attr("src", e.target.result);
        }
        reader.readAsDataURL(input.files[0]); //lee como un string en base64
    }
}