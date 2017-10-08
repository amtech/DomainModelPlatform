/*
该js为报表form的基类，继承于BaseForm
*/

function ReportForm() {
    BaseForm.call(this);
}

ReportForm.prototype = new BaseForm();

ReportForm.prototype.GridInit = function (gridId, gridPagerId) {
    var grid = $(gridId);
    grid.removeClass();
    var gridPager = $(gridPagerId);
    $.jgrid.defaults.styleUI = 'Bootstrap';
    var columns = new Array();
    var table = this.model.Tables[0];
    for (var i = 0; i < table.Columns.length; i++) {
        var col = table.Columns[i];
        if (!col.Visible) continue;
        columns.push({
            label: col.DisplayName,
            name: col.Name,
            index: col.FieldName
        });
    }

    /**
        addJSONData 
      
        使用传来的data数据填充表格。使用方法： 
        var mygrid = jQuery(”#”+grid_id)[0]; 
        var myjsongrid = eval(”(”+jsonresponse.responseText+”)”); 
        mygrid.addJSONData(myjsongrid); 
        myjsongrid = null; 
        jsonresponse =null; 
     */


    grid.jqGrid({
        datatype: "local",
        colModel: columns,
        rowNum: 20,
        regional: 'cn',
        pager: gridPager,
        page: 1
    });
    //支持键盘上下移动
    grid.jqGrid('bindKeys');
};

var reportForm = new ReportForm();

function onReady() {
    reportForm.searchColumns = new Array();
    reportForm.getModelInfo();
}

//override 获取模型后时机点
function afterGetModelInfo(result) {
    reportForm.model = JSON.parse(result.Items.model);
    $('#title').html(reportForm.model.DisplayName);
    for (var tbIndex in reportForm.model.Tables) {
        if (reportForm.model.Tables.hasOwnProperty(tbIndex)) {
            var table = reportForm.model.Tables[tbIndex];
            initColumns(table.Columns);
        }
    }
};

//override 执行ui初始化
function doInitUi() {
    drawConditonArea();
    reportForm.GridInit("#fixtable", "#jqGridPager", mydata);
    $(".container-fluid").setflexbox($(".nav.nav-tabs,.nav-tabs-body,.panel,.table-overscroll"));
    $(window).on("resize", function () {
        gridResize();
    });
    gridResize();
}

function gridResize() {
    var grid = jQuery("#fixtable");
    var gridheight = $(window).height() - $("#whereConditionArea").height() - $(".ui-jqgrid-pager").height() - $("#title").height() - 75;
    grid.jqGrid('setGridHeight', gridheight);
    grid.jqGrid('setGridWidth', grid.parents(".ui-jqgrid").parent().width());
}


//初始化列集合（筛选条件列集合，展示列集合）
function initColumns(columns) {
    for (var colIndex in columns) {
        if (columns.hasOwnProperty(colIndex)) {
            var col = columns[colIndex];
            if (col.IsSearch === true) //如果是查询条件
            {
                reportForm.searchColumns.push(col);
            }
        }
    }
}

//画查询区域
function drawConditonArea() {
    //模板拼接
    var searchColumns = {};
    searchColumns.items = [];

    for (var searchColIndex in reportForm.searchColumns) {
        if (reportForm.searchColumns.hasOwnProperty(searchColIndex)) {
            var searchCol = reportForm.searchColumns[searchColIndex];
            /*
            String,
            /// <summary>整型</summary>
            Int,
            /// <summary>布尔</summary>
            Bool,
            /// <summary>小数</summary>
            Decimal,
            /// <summary>日期</summary>
            Date 
            */
            var colType;
            switch (searchCol.ColumnType) {
                case 0:
                    colType = 'string';
                    break;
                case 1:
                    colType = 'int';
                    break;
                case 2:
                    colType = 'bool';
                    break;
                case 3:
                    colType = 'decimal';
                    break;
                case 4:
                    colType = 'date';
                    break;
                default:
                    colType = 'string';
                    break;
            }
            //如果是下拉选项 
            if (searchCol.Items && searchCol.Items.length > 0) {

                var options = new Array();

                for (var i = 0; i < searchCol.Items.length; i++) {
                    options.push({
                        "value": searchCol.Items[i].Value,
                        "index": searchCol.Items[i].Text
                    });
                }
                searchColumns.items.push({
                    type: "multiselect",
                    content_label: searchCol.DisplayName,
                    options: options
                });
            } else {
                switch (colType) {
                    case "string":
                        {
                            searchColumns.items.push({
                                type: "input",
                                content_label: searchCol.DisplayName,
                                addclass: "myclass",
                                events: [{
                                    eventtype: "click", eventtarget: ".form-control-simplified",
                                    eventfunc: function () {
                                        alert("!");
                                    }
                                }]
                            });
                        }
                        break;
                    case "int":
                        {
                            if (searchCol.Relationship) {
                                //关联字段
                                searchColumns.items.push({
                                    type: "input",
                                    content_label: searchCol.DisplayName,
                                    addclass: "myclass",
                                    events: [{
                                        eventtype: "click", eventtarget: ".form-control-simplified",
                                        eventfunc: function () {
                                            var col = searchCol;
                                            alert("!");
                                        }
                                    }]
                                });
                            }
                            else {
                                searchColumns.items.push({
                                    type: "input",
                                    content_label: searchCol.DisplayName,
                                    addclass: "myclass",
                                    events: [{
                                        eventtype: "click", eventtarget: ".form-control-simplified",
                                        eventfunc: function () {
                                            alert("!");
                                        }
                                    }]
                                });
                            }
                        }
                        break;
                    case "bool":
                        {
                            searchColumns.items.push({
                                type: "multiselect",
                                content_label: searchCol.DisplayName,
                                options: [{
                                    "value": "1", "index": "是"
                                }, {
                                    "value": "0", "index": "否"
                                }]
                            });
                        }
                        break;
                    case "decimal":
                        searchColumns.items.push({
                            type: "input",
                            content_label: searchCol.DisplayName,
                            addclass: "myclass",
                            events: [{
                                eventtype: "click", eventtarget: ".form-control-simplified",
                                eventfunc: function () {
                                    alert("!");
                                }
                            }]
                        });
                        break;
                    case "date":
                        searchColumns.items.push({
                            type: "time",
                            content_label: searchCol.DisplayName,
                            addclass: "myclass"
                        });
                        break;
                    default:
                }
            }

        }
    }
    //引入控件
    tmplFactory.include('text_box');
    tmplFactory.include('time_pickup');
    tmplFactory.include('multi_select');

    //模板规则
    var rule =
    '{{if type=="multiselect"}}' +
    '{{include tmpl="bs.multiSelect"/}}' +
    '{{else type=="time"}}' +
    '{{include tmpl="bs.timePickUp"/}}' +
    '{{else type=="input"}}' +
    '{{include tmpl="bs.textBox"/}}' +
    '{{/if}}';
    modelcollection.addmain("rule", rule);
    modelcollection.modelmakeup("#jsrender-head", searchColumns.items);
}

 

 

 