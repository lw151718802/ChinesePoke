<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member_Show.aspx.cs" Inherits="RM.Web.User.template.member.Member_Show" %>

<!DOCTYPE HTML>
<html>
<head>
   <!--#include file="../_meta.html"-->
<![endif]--><title>用户查看</title>
</head>
<body>
<div class="cl pd-20" style=" background-color:#5bacb6">
 
  <dl style="margin-left:80px; color:#fff">
    <dt><span class="f-18" id="RealName"></span> <span class="pl-10 f-12" id="RegMoney"></span></dt>
  
  </dl>
</div>
<div class="pd-20">
  <table class="table">
    <tbody>
      <tr>
        <th class="text-r" width="80">账号：</th>
        <td id="Account"></td>
      </tr>
      <tr>
        <th class="text-r">手机：</th>
        <td id="Phone"></td>
      </tr>
      <tr>
        <th class="text-r">推荐人：</th>
        <td id="RecMan"></td>
      </tr>
      <tr>
        <th class="text-r">注册时间：</th>
        <td id="RegDate"></td>
      </tr>
      <tr>
        <th class="text-r">激活状态：</th>
        <td id="ISActive">2014.12.20</td>
      </tr>
    </tbody>
  </table>
</div>
    <!--_footer 作为公共模版分离出去-->
  <!--#include file="../_footer.html"-->
    <!--/_footer /作为公共模版分离出去-->


    <script>

        $(function () {

            var v = GetQueryString("v");

            ajaxUserInfo(v, bind);



        });


        function bind(a) {

            if (a.res_code == 1) {
                
                $("#RegMoney").text("注册资金："+a.RegMoney+"万元");
                $("#RealName").text(a.RealName);
                $("#Account").text(a.Account);
                $("#Phone").text(a.Phone);
                $("#RecMan").text(a.RecMan);
                $("#RegDate").text(a.RegDate);
                if (a.ISActive == 1) {
                    $("#ISActive").text("已激活");
                } else {
                    $("#ISActive").text("未激活");
                }
                
            } else {
                layer.msg("网络异常！", { icon: 5 });
            }

        }

    </script>
</body>
</html>
