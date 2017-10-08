(function ($) {
    // IE6\7\8 input 重封装，IE6\7\8不支持input事件，但支持propertychange事件
    if ('onpropertychange' in document) {
        // 检查是否为可输入元素
        var rinput = /^INPUT|TEXTAREA$/,
                isInput = function (elem) {
                    console.log(rinput.test(elem.nodeName));
                    return rinput.test(elem.nodeName);
                };

        $.event.special.input = {
            setup: function () {
                var thisObj = this,
                        $this = $(thisObj);
                if (!isInput(thisObj)) return false;
                $this.on('propertychange', function inputfunc() {
                    $this.data("inputfunccall", inputfunc);
                    if ($this.data.oldValue != $this.val()) {
                        $this.trigger("input");
                        $this.data("oldValue", $this.val());
                    }
                });
            },
            remove: function () {
                if (!isInput($(this))) return false;
                $(this).off('propertychange', $(this).data.inputfunc);
            }
        };
    };
})(jQuery);
