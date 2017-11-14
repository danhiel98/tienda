$(".btn-add").on("click", function () {
    var idProd = this.id;
    var cantidad = $("#cantidad" + idProd);
    var cant = cantidad.val();
    //alert(cantidad.attr("max"));
    if (cant <= 0 || cant > cantidad.attr("max")) {
        alert("La cantidad a comprar debe estar entre 1 y " + cantidad.attr("max"));
    } else {
        $.ajax({
            type: "GET",
            url: "/Admin/Ajax/AddToCart",
            data: {
                idPrd: idProd,
                cant: cant
            },
            success: function () {
                alert("Producto agregado al carrito!");
            }
        });
    }
});