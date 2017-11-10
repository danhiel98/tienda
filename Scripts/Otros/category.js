$(".btn-edit").on("click", function (e) {
    e.preventDefault();
    var idCategoria = this.id;

    $.ajax({
        type: "GET",
        url: '/Admin/Ajax/ObtenerCategoria',
        data: { idCat: idCategoria },
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
        url: '/Admin/Categories',
        data: {
            guardar: "true",
            nombreC: nombre
        },
        success: function () {
            alert("Datos Guardados Correctamente!");
            location = "/Admin/Categories";
        }
    });
});

$("#Contenido_btnUpdateI").on("click", function (e) {
    e.preventDefault();
    var id = $('#Contenido_eid').val(),
        nombre = $('#Contenido_enombre').val();
        
    $.ajax({
        type: "GET",
        url: '/Admin/Categories',
        data: {
            actualizar: "true",
            idCategory: id,
            nombreC: nombre
        },
        success: function () {
            alert("Datos Actualizados Correctamente!");
            location = "/Admin/Categories";
        }
    });
});