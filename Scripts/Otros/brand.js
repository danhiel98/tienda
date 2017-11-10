$(".btn-edit").on("click", function (e) {
    e.preventDefault();
    var idMarca = this.id;

    $.ajax({
        type: "GET",
        url: '/Admin/Ajax/ObtenerMarca',
        data: { idMrc: idMarca },
        success: function (data) {
            var oDato = JSON.parse(data);
            //console.log(oDato);
            $('#Contenido_eid').val(oDato[0].ID);
            $('#Contenido_enombre').val(oDato[0].Nombre);
        }
    });
});

$("#Contenido_btnGuardarI").on("click", function (e) {
    e.preventDefault();
    var nombre = $('#nombre').val();

    $.ajax({
        type: "GET",
        url: '/Admin/Brands',
        data: {
            guardar: "true",
            nombreC: nombre
        },
        success: function () {
            alert("Datos Guardados Correctamente!");
            location = "/Admin/Brands";
        }
    });
});

$("#Contenido_btnUpdateI").on("click", function (e) {
    e.preventDefault();
    var id = $('#Contenido_eid').val(),
        nombre = $('#Contenido_enombre').val();
        
    $.ajax({
        type: "GET",
        url: '/Admin/Brands',
        data: {
            actualizar: "true",
            idMarcaC: id,
            nombreC: nombre
        },
        success: function () {
            alert("Datos Actualizados Correctamente!");
            location = "/Admin/Brands";
        }
    });
});