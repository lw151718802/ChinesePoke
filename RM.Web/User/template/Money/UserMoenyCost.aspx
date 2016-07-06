<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserMoenyCost.aspx.cs" Inherits="RM.Web.User.template.Money.UserMoenyCost" %>

<!DOCTYPE HTML>
<html>
<head>
   <!--#include file="../_meta.html"-->

    <link href="/User/lib/page.css" rel="stylesheet" />
<title>支出明细</title>
</head>
<body>
<nav class="breadcrumb"><i class="Hui-iconfont">&#xe67f;</i> 首页 <span class="c-gray en">&gt;</span> 资金管理 <span class="c-gray en">&gt;</span> 支出明细 <a class="btn btn-success radius r" style="line-height:1.6em;margin-top:3px" href="javascript:location.replace(location.href);" title="刷新" ><i class="Hui-iconfont">&#xe68f;</i></a></nav>
<div class="page-container">

	
  
</div>
      <div class="row cl">
             <div id="pager"></div>
            </div>
  <!--#include file="../_footer.html"-->

     <script type="text/javascript" src="/user/lib/js-extend.js"></script>
	<script type="text/javascript" src="/user/lib/jquery-ajax-pager.js"></script>
<script type="text/javascript">
    function loadhtml()
    {
        $(".page-container").load("html/UserMoenyCost.html", function () {
            init();
        });
    }
    function init() {

        divresize(160);
        //FixedTableHeader("#table1", $(window).height() - 151);

        $('#pager').sjAjaxPager({
            url: "/User/Ajax/ZS_UserMoneyFlow.ashx",

            pageSize: 10,
            searchParam: {
                /*
                * 如果有其他的查询条件，直接在这里传入即可
                */
                t: 200,
                name: 'test'
            },
            beforeSend: function () {
            },
            preText: "上一页",
            nextText: "下一页",
            firstText: "首页",
            lastText: "尾页",
            success: function (data) {
                /*
                *返回的数据根据自己需要处理
                */

                var tableStr = "";
                $.each(data.items, function (i, v) {
                    tableStr += "<tr lass=\"text-c\">";
                    tableStr += "<td>￥" + moneyIntFormat(-v.U_MONEY) + "</td>";
                    tableStr += "<td>" + v.TYPEDESC + "</td>";
                    tableStr += "<td>" + v.MONEYDESC + "</td>";
                    tableStr += "<td>" + formatDate_S(new Date(v.CREATETIME)) + "</td>";

                    tableStr += "</tr>";

                });

                $('#dataTable').html(tableStr);
            },
            complete: function () {
            }
        });
    }
    $(function () {

       
    })



</script> 
</body>
</html>