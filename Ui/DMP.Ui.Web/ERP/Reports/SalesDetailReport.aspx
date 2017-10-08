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
        <li id="title">客户回款率</li>
    </ul>
    <div class="container-fluid">
        <div class="panel panel-suspend panel-condensed">
            <div id="whereConditionArea" class="panel-body panel-body-condensebottom">
                <form id="jsrender-head" class="form-fixwidth" action="">
                </form>
            </div>
        </div>
        <div class="panel panel-suspend panel-condensed" style="text-align: right;">
            <button>查询</button>
        </div>
        <div class="flexbox-index ui-jqgrid-nomargin" rel-flow="1" rel-min-height="200">
            <table id="fixtable" class="table table-condensed table-striped table-hover">
            </table>
            <div id="jqGridPager">
            </div>
        </div>
    </div>
</body>
</html>
