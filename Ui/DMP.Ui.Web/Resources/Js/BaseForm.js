$(document).ready(function () { 

    $.ajax({
        url: "?action=get_model",
        data: "{type:'DoOpenClickStart',id:'1001'}",
        type: 'post',
        dataType: 'json',
        contentType: 'application/json; charset=utf8',
        success: function (data) {
            alert("ID=" + data.ID + ";Type=" + data.Type);
        },
        error: function (xhr) {
            alert("失败！");
        }
    });

});