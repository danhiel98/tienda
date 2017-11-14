$(".btn-send").on("click", function (e) {
    e.preventDefault();
    var idPedido = this.id;

    $.ajax({
        type: "GET",
        url: '/Admin/Requests',
        data: {
            idPedidoSend: idPedido
        },
        success: function () {
            alert("Se ha enviado el pedido!");
        }
    });
});