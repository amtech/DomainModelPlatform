/*
该js为报表form的基类，继承于BaseForm
*/

function ReportForm() {
    BaseForm.call(this);
}
ReportForm.prototype = new BaseForm();
var reportForm = new ReportForm();

$(document).ready(function () {
    reportForm.searchColumns = new Array();
    reportForm.getModelInfo();

});

//override
function afterGetModelInfo(result) {
    reportForm.model = JSON.parse(result.Items.model);
    for (var tbIndex in reportForm.model.Tables) {
        if (reportForm.model.Tables.hasOwnProperty(tbIndex)) {
            var table = reportForm.model.Tables[tbIndex];
            initColumns(table.Columns);
        }
    }
    initUi();
};
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

function initUi() {

    //模板拼接
    var searchColumns = {};
    searchColumns.items = [];

    //画查询区域
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
            var colType = 'string';
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
            switch (colType) {
                case "string":
                    {
                        if (searchCol.Items && searchCol.Items.length > 0) {
                            searchColumns.items.push({
                                "type": "multiselect",
                                "contentLabel": "index"
                            });
                        }
                    }
                    break;
                case "int":
                    {
                        if (searchCol.Items && searchCol.Items.length > 0) {
                            searchColumns.items.push({
                                "type": "multiselect",
                                "contentLabel": "index"
                            });
                        }
                    }
                    break;
                case "bool":
                    {
                        searchColumns.items.push({
                            "type": "multiselect",
                            "contentLabel": "index"
                        });
                    }
                    break;
                case "decimal":
                    searchColumns.items.push({
                        "type": "text",
                        "contentLabel": "index",
                        "addclass": "myclass"
                    });
                    break;
                case "date":
                    searchColumns.items.push({
                        "type": "time",
                        "contentid": "datepicker",
                        "contentLabel": "index"
                    });
                    break;
                default:
            }
        }
    }
    $("#searchArea").html($.render.tmplSearchArea(searchColumns));
    $("#datepicker").datepicker({
        language: "zh-CN"
    });
    $('.control-multiselect').multiselect();

    $.jgrid.defaults.styleUI = 'Bootstrap'; 
    pageInit();
    $(".container-fluid").css("height", function () {
        return $(window).height() - $(this).offset().top;
    });
    $(".container-fluid").setflexbox($(".nav.nav-tabs,.nav-tabs-body,.panel,.table-overscroll"));
    
}

//模板拼接
//加载jqgrid start 
function pageInit() {
    $("#dataGrid").jqGrid({
        datatype: "local",
        autowidth: true,
        colNames: tableHeadList,
        colModel: tableHeadBind,
        rowNum: 10,
        regional: 'cn',
        pager: '#gridPager',
        page: 1
    });
    for (var i = 0; i <= mydata.length; i++) {
        jQuery("#dataGrid").jqGrid('addRowData', i + 1, mydata[i]);
    }
    $("#dataGrid").jqGrid('bindKeys');
};