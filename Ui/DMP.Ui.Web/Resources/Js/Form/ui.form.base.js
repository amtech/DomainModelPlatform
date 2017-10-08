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
                doInitUi(); 
                $('[rel-type="timecontent"]').datepicker({
                    language: "zh-CN"
                });
                $('.control-multiselect').multiselect(); 
            },
            error: function (xhr) {
                alert("失败！");
            }
        });
    };
}


$(document).ready(function () {
    onReady();
    $(window).on("resize", function () {
        $(".container-fluid").css("height", function () {
            return $(window).height() - $(this).offset().top - 5;
        });
    });
});

/**
* virtual 时机点-获取模型后
* @param {} result 
* @returns {} 
*/
function afterGetModelInfo(result) {
    alert(result);
};

/**
* virtual 时机点-初始化ui
* @param {} result 
* @returns {} 
*/
function doInitUi() {
    alert(result);
};

/**
* virtual 时机点-页面加载就绪
* @returns {} 
*/
function onReady() {
    alert('ready!');
};

