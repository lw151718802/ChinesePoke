<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member_List.aspx.cs" Inherits="RM.Web.User.template.member.Member_List" %>
<!DOCTYPE HTML>
<html>
<head>
   <!--#include file="../_meta.html"-->

    <link href="/User/lib/page.css" rel="stylesheet" />
<title>推荐用户管理</title>
</head>
<body>
<nav class="breadcrumb"><i class="Hui-iconfont">&#xe67f;</i> 首页 <span class="c-gray en">&gt;</span> 会员管理 <span class="c-gray en">&gt;</span> 推荐用户管理 <a class="btn btn-success radius r" style="line-height:1.6em;margin-top:3px" href="javascript:location.replace(location.href);" title="刷新" ><i class="Hui-iconfont">&#xe68f;</i></a></nav>
<div class="page-container">



</div>
     
  <!--#include file="../_footer.html"-->

<script type="text/javascript" src="/user/lib/js-extend.js"></script>
<script type="text/javascript" src="/user/lib/jquery-ajax-pager.js"></script>
<script type="text/javascript">


    $(function () {
      
    })
    function loadhtml() {
        $(".page-container").load("html/Member_List.html", function () {
            init();
        });
    }
   

    function init()
    {
        divresize(120);
        //FixedTableHeader("#table1", $(window).height() - 151);

        $('#pager').sjAjaxPager({
            url: "/User/Ajax/GetUserPage.ashx",

            pageSize: 10,
            searchParam: {
                /*
                * 如果有其他的查询条件，直接在这里传入即可
                */
                id: 1,
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
                var s = '';
                $.each(data.items, function (i, v) {
                    tableStr += "<tr lass=\"text-c\">";
                    tableStr += "<td>" + v.ACCOUNT + "</td>";
                    tableStr += "<td>" + v.REALNAME + "</td>";
                    tableStr += "<td>" + v.PHONE + "</td>";
                    tableStr += "<td>￥" + moneyIntFormat(v.REGMONEY) + "</td>";
                    tableStr += "<td>￥" + moneyIntFormat(v.ZXYJ) + "</td>";
                    tableStr += "<td>￥" + moneyIntFormat(v.PXYJ) + "</td>";
                    tableStr += "<td>￥" + moneyIntFormat(v.PERYJ) + "</td>";
                    tableStr += "<td>￥" + moneyIntFormat(v.CURYJ) + "</td>";
                    if (v.ISACTIVE == 1) {
                        tableStr += "<td>激活</td>";
                    } else {
                        tableStr += "<td>未激活</td>";
                    }

                    tableStr += "<td>" + formatDate_S(new Date(v.REGDATE)) + "</td>";
                    tableStr += "<td>" + formatDate_S(new Date(v.UPDATETIME)) + "</td>";
                    tableStr += "</tr>";
                    s = v.REGDATE;

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