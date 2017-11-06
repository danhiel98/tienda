$(".btn-edit").on("click", function (e) {
    e.preventDefault();
    var idProv = this.id;

    $.ajax({
        type: "GET",
        url: '/Admin/Ajax/ObtenerProveedor',
        data: { idProvd: idProv },
        success: function (data) {
            var oDato = JSON.parse(data);
            //console.log(oDato);
            $('#Contenido_eid').val(oDato[0].ID);
            $('#Contenido_enombre').val(oDato[0].Nombre);
            $('#Contenido_eemail').val(oDato[0].Email);
            $('#Contenido_etelefono').val(oDato[0].Telefono);
            $('#Contenido_edireccion').val(oDato[0].Direccion);
            $('#Contenido_econtacto').val(oDato[0].PersonaContacto);
            $('#Contenido_etelContacto').val(oDato[0].TelPersonaContacto);
        }
    });
});

$("#Contenido_btnGuardarI").on("click", function (e) {
    e.preventDefault();
    var nombre = $('#nombre').val(),
        email = $('#email').val(),
        telefono = $('#telefono').val(),
        direccion = $('#direccion').val(),
        contacto = $('#contacto').val(),
        telContacto = $('#telContacto').val()

    $.ajax({
        type: "GET",
        url: '/Admin/Providers',
        data: {
            guardar: "true",
            nombreC: nombre,
            emailC: email,
            telefonoC: telefono,
            direccionC: direccion,
            contactoC: contacto,
            telContactoC: telContacto
        },
        success: function () {
            alert("Datos Guardados Correctamente!");
            location = "/Admin/Providers";
        }
    });
});

$("#Contenido_btnUpdateI").on("click", function (e) {
    e.preventDefault();
    var id = $('#Contenido_eid').val(),
        nombre = $('#Contenido_enombre').val(),
        email = $('#Contenido_eemail').val(),
        telefono = $('#Contenido_etelefono').val(),
        direccion = $('#Contenido_edireccion').val(),
        contacto = $('#Contenido_econtacto').val(),
        telContacto = $('#Contenido_etelContacto').val();

    $.ajax({
        type: "GET",
        url: '/Admin/Providers',
        data: {
            actualizar: "true",
            idProv: id,
            nombreC: nombre,
            emailC: email,
            telefonoC: telefono,
            direccionC: direccion,
            contactoC: contacto,
            telContactoC: telContacto
        },
        success: function () {
            alert("Datos Actualizados Correctamente!");
            location = "/Admin/Providers";
        }
    });
});