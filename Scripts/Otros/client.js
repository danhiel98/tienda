$(".btn-edit").on("click", function (e) {
    e.preventDefault();
    var idCliente = this.id;

    $.ajax({
        type: "GET",
        url: '/Admin/Ajax/ObtenerCliente',
        data: { idClient: idCliente },
        success: function (data) {
            var oDato = JSON.parse(data);
            //console.log(oDato);
            $('#Contenido_eid').val(oDato[0].ID);
            $('#Contenido_enombre').val(oDato[0].Nombre);
            $('#Contenido_eapellido').val(oDato[0].Apellido);
            $('#Contenido_eemail').val(oDato[0].Email);
            $('#Contenido_etelefono').val(oDato[0].Telefono);
            $('#Contenido_edireccion').val(oDato[0].Direccion);
        }
    });
});

$("#Contenido_btnGuardarI").on("click", function (e) {
    e.preventDefault();
    var nombre = $('#nombre').val(),
        apellido = $('#apellido').val(),
        email = $('#email').val(),
        telefono = $('#telefono').val(),
        direccion = $('#direccion').val(),
        login = $('#login').val(),
        clave = $('#clave').val();

    $.ajax({
        type: "GET",
        url: '/Admin/Clients',
        data: {
            guardar: "true",
            nombreC: nombre,
            apellidoC: apellido,
            emailC: email,
            telefonoC: telefono,
            direccionC: direccion,
            loginC: login,
            claveC: clave
        },
        success: function () {
            alert("Datos Guardados Correctamente!");
            location = "/Admin/Clients";
        }
    });
});

$("#Contenido_btnUpdateI").on("click", function (e) {
    e.preventDefault();
    var id = $('#Contenido_eid').val(),
        nombre = $('#Contenido_enombre').val(),
        apellido = $('#Contenido_eapellido').val(),
        email = $('#Contenido_eemail').val(),
        telefono = $('#Contenido_etelefono').val(),
        direccion = $('#Contenido_edireccion').val();

    $.ajax({
        type: "GET",
        url: '/Admin/Clients',
        data: {
            actualizar: "true",
            idClient: id,
            nombreC: nombre,
            apellidoC: apellido,
            emailC: email,
            telefonoC: telefono,
            direccionC: direccion
        },
        success: function () {
            alert("Datos Actualizados Correctamente!");
            location = "/Admin/Clients";
        }
    });
});