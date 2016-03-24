//jquery的静态插件 $.tablewidthcount()
(function($) {
  $.extend({
    "tablewidthcount": function($table, min_height) {
      count = 0;
      min_height = !min_height ? 0 : min_height;
      $table.find("th").each(function() {
        count += $(this).outerWidth(true) + 1;
      });
      return count > min_height ? count : min_height;
    }
  });
})(jQuery);
