<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesDetailReport.aspx.cs"
    Inherits="DMP.Ui.Web.ERP.Reports.SalesDetailReport" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Document</title>
</head>
<body>
    <ul class="banner-head">
        <li>客户回款率</li>
    </ul>
    <div class="container-fluid">
        <div class="panel panel-suspend panel-condensed">
            <div id="jsrender-head" class="panel-body panel-body-condensebottom">
            </div>
        </div>
        <div class="flexbox-index ui-jqgrid-nomargin" rel-flow="1" rel-min-height="200">
            <table id="fixtable" class="table table-condensed table-bordered table-striped table-hover"></table>
            <div id="jqGridPager"></div>
        </div>
    </div>
    <!-- 模板区 -->
    <script id="jsrender-head-model" type="text/x-jsrender">
        <div class="form-fixwidth">
            {{for items}}
            {{if type=="input"}}
            {{include tmpl="#jsrender-boostrap-form-content"/}}
            {{else type=="time"}}
            {{include tmpl="#jsrender-boostrap-form-content-time"/}}
            {{else type=="multiselect"}}
            {{include tmpl="#jsrender-boostrap-form-content-multiselect"/}}
            {{/if}}
            {{/for}}
        </div>
    </script>
    <script id="jsrender-boostrap-form-content" type="text/x-jsrender">
        <div class="form-group-sm col-xs-12 col-sm-4 col-lg-3 col-ie7-4">
            <label class="control-label" for="">{{: contentLabel}}</label>
            <div class="form-control-content">
                <input type="text" class="form-control-simplified {{: addclass}}" />
            </div>
        </div>
    </script>
    <script id="jsrender-boostrap-form-content-time" type="text/x-jsrender">
        <div class="form-group-sm col-xs-12 col-sm-4 col-lg-3 col-ie7-4 hidden-ie7">
            <label class="control-label" for="">{{: contentLabel}}</label>
            <div class="form-control-content">
                <div class="input-daterange input-trio" id="{{: contentid}}">
                    <span class="input-trio-btn pull-left">
                        <input type="text" class="form-control" name="start" />
                    </span>
                    <span class="input-trio-btn pull-right">
                        <input type="text" class="form-control" name="end" />
                    </span>
                    <span class="input-trio-addon input-trio-body">to</span>
                </div>
            </div>
        </div>
    </script>
    <script id="jsrender-boostrap-form-content-multiselect" type="text/x-jsrender">
        <div class="form-group-sm col-xs-12 col-sm-4 col-lg-3 col-ie7-4 hidden-ie7">
            <label class="control-label" for="">{{: contentLabel}}</label>
            <div class="form-control-content">
                <select class="control-multiselect form-control" multiple="multiple">
                    <option value="1">Option 1</option>
                    <option value="2">Option 2</option>
                    <option value="3">Option 3</option>
                    <option value="4">Option 4</option>
                    <option value="5">Option 5</option>
                    <option value="6">Option 6</option>
                </select>
            </div>
        </div>
    </script>
    <!-- 数据区 -->

    <script type="text/javascript">
        //模板拼接
        var headindex = [{
            "items": [{
                "type": "input",
                "contentLabel": "index",
                "addclass": "myclass"
            }, {
                "type": "time",
                "contentid": "datepicker",
                "contentLabel": "index"
            }, {
                "type": "multiselect",
                "contentLabel": "index"
            }, {
                "type": "multiselect",
                "contentLabel": "index"
            }, {
                "type": "multiselect",
                "contentLabel": "index"
            }]
        }];
        //模板拼接
        //加载jqgrid start 
        function pageInit() {
            $("#fixtable").jqGrid({
                datatype: "local",
                autowidth: true,
                colNames: tableHeadList,
                colModel: tableHeadBind,
                rowNum: 10,
                regional: 'cn',
                pager: '#jqGridPager',
                page: 1
            });
            for (var i = 0; i <= mydata.length; i++) {
                jQuery("#fixtable").jqGrid('addRowData', i + 1, mydata[i]);
            }
            $("#fixtable").jqGrid('bindKeys');
        };
        //加载jqgrid end
        $(function () {

            $.jgrid.defaults.styleUI = 'Bootstrap';
            $("#jsrender-head").html($.templates("#jsrender-head-model").render(headindex));
            pageInit();
            $(".container-fluid").css("height", function () {
                return $(window).height() - $(this).offset().top;
            });
            $(window).on("resize", function () {
                $(".container-fluid").css("height", function () {
                    return $(window).height() - $(this).offset().top - 5;
                });
            });
            /*
            $(window).on("resize", function () {
                var gridheight = $("#fixtable").parents(".flexbox-index").height() - $(".ui-jqgrid-bdiv").position().top - $(".ui-jqgrid-pager").height() - 20;
                $("#fixtable").jqGrid('setGridHeight', gridheight);
                $("#fixtable").jqGrid('setGridWidth', $("#fixtable").parents(".container-fluid").width());
            });
            */
            $(".container-fluid").setflexbox($(".nav.nav-tabs,.nav-tabs-body,.panel,.table-overscroll"));
            $("#datepicker").datepicker({
                language: "zh-CN"
            });
            $(window).trigger('resize');
            $('.control-multiselect').multiselect();
        });
    </script>
</body>
</html>
