+function ($) {
    'use strict';
    var version = $.fn.jquery.split(' ')[0].split('.')
    if (version[0] < 2 && version[1] < 7) {
        throw new Error('Bootstrap\'s JavaScript requires jQuery version 1.9.1 or higher')
    }
} (jQuery);

var ieVer = (function () {
    if (navigator.appName == "Microsoft Internet Explorer") {
        return navigator.appVersion.split(";")[1].replace(/[ ]/g, "").split("")[4];
    }
    return 0;
})();
(function ($) {
    $.fn.inputHelper = function (option) {
        var defaultoption = {
            "listen": false,
            "only-num": true
        }
        var currentOption;
        if (option) {
            currentOption = option;
        } else {
            currentOption = defaultoption;
        }
        var inputFun = function (e, $this) {
            var temparr = $this.val().split("");
            if (isNaN(temparr[temparr.length - 1])) {
                temparr.pop();
            }
            $this.val(temparr.join(""));
        }
        $this = $(this);
        var eventstr = "input";
        if (currentOption.listen) {
            $("body").on(eventstr, $this.selector, function (e) {
                return inputFun(e, $(this));
            });
        } else {
            $this.on(eventstr, function (e) {
                return inputFun(e, $(this));
            });
        }
    }
})(jQuery)
