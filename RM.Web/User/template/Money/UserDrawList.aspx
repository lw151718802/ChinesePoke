<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDrawList.aspx.cs" Inherits="RM.Web.User.template.Money.UserDrawList" %>
<!DOCTYPE HTML>
<html>
<head>
   <!--#include file="../_meta.html"-->

    <link href="/User/lib/page.css" rel="stylesheet" />
<title>推荐用户管理</title>
</head>
<body>
<nav class="breadcrumb"><i class="Hui-iconfont">&#xe67f;</i> 首页 <span class="c-gray en">&gt;</span> 资金管理 <span class="c-gray en">&gt;</span> 提现账目 <a class="btn btn-success radius r" style="line-height:1.6em;margin-top:3px" href="javascript:location.replace(location.href);" title="刷新" ><i class="Hui-iconfont">&#xe68f;</i></a></nav>
<div class="page-container">
	
	
  
</div>
      <div class="row cl">
             <div id="pager"></div>
            </div>
  <!--#include file="../_footer.html"-->

     <script type="text/javascript" src="/user/lib/js-extend.js"></script>
	<script type="text/javascript" src="/user/lib/jquery-ajax-pager.js"></script>
<script type="text/javascript">

    $(function () {

      
       
    })
    

    function loadhtml()
    {
        $(".page-container").load("html/UserDrawList.html", function () {
            init();
        });
    }
    function init() {
        divresize(160);
        //FixedTableHeader("#table1", $(window).height() - 151);

        $('#pager').sjAjaxPager({
            url: "/User/Ajax/UserDrawPage.ashx",

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
                $.each(data.items, function (i, v) {
                    tableStr += "<tr lass=\"text-c\">";
                    tableStr += "<td>" + v.REALNAME + "</td>";
                    tableStr += "<td>" + v.BANKNAME + "</td>";
                    tableStr += "<td>" + v.BANDCARDNO + "</td>";
                    tableStr += "<td>￥" + moneyIntFormat(v.DRAWSUMMONEY) + "</td>";
                    tableStr += "<td>￥" + moneyIntFormat(v.DRAWREALMONEY) + "</td>";
                    tableStr += "<td id='statu'>" + v.DRAWSTATUSDESC + "</td>";
                    tableStr += "<td>" + formatDate_S(new Date(v.DRAWTIME)) + "</td>";
                    tableStr += "<td id='overtime'>" + formatDate_S(new Date(v.DRAWOVERTIME)) + "</td>";

                    tableStr += "<td class=\"td-manage\">";
                    if (v.DRAWSTATUS == 0) {
                        tableStr += "<a style=\"text-decoration:none\" onClick=\"draw_stop(this,'" + v.ID + "')\" href=\"javascript:;\" title=\"撤销\"><i class=\"Hui-iconfont\">&#xe6de;</i>";
                    }
                    tableStr += "</td>";
                    tableStr += "</tr>";

                });

                $('#dataTable').html(tableStr);
            },
            complete: function () {
            }
        });
    }

    function draw_stop(o,id)
    {
        layer.confirm('确认要撤销该提现吗？', function (index) {
            layer.load(1, { shade: [0.8, '#393D49'] })
            ajaxBackUserDraw(id, o, bindAddDraw);

        });

      
    }

    function bindAddDraw(a, obj)
    {
        layer.closeAll('loading');
        if (a.res_code == 1) {
            //$("#recman").after("<p>姓名：" + a.RealName + "</p>");
            
            $(obj).parents("tr").find("#statu").text("撤销");
            $(obj).parents("tr").find("#overtime").text(a.ctime);
            $(obj).parents("tr").find(".td-manage").html('');
            
            $(obj).remove();
            layer.msg('撤销成功!', { icon: 6, time: 3000 });
        } else {
            layer.msg(a.res_msg, { icon: 5 });

        }
    
    }
</script> 
</body>
</html>