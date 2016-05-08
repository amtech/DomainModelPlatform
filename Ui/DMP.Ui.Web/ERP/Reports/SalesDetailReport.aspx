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
            <div id="searchArea" class="panel-body panel-body-condensebottom">
            </div>
        </div>
        <div class="flexbox-index ui-jqgrid-nomargin" rel-flow="1" rel-min-height="200">
            <table id="dataGrid" class="table table-condensed table-bordered table-striped table-hover">
            </table>
            <div id="gridPager">
            </div>
        </div>
    </div>
</body>
</html>
