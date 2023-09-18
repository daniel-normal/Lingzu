// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Función para mostrar u ocultar el botón "scroll-to-top"
function toggleScrollToTopButton() {
    var scrollButton = document.getElementById("scroll-to-top");
    if (window.scrollY > 100) {
    scrollButton.style.display = "block";
    } else {
    scrollButton.style.display = "none";
    }
}

// Agrega un evento "scroll" al documento para llamar a la función cuando se desplaza
document.addEventListener("scroll", toggleScrollToTopButton);

// Función para hacer scroll al principio de la página cuando se hace clic en el botón
document.getElementById("scroll-to-top").addEventListener("click", function() {
    window.scrollTo({ top: 0, behavior: "smooth" });
});
