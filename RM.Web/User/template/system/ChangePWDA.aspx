<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePWDA.aspx.cs" Inherits="RM.Web.User.template.system.ChangePWDA" %>


<!DOCTYPE html>

<!--_meta 作为公共模版分离出去-->
<!DOCTYPE HTML>
<html>
<head>
   <!--#include file="../_meta.html"-->
   <title>修改登录密码</title>
</head>
<body>

  <nav class="breadcrumb"><i class="Hui-iconfont">&#xe67f;</i> 首页 <span class="c-gray en">&gt;</span> 系统管理 <span class="c-gray en">&gt;</span> 修改登录密码 <a class="btn btn-success radius r" style="line-height:1.6em;margin-top:3px" href="javascript:location.replace(location.href);" title="刷新" ><i class="Hui-iconfont">&#xe68f;</i></a></nav>
    <div class="page-container">
      
    </div>
    <!--_footer 作为公共模版分离出去-->
  <!--#include file="../_footer.html"-->
    <!--/_footer /作为公共模版分离出去-->
    

    <script type="text/javascript">

function loadhtml() {
    $(".page-container").load("html/ChangePWDA.html", function () {
        init();
    });
}
function init() {
   
}

function loadInfo()
{
    ajaxUserDrawInfo(bindDrawMoney);
}
function bindDrawMoney(a) {
   
    if (a.res_code == 1) {
        
        $("#hidremoeny").val(a.Money);
        $("#Account").val(a.Account);
        $("#remoeny").val('￥'+moneyIntFormat(a.Money));
        $("#RealName").val(a.RealName);
        $("#BankName").val(a.BankName);
        $("#BandAddress").val(a.BankAddress);
        $("#BandCardNO").val(a.BankCardNO);
        $("#rate").val(a.Rate);
        $("#DrawFeeMoney").val('');
        $("#DrawRealMoney").val('');
        $("#DrawSumMoney").val('');
        $("#loginpwd").val('');
       

    } else {
        layer.msg("网络异常！", { icon: 5 });
    }

}

function submitModify()
{
    
    var pwda = $("#pwda").val();
    var pwdb = $("#pwdb").val();
    var pwdc = $("#pwdc").val();
  
    if (pwdb != pwdc)
    {
        layer.tips('两次密码输入不一致', $("#pwdb"));
        $("#pwdb").focus();
        return false;
    }

    if (!CheckDataValid('#form-pwd-modify')) {
        return false;
    }

    layer.confirm('确认修改登录密码 ，成功后需要重新登录？', function (index) {
        layer.load(1, { shade: [0.8, '#393D49'] })
        ajaxModify('pwda', pwda, pwdb, pwdc, bindModify);

    });

   
}

function bindModify(a)
{
    layer.closeAll('loading');
   
    if (a.res_code == 1) {
        clear();
        //setInterval(Load, 3000);
        parent.document.location.href = '/User/login.html';
       // layer.msg('登录密码修改成功，请重新登录', { icon: 6, time: 3000 });
       
       
    } else {
        layer.msg(a.res_msg, { icon: 5 });

    }
    
}

function load()
{
    parent.document.location.href = '/User/login.html';
    return false;
}

function clear()
{
    $("#pwda").val('');
    $("#pwda").val('');
    $("#pwda").val('');
}



</script> 


</body>
</html>