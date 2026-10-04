document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".nav-link-item").forEach(function (item) {
        if (item.href === window.location.href) item.classList.add("active");
    });
});
