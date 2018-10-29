window.jsLib = {
    focusElement: function(element) {
        element.focus();
    },
    hideElement: function(element) {
        element.setAttribute("hidden", true);
    },
    showElement: function(element) {
        element.removeAttribute("hidden");
    }
}