// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function getCanvasSize(canvasId) {
    const canvas = document.getElementById(canvasId);
    return { width: canvas.offsetWidth, height: canvas.offsetHeight };
}

function setCirclePosition(elementId, x, y) {
    const element = document.getElementById(elementId);
    element.style.left = `${x}px`;
    element.style.top = `${y}px`;
}
