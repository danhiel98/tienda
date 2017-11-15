$(".btn-entregado").on("click", function () {
    var idProd = this.id;
    var cantidad = $("#cantidad" + idProd);
    var canti = cantidad.val();
    var max = cantidad.attr("max")
    $.ajax({
        type: "GET",
        url: "/Admin/Ajax/AddToCart",
        data: {
            idPrd: idProd,
            cant: canti
        },
        success: function () {
            alert("Producto agregado al carrito!");
        }
    });
});