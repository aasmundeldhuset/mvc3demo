(function ($) {
    $.validator.addMethod("jqcount", function (value, element, params) {
        var thisValue;
        if (this.optional(element)) { // No value is always valid
            return true;
        }

        thisValue = value.split(" ").length;
        
        return thisValue < params;
    });


    $.validator.unobtrusive.adapters.add("wordcount", ["max"], function (options) {
        other = options.params.max,

        options.rules["jqcount"] = other;  // element becomes "params" in callback
        if (options.message) {
            options.messages["jqcount"] = options.message;
        }
    });
} (jQuery));