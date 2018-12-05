window.jsLib = {
    focusElement: function(element) {
        console.log('focusElement(' + element.id + ')');
        element.focus();
    },
    hideElement: function(element) {
        console.log('hideElement(' + element.id + ')');
        element.setAttribute("hidden", true);
    },
    showElement: function(element) {
        console.log('showElement(' + element.id + ')');
        element.removeAttribute("hidden");
    }
};
