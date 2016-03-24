/*该js为form的基类*/
function BaseForm() {
    this.model = null;
    this.searchColumns = null;
    //添加方法
    this.getModelInfo = function () { 
        $.ajax({
            url: "?action=get_model",
            data: "{type:'DoOpenClickStart',id:'1001'}",
            type: 'post',
            dataType: 'json',
            contentType: 'application/json; charset=utf8',
            success: function (result) {
                afterGetModelInfo(result);
            },
            error: function (xhr) {
                alert("失败！");
            }
        });
    };
} 

function afterGetModelInfo(result) {
    alert(result);
};


