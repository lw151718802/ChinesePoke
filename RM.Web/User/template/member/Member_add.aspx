<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member_add.aspx.cs" Inherits="RM.Web.User.template.member.Member_add" %>

<!DOCTYPE html>

<!--_meta 作为公共模版分离出去-->
<!DOCTYPE HTML>
<html>
<head>
   <!--#include file="../_meta.html"-->
   
</head>
<body>
         <nav class="breadcrumb"><i class="Hui-iconfont">&#xe67f;</i> 首页 <span class="c-gray en">&gt;</span> 会员管理 <span class="c-gray en">&gt;</span> 注册新会员 <a class="btn btn-success radius r" style="line-height:1.6em;margin-top:3px" href="javascript:location.replace(location.href);" title="刷新" ><i class="Hui-iconfont">&#xe68f;</i></a></nav>

    <div class="page-container">
         
    </div>
    <!--_footer 作为公共模版分离出去-->
  <!--#include file="../_footer.html"-->
    <!--/_footer /作为公共模版分离出去-->
    

    <script type="text/javascript">
$(function(){
	


	
});

function init()
{
    $("#bankcardno").keydown(function (e) {
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
}

function loadhtml() {
    $(".page-container").load("html/Member_add.html", function () {
        init();
    });
}


function submituser()
{
    
    var buymoney = $("#buymoney").val();
    var realname = $("#realname").val();
    var idno = $("#idno").val();
    var bankname = $("#bankname").val();
    var bankaddress = $("#bankaddress").val();
    var bankcardno = $("#bankcardno").val();
    var email = $("#email").val();
    var phone = $("#phone").val();
    //var recman = $("#recman").val();
 

    if (!CheckDataValid('#form-member-add')) {
        return false;
    }
    layer.load(1, { shade: [0.8, '#393D49'] })
    ajaxAddUser(buymoney, realname, idno, bankname, bankaddress, bankcardno, email, phone, bindAddUser);
}

function bindAddUser(a)
{
    layer.closeAll('loading');
    if (a.res_code == 1) {
        //$("#recman").after("<p>姓名：" + a.RealName + "</p>");
        clear();
        layer_show("注册成功 " + a.Account, 'Member_Show.aspx?v=' + a.Account, '360', '400')
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
   $("#buymoney").val('');
   $("#realname").val('');
   $("#idno").val('');
   $("#bankname").val('');
   $("#bankaddress").val('');
   $("#bankcardno").val('');
   $("#email").val('');
   $("#phone").val('');
   $("#recman").val('');
   $("#rname").text("");
}



</script> 


</body>
</html>