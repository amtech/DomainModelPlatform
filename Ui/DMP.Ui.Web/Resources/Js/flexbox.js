(function($) {
  $.fn.setflexbox = function(flexboxlist, option) {
    $flexboxlist = $(this).children(flexboxlist);
    //设置外框
    var $this = this;
    //私有方法区START-------------------------
    //快捷获取元素的权重
    var getFlow = function($target) {
      if ($target.attr("rel-flow")) {
        return $target.attr("rel-flow");
      }
      return 0;
    }

    //获取父盒子的高度(去掉固定元素)
    var getcontentflexheight = function() {
        return $this.height() - fixedheight.get();
      }
      //去除边框宽度与内边距宽度
    var getredundancyheight = function($target) {
      return $target.outerHeight(true) - $target.height();
    }

    //私有方法区END---------------------------
    //计数器区START-------------------------------

    //固定元素（没有权重的元素）的高度的计数器
    var fixedheight = (function() {
      var fheight = 0;
      return {
        get: function() {
          fheight = 0;
          $flexboxlist.each(function() {
            if (getFlow($(this)) == 0) {
              fheight += Math.floor($(this).outerHeight(true));
            }
          });
          return fheight;
        }
      }
    })();
    //高度总权重的计数器
    var flowcount = function() {
      var count = 0;
      $flexboxlist.each(function() {
        if($(this).is(":visible")){
          count += Math.floor(getFlow($(this)));
        }
      });
      return count;
    };
    //判断ie7
    var isie7 = (function() {
      return navigator.appName == "Microsoft Internet Explorer" && navigator.appVersion.split(";")[1].replace(/[ ]/g, "") == "MSIE7.0";
    })();

    //计数器区 END----------------------------



    //执行区START--------------------------------------

    //根据权重处理高度
    var setflexboxheight = function() {
      $flexboxlist.each(function() {
        if (getFlow($(this)) != 0) {
          var rightheight = ((getcontentflexheight() * getFlow($(this))) /
            flowcount()) - getredundancyheight($(this));
          //如果本身高度小于自己的最小高度，就以最小高度为准
          var min_height = 0;
          min_height = Math.floor($(this).attr("rel-min-height"));
          if (min_height) {
            $(this).css("height", (rightheight > min_height ? rightheight : min_height));
          } else {
            $(this).css("height", rightheight);
          }
        }
      });
    };
    setflexboxheight();
    $(window).on("resize", function() {
      setflexboxheight();
    });
  }
})(jQuery);
