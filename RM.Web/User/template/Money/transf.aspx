\<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transf.aspx.cs" Inherits="RM.Web.User.template.Money.transf" %>


<!DOCTYPE html>

<!--_meta 作为公共模版分离出去-->
<!DOCTYPE HTML>
<html>
<head>
   <!--#include file="../_meta.html"-->
   <title>转账</title>
</head>
<body>
         <nav class="breadcrumb"><i class="Hui-iconfont">&#xe67f;</i> 首页 <span class="c-gray en">&gt;</span> 资金管理 <span class="c-gray en">&gt;</span> 转账 <a class="btn btn-success radius r" style="line-height:1.6em;margin-top:3px" href="javascript:location.replace(location.href);" title="刷新" ><i class="Hui-iconfont">&#xe68f;</i></a></nav>

      <input type="hidden" id="hidremoeny" />
    <div class="page-container">
      
    </div>
    <!--_footer 作为公共模版分离出去-->
  <!--#include file="../_footer.html"-->
    <!--/_footer /作为公共模版分离出去-->
    

    <script type="text/javascript">
$(function(){
   
	
});




function loadhtml() {
    $(".page-container").load("html/transf.html", function () {
        init();
    });
}
function init()
{
    $("#rel").hide();
    ajaxUserMoneyInfo(bindMoney);

    $("#tomoney").blur(function () {


        var tomoney = $("#tomoney").val();
        if (!isNumberBy100(tomoney)) {
            layer.tips('转账金额必须是100的整数倍', $("#tomoney"));
            $("#tomoney").focus();
            return;
        }
        var remoeny = $("#hidremoeny").val() - tomoney;

        if (remoeny < 0) {
            layer.tips('可转账金额不足', $("#tomoney"));
            $("#tomoney").focus();
            return;
        }



    });

    $("#recaccount").blur(function () {

        var recman = $("#recaccount").val();

        if (recman == $("#Account").val()) {
            layer.msg("不能对本账号转账！", { icon: 5 });
            return;
        }

        ajaxcheckaccount(recman, bindName);

    });

}

function bindName(a) {

    if (a.res_code == 1) {
        $("#relname").val(a.RealName);
        $("#rel").show();
    } else {
        $("#rel").hide();
        $("#relname").val('');
        layer.msg(a.res_msg, { icon: 5 });

    }

}

function bindMoney(a) {
   
    $("#rel").hide();
    $("#relname").val('');
    $("#hidremoeny").val('');
    $("#Account").val('');
    $("#remoeny").val('');
    $("#tomoney").val('');
    $("#recaccount").val('');
    $("#loginpwd").val('');
    if (a.res_code == 1) {

        $("#Account").val(a.Account);
        $("#hidremoeny").val(a.UserMoney);
        $("#remoeny").val('￥' + moneyIntFormat(a.UserMoney));
       

    } else {
        layer.msg("网络异常！", { icon: 5 });
    }

}

function submittransf() {

    var loginpwd = $("#loginpwd").val();
    var recaccount = $("#recaccount").val();
    var tomoney = $("#tomoney").val();
  


    if (!isNumberBy100(tomoney)) {
        layer.tips('转账金额必须是100的整数倍', $("#tomoney"));
        $("#tomoney").focus();
        return false;
    }
    var remoeny = $("#hidremoeny").val() - tomoney;

    if (remoeny < 0) {
        layer.tips('可转账金额不足', $("#tomoney"));
        $("#tomoney").focus();
        return false;
    }




    if (!CheckDataValid('#form-trans-add')) {
        return false;
    }

    layer.confirm('确认要向' + recaccount + '转入'+tomoney+'？', function (index) {
        layer.load(1, { shade: [0.8, '#393D49'] })
        ajaxAddTrans(loginpwd, recaccount, tomoney, bindAddTran);

    });

   
}

function bindAddTran(a) {
    layer.closeAll('loading');
    if (a.res_code == 1) {
        ajaxUserMoneyInfo(bindMoney);
        layer.msg('转账成功!', { icon: 6, time: 3000 });
    } else {
        layer.msg(a.res_msg, { icon: 5 });

    }

}



</script> 


</body>
</html>