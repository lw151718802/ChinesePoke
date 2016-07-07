<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gameuserrecharge.aspx.cs" Inherits="Poke.ProxyWeb.User.gameuser.gameuserrecharge" %>


<!DOCTYPE html>

<!--_meta 作为公共模版分离出去-->
<!DOCTYPE HTML>
<html>
<head>
   <!--#include file="../_meta.html"-->
   
</head>
<body>
         <nav class="breadcrumb"><i class="Hui-iconfont">&#xe67f;</i> 首页 <span class="c-gray en">&gt;</span> 充值管理 <span class="c-gray en">&gt;</span> 玩家充值 <a class="btn btn-success radius r" style="line-height:1.6em;margin-top:3px" href="" title="刷新" ><i class="Hui-iconfont">&#xe68f;</i></a></nav>
   
    <div class="page-container">
         <div class="panel panel-primary">
	<div class="panel-header">玩家充值     &nbsp;&nbsp;   当前可用数量 <span class="label label-default radius" id="cardcount">正在获取....</span></div>
	<div class="panel-body"> <form action="" method="post" class="form form-horizontal" id="form-card-add">
    <div class="row cl">
        <label class="form-label col-xs-4 col-sm-2"><span class="c-red">*</span>玩家UID：</label>
        <div class="formControls col-xs-5 col-sm-7">
            <input type="text" class="input-text" placeholder="请填写会员UID" id="uid" name="buymoney" datacol="yes" err="玩家UID"
                   checkexpession="PInt">
        </div>
        <div class="formControls col-xs-3 col-sm-2">
               <input class="btn btn-primary radius" type="button" onclick="return checkuser();" value="&nbsp;&nbsp;查询&nbsp;&nbsp;">
        </div>
 
    </div>
    <div class="row cl">
        <label class="form-label col-xs-4 col-sm-2">昵称：</label>
        <div class="formControls col-xs-8 col-sm-9">
         
            <input type="text" class="input-text" placeholder="玩家昵称" id="name" name="name" disabled="disabled">
        </div>
    </div>

    <div class="row cl">
        <label class="form-label col-xs-4 col-sm-2"><span class="c-red">*</span>充卡数量：</label>
        <div class="formControls col-xs-8 col-sm-9">
            <input type="text" class="input-text" placeholder="请填写充卡数量" id="card" name="card" datacol="yes" err="充卡数量"
                   checkexpession="PInt">
        </div>
    </div>
    <div class="row cl">
        <div class="col-xs-8 col-sm-9 col-xs-offset-3 col-sm-offset-2">
            <input class="btn btn-primary radius" type="button" id="okbtn" onclick="return submitcharge()"   value="&nbsp;&nbsp;提交&nbsp;&nbsp;">
        </div>
    </div>
</form></div>
</div>
        
    </div>
    <!--_footer 作为公共模版分离出去-->
  <!--#include file="../_footer.html"-->
    <!--/_footer /作为公共模版分离出去-->
    

    <script type="text/javascript">
$(function(){
	

    init();
	
});

function init()
{
  
    GetProxy_Info(bindproxyinfo);
   
}
function bindproxyinfo(b)
{
    b = b.proxy.card;
    $("#cardcount").text(b);
 
}

function checkuser()
{
    var uid = $("#uid").val();
    Game_UserHandler(uid,bindgameuserinfo);
    

}
function bindgameuserinfo(b)
{
   
    if (b.res_code == 1) {
        var a = b.gameuser.name;
        $("#name").val(a);
       

    } else { layer.msg(a.res_msg, { icon: 5 }); }
        
}


function submitcharge()
{
    
    var uid = $("#uid").val();
    var card = $("#card").val();
  
 

    if (!CheckDataValid('#form-card-add')) {
        return false;
    }
   
    layer.load(1, { shade: [0.8, '#393D49'] })
    Game_UserChrage(uid, card, bindAddCard);
}

function bindAddCard(a)
{
    layer.closeAll('loading');
    if (a.res_code == 1) {
        //$("#recman").after("<p>姓名：" + a.RealName + "</p>");
        clear();
        $("#cardcount").text(a.card);
        layer.msg('充值成功!', { icon: 6, time: 3000 });
       // layer_show("注册成功 " + a.Account, 'Member_Show.aspx?v=' + a.Account, '360', '400')
    } else {
      
        layer.msg(a.res_msg, { icon: 5 });

    }
    
}


function clear()
{
    $("#uid").val('');
    $("#card").val('');
    $("#name").val('');
   
}



</script> 


</body>
</html>