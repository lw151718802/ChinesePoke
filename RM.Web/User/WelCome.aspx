<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelCome.aspx.cs" Inherits="RM.Web.User.WelCome" %>

<!DOCTYPE HTML>
<html>
<head>
<meta charset="utf-8">
<meta name="renderer" content="webkit|ie-comp|ie-stand">
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
<meta http-equiv="Cache-Control" content="no-siteapp" />
<!--[if lt IE 9]>
<script type="text/javascript" src="lib/html5.js"></script>
<script type="text/javascript" src="lib/respond.min.js"></script>
<script type="text/javascript" src="lib/PIE_IE678.js"></script>
<![endif]-->
<link rel="stylesheet" type="text/css" href="static/h-ui/css/H-ui.min.css" />
<link rel="stylesheet" type="text/css" href="static/h-ui.admin/css/H-ui.admin.css" />
<link rel="stylesheet" type="text/css" href="lib/Hui-iconfont/1.0.7/iconfont.css" />
<link rel="stylesheet" type="text/css" href="lib/icheck/icheck.css" />
<link rel="stylesheet" type="text/css" href="static/h-ui.admin/skin/default/skin.css" id="skin" />
<link rel="stylesheet" type="text/css" href="static/h-ui.admin/css/style.css" />
<!--[if IE 6]>
<script type="text/javascript" src="lib/DD_belatedPNG_0.0.8a-min.js" ></script>
<script>DD_belatedPNG.fix('*');</script>
<![endif]-->
<title>我的桌面</title>
</head>
<body>
    <nav class="breadcrumb"><i class="Hui-iconfont">&#xe67f;</i> 首页 <span class="c-gray en">&gt;</span> 欢迎页 <span class="c-gray en"></span> <a class="btn btn-success radius r" style="line-height:1.6em;margin-top:3px" href="javascript:location.replace(location.href);" title="刷新"><i class="Hui-iconfont">&#xe68f;</i></a></nav>
<div class="page-container">

	</div>
<footer class="footer mt-20">
	
</footer>
    <script type="text/javascript" src="/User/lib/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" src="/User/lib/layer/2.1/layer.js"></script>
    <script type="text/javascript" src="/User/lib/icheck/jquery.icheck.min.js"></script>
    <script type="text/javascript" src="/User/lib/jquery.validation/1.14.0/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/User/lib/jquery.validation/1.14.0/validate-methods.js"></script>
    <script type="text/javascript" src="/User/lib/jquery.validation/1.14.0/messages_zh.min.js"></script>
    <script type="text/javascript" src="/User/static/h-ui/js/H-ui.js"></script>
    <script type="text/javascript" src="/User/static/h-ui.admin/js/H-ui.admin.js"></script> 
<script src="/User/js/common/Common.js" type="text/javascript"></script>
<script src="/User/js/common/common_ajaxfunction_main.js" type="text/javascript"></script>

    <script>
        function loadhtml() {
            $(".page-container").load("welcome.html", function () {
                init();
            });
        }
        function init() {

            loadInfo();
        }

       function loadInfo() {
            ajaxWelcomeStat(bindInfo);
        }
        function bindInfo(a) {

            var relname = a.relname;
            $("#welname").text("欢迎  " + relname)
            


            var tableStr = "";
            $.each(a.t1, function (i, v) {
                tableStr += "<tr lass=\"text-c\">";
                tableStr += "<td>" + v.Qtype + "</td>";
                tableStr += "<td>￥" + moneyIntFormat(v.S_Money) + "</td>";
                tableStr += "<td>￥" + moneyIntFormat(v.CZ) + "</td>";
                tableStr += "<td>￥" + moneyIntFormat(v.GDSY) + "</td>";
                tableStr += "<td>￥" + moneyIntFormat(v.FDFH) + "</td>";
                tableStr += "<td>￥" + moneyIntFormat(v.YYFH) + "</td>";
                tableStr += "<td>￥" + moneyIntFormat(v.XSJL) + "</td>";
                tableStr += "<td>￥" + moneyIntFormat(v.GLJL) + "</td>";
                tableStr += "<td>￥" + moneyIntFormat(v.FWJL) + "</td>";
                tableStr += "<td>￥" + moneyIntFormat(v.FLFH) + "</td>";
                tableStr += "<td>￥" + moneyIntFormat(v.ZJ) + "</td>";
               
                tableStr += "</tr>";

            });
           
            $('#t1').html(tableStr);

             tableStr = "";
            $.each(a.t2, function (i, v) {
                tableStr += "<tr lass=\"text-c\">";
                tableStr += "<td>" + v.Qtype + "</td>";
                tableStr += "<td>￥" + moneyIntFormat(v.S_Money) + "</td>";
                tableStr += "<td>￥" + moneyIntFormat(v.TIXIAN) + "</td>";
                tableStr += "<td>￥" + moneyIntFormat(v.ZC) + "</td>";
                tableStr += "<td>￥" + moneyIntFormat(v.ZCZH) + "</td>";
               
                tableStr += "</tr>";

            });
            $('#t2').html(tableStr);


          

            tableStr = "";
            $.each(a.t3, function (i, v) {
                tableStr += "<tr lass=\"text-c\">";
                tableStr += "<td>" + v.Qtype + "</td>";
               tableStr += "<td>￥" + moneyIntFormat(v.ZXYJ) + "</td>";
                tableStr += "<td>￥" + moneyIntFormat(v.PXYJ) + "</td>";
                tableStr += "<td>￥" + moneyIntFormat(v.DYYJ) + "</td>";
                tableStr += "<td>￥" + moneyIntFormat(v.DEYJ) + "</td>";
                tableStr += "<td>￥" + moneyIntFormat(v.DSYJ) + "</td>";
                tableStr += "</tr>";

            });
            $('#t3').html(tableStr);


  
            if (a.lgininfo.length >= 1) {
                var objlgininfo = a.lgininfo[0];

                var htmls = "";
                htmls += "  <p >登录次数：" + objlgininfo.logincount + " </p>"
                htmls += "  <p >上次登录IP：" + objlgininfo.SYS_LOGINLOG_IP + " 登录地址:" + objlgininfo.OWNER_address + "登录时间:" + formatDate_S(new Date(objlgininfo.SYS_LOGINLOG_TIME))+"</p>";
              
                $("#welname").after(htmls);
            }
        }

    </script>
</body>
</html>