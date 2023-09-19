function actualizarPrecio() {
    var select = document.getElementById("ProductoIdSeleccionado");
    var precio = select.options[select.selectedIndex].getAttribute("data-precio");
    var nombreProducto = select.options[select.selectedIndex].text;
    var precioInput = document.getElementById("Producto_PrecioProducto");
    var nombreProductoInput = document.getElementById("Producto_NombreProducto");
    if (precioInput) {
        precioInput.value = precio;
    }
    if (nombreProductoInput) {
        nombreProductoInput.value = nombreProducto;
    }
}