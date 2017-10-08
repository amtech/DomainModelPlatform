//模板收集器，将模板数据集合到一块
//首个元素被视作主要模板，并提供方法"插队",但插队建议只做一次，因为如果插队次数过多将会无法分辨那个是首要模板
var modelcollection = (function() {
  var __models = [];
  return {
    add: function(modelname, modelindex) {
      __models[__models.length] = {
        "name": modelname,
        "index": modelindex
      }
    },
    addmain: function(modelname, modelindex) {
      __models.unshift({
        "name": modelname,
        "index": modelindex
      })
    },
    get: function() {
      return __models;
    },
    modelmakeup: function(targetdom, targetindex) {
      //拼接-为每个事件做一个特定ID
      var __targetitems = targetindex;
      for (x in __targetitems) {
        __targetitems[x].modelindex = targetdom + "-" + x;
      }
      for (x in __models) {
        $.templates(__models[x].name, __models[x].index);
      }
      $(targetdom).html($.render[__models[0].name](targetindex));
      //绑定-为ID与特定ID绑定事件
      for (x in __targetitems) {
        if (__targetitems[x].events) {
          var selector = "[rel-modelindex=" + __targetitems[x].modelindex + "]";
          if (__targetitems[x].control_id) {
            selector = "#" + targetitems[x].control_id;
          }
          for(y in __targetitems[x].events){
            if (__targetitems[x].events[y].eventtarget) {
              $(selector).on(__targetitems[x].events[y].eventtype,__targetitems[x].events[y].eventtarget, __targetitems[x].events[y].eventfunc);
            }else{
              $(selector).on(__targetitems[x].events[y].eventtype,__targetitems[x].events[y].eventfunc);
            }
          }
        }
      }
    }
  }
})();

var jqgridinit = function(targettable, targetpager, oridata) {
  $targettable = $(targettable);
  $targettable.removeClass();
  $targetpager = $(targetpager);
  $.jgrid.defaults.styleUI = 'Bootstrap';
  $.jgrid.defaults.responsive = true;
  $targettable.jqGrid({
    datatype: "local",
    data: oridata,
    colModel: tableHeadBind,
    rowNum: 20,
    regional: 'cn',
    shrinkToFit: false,
    pager: $targetpager,
    page: 1
  });
  $targettable.jqGrid('bindKeys');
  $targettable.jqGrid("setFrozenColumns");
}
var jqgridwidthset = function(targettable, targetpager) {
  $(window).on("resize", function() {
    var gridheight = $targettable.parents(".ui-jqgrid").parent().height() - $(".ui-jqgrid-hbox").height() - $(".ui-jqgrid-pager").height() - 20;
    $targettable.jqGrid('setGridHeight', gridheight);
    //$targettable.jqGrid('setGridWidth', $targettable.parents(".ui-jqgrid").parent().width());
  });
}

earlyready = function() {

}

lateready = function() {
  $('[rel-type="timecontent"]').datepicker({
    language: "zh-CN"
  });
  $('.control-multiselect').multiselect();
  jqgridwidthset("#fixtable", "#jqGridPager");
  $(window).trigger('resize');
}

$.extend({
  pageinit: function(ready) {
    $([earlyready(), ready(), lateready()]);
  }
});
