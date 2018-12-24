window.jsLib = {
    focusElement: function(element) {
        element.focus();
    },
    hideElement: function(element) {
        element.setAttribute("hidden", true);
    },
    showElement: function(element) {
        element.removeAttribute("hidden");
    },
    createAutocomplete: function(element) {
        $('#input').autoComplete({
            minChars: 2,
            source: function(term, suggest) {
                term = term.toLowerCase();
                var choices = ['ActionScript', 'AppleScript', 'Asp'];
                var matches = [];
                for (i = 0; i < choices.length; i++)
                    if (~choices[i].toLowerCase().indexOf(term)) matches.push(choices[i]);
                suggest(matches);
            }
        });
    }
};
