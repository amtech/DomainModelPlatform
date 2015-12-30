/*该js用于实现form的基类功能*/

$(document).ready(function () {

    var baseForm = new BaseForm();
    baseForm.getModelInfo();

});

function BaseForm() {
    //添加方法
    this.getModelInfo = function () {
        $.ajax({
            url: "?action=get_model",
            data: "{type:'DoOpenClickStart',id:'1001'}",
            type: 'post',
            dataType: 'json',
            contentType: 'application/json; charset=utf8',
            success: function (result) {
                alert(result);
            },
            error: function (xhr) {
                alert("失败！");
            }
        });
    }  
}


