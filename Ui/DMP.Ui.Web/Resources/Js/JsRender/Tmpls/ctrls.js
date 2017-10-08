//模板收集器，将模板数据集合到一块
//首个元素被视作主要模板，并提供方法"插队",但插队建议只做一次，因为如果插队次数过多将会无法分辨那个是首要模板
var modelcollection = (function () {
    var models = [];
    return {
        add: function (modelname, modelindex) {
            models[models.length] = {
                "name": modelname,
                "index": modelindex
            }
        },
        addmain: function (modelname, modelindex) {
            models.unshift({
                "name": modelname,
                "index": modelindex
            });
        },
        get: function () {
            return models;
        },
        modelmakeup: function (targetdom, targetindex) {
            //拼接-为每个事件做一个特定ID
            var targetitems = targetindex;
            var x;
            for (x in targetitems) {
                if (targetitems.hasOwnProperty(x)) {
                    targetitems[x].modelindex = targetdom + "-" + x;
                }
            }
            for (x in models) {
                if (models.hasOwnProperty(x)) {
                    $.templates(models[x].name, models[x].index);
                }
            }
            $(targetdom).html($.render[models[0].name](targetindex));
            //绑定-为ID与特定ID绑定事件
            for (x in targetitems) {
                if (targetitems[x].events) {
                    var selector = "[rel-modelindex=" + targetitems[x].modelindex + "]";
                    if (targetitems[x].control_id) {
                        selector = "#" + targetitems[x].control_id;
                    }
                    for (y in targetitems[x].events) {
                        if (targetitems[x].events[y].eventtarget) {
                            $(selector).on(targetitems[x].events[y].eventtype, targetitems[x].events[y].eventtarget, targetitems[x].events[y].eventfunc);
                        } else {
                            $(selector).on(targetitems[x].events[y].eventtype, targetitems[x].events[y].eventfunc);
                        }
                    }
                }
            }
        }
    }
})();

var tmplFactory = (function () {
    return {
        include: function (type) {

            switch (type) {
                case 'text_box':
                    {
                        var textBox =
                        '<div id="{{: control_id}}" class="form-group-sm col-xs-12 col-sm-4 col-lg-3 col-ie7-4" rel-modelindex="{{: modelindex}}">' +
                          '<label class="control-label" for="">{{: content_label}}</label>' +
                          '<div class="form-control-content">' +
                          '<input type="text" class="form-control-simplified" />' +
                          '</div>' +
                          '</div>';
                        modelcollection.add("bs.textBox", textBox);
                    }
                case 'time_pickup':
                    {
                        var timePickUp =
                        '<div id="{{: control_id}}" class="form-group-sm col-xs-12 col-sm-4 col-lg-3 col-ie7-4 hidden-ie7" rel-modelindex="{{: modelindex}}">' +
                          '<label class="control-label" for="">{{: content_label}}</label>' +
                          '<div class="form-control-content">' +
                          '<div class="input-daterange input-group" rel-type="timecontent" id="datepicker">' +
                          '<input type="text" class="input form-control" name="start" />' +
                          '<span class="input-group-addon">至</span>' +
                          '<input type="text" class="input form-control" name="end" />' +
                          '</div>' +
                          '</div>' +
                          '</div>';
                        modelcollection.add("bs.timePickUp", timePickUp);
                    }
                case 'multi_select':
                    {
                        var multiSelect =
                        '<div id="{{: control_id}}" class="form-group-sm col-xs-12 col-sm-4 col-lg-3 col-ie7-4 hidden-ie7" rel-modelindex="{{: modelindex}}">' +
                          '<label class="control-label" for="">{{: content_label}}</label>' +
                          '<div class="form-control-content">' +
                          '<select class="control-multiselect form-control"  multiple="multiple">' +
                          '{{for options}}' +
                          '<option value="{{:value}}">{{:index}}</option>' +
                          '{{/for}}' +
                          '</select>' +
                          '</div>' +
                          '</div>';
                        modelcollection.add("bs.multiSelect", multiSelect);
                    }
                default:
                    { }
            } 
        }
    }
})(); 


