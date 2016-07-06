<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Draw.aspx.cs" Inherits="RM.Web.User.template.Money.Draw" %>

<!DOCTYPE html>

<!--_meta 作为公共模版分离出去-->
<!DOCTYPE HTML>
<html>
<head>
   <!--#include file="../_meta.html"-->
   <title>转账</title>
</head>
<body>
     <nav class="breadcrumb"><i class="Hui-iconfont">&#xe67f;</i> 首页 <span class="c-gray en">&gt;</span> 资金管理 <span class="c-gray en">&gt;</span> 提现 <a class="btn btn-success radius r" style="line-height:1.6em;margin-top:3px" href="javascript:location.replace(location.href);" title="刷新" ><i class="Hui-iconfont">&#xe68f;</i></a></nav>
    <input type="hidden" id="rate" />
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
    $(".page-container").load("html/Draw.html", function () {
        init();
    });
}
function init()
{
    loadInfo();
    $("#BandCardNO").keydown(function (e) {
        if (!isNaN(this.value.replace(/[ ]/g, ""))) {
            this.value = this.value.replace(/\s/g, '').replace(/(\d{4})(?=\d)/g, "$1 ");//四位数字一组，以空格分割
        } else {
            if (e.keyCode == 8) {//当输入非法字符时，禁止除退格键以外的按键输入
                return true;
            } else {
                return false
            }
        }
    });
    $("#DrawSumMoney").blur(function () {


        var rate = $("#rate").val();
        var DrawSumMoney = $("#DrawSumMoney").val();
        if (!isNumberBy100(DrawSumMoney)) {
            layer.tips('提现金额必须是100的整数倍', $("#DrawSumMoney"));
            $("#DrawSumMoney").focus();
            return;
        }
        var remoeny = $("#hidremoeny").val() - DrawSumMoney;

        if (remoeny < 0) {
            layer.tips('可提现金额不足', $("#DrawSumMoney"));
            $("#DrawSumMoney").focus();
            return;
        }


        var DrawFeeMoney = DrawSumMoney * rate;
        //$("#DrawFeeMoney").val(DrawFeeMoney);
        var DrawRealMoney = DrawSumMoney - DrawFeeMoney;
        $("#DrawRealMoney").val(DrawRealMoney);

    });
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

         $("#DrawSumMoney").attr("placeholder", "请输入提现金额（只能是100的整数倍，手续费" + a.Rate*100+"%)");
       
       

    } else {
        layer.msg("网络异常！", { icon: 5 });
    }

}

function submitdraw()
{
    
    var loginpwd = $("#loginpwd").val();
    var RealName = $("#RealName").val();
    var DrawSumMoney = $("#DrawSumMoney").val();
    var bankname = $("#BankName").val();
    var bankaddress = $("#BandAddress").val();
    var bankcardno = $("#BandCardNO").val();
 

    if (!isNumberBy100(DrawSumMoney)) {
        layer.tips('提现金额必须是100的整数倍', $("#DrawSumMoney"));
        $("#DrawSumMoney").focus();
        return false;
    }
    var remoeny = $("#hidremoeny").val() - DrawSumMoney;

    if (remoeny < 0) {
        layer.tips('可提现金额不足', $("#DrawSumMoney"));
        $("#DrawSumMoney").focus();
        return false;
    }




    if (!CheckDataValid('#form-member-add')) {
        return false;
    }

    layer.confirm('确认要提现' + DrawSumMoney + ' ？', function (index) {
        layer.load(1, { shade: [0.8, '#393D49'] })
        ajaxAddDraw(loginpwd, RealName, DrawSumMoney, bankname, bankaddress, bankcardno, bindAddDraw);

    });

   
}

function bindAddDraw(a)
{
    layer.closeAll('loading');
    if (a.res_code == 1) {
        //$("#recman").after("<p>姓名：" + a.RealName + "</p>");
        clear();
        layer.msg('已经提交提现申请,等待审核!', { icon: 6, time: 3000 });
    } else {
        layer.msg(a.res_msg, { icon: 5 });

    }
    
}

function getrecplace() {

    var recman = $("#recman").val();

    ajaxcheckaccount(recman, bind);
}

function bind(a) {

    if (a.res_code == 1) {
        $("#rname").text("姓名：" + a.RealName);
    } else {
        $("#rname").text("");
        layer.msg(a.res_msg, { icon: 5 });

    }

}

function clear()
{
    loadInfo();
}



</script> 


</body>
</html>