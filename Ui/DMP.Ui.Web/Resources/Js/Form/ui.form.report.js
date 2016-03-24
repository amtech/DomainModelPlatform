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
    initUi();
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
    //画查询区域
    for (var searchColIndex in reportForm.searchColumns) {
        if (columns.hasOwnProperty(searchColIndex)) {
            var searchCol = reportForm.searchColumns[searchColIndex];
            //如果是下拉选项 
            switch (searchCol.ColumnType) {
                case "String":
                    {
                        if (searchCol.Items && searchCol.Items.length > 0) {

                        } 
                    }
                    break;
                case "Int":
                    {
                        if (searchCol.Items && searchCol.Items.length > 0) {

                        } 
                    }
                    break;
                case "Bool":
                    {
                        
                    }
                    break;
                case "Decimal":
                    break;
                case "Date":
                    break;
                default:
            } 
        }
    }
}