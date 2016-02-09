/*
    该js用于实现报表form的基类功能继承于BaseForm
*/

function ReportForm() {
    BaseForm.call(this);
}
ReportForm.prototype = new BaseForm();

$(document).ready(function () {

    var form = new ReportForm();
    form.getModelInfo();

});