<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkPWD.aspx.cs" Inherits="RM.Web.User.template.checkPWD" %>


<!DOCTYPE html>

<!--_meta 作为公共模版分离出去-->
<!DOCTYPE HTML>
<html>
<head>
   <!--#include file="_meta.html"-->
   
</head>
<body>
    <div class="page-container">
        <form action="" method="post" class="form form-horizontal" id="form-member-add">

             <div class="row cl">
                <label class="form-label col-xs-4 col-sm-2"><span class="c-red">*</span>二级密码：</label>
              <div class="formControls col-xs-7 col-sm-8">
                    <input  type="password" class="input-text"  placeholder="请输入二级密码" id="PWDB" name="PWDB" > 
                </div>
            </div>
           <div class="row cl">
			<div class="col-xs-8 col-sm-9 col-xs-offset-3 col-sm-offset-2">
				<input class="btn btn-primary radius" type="button" onclick=" btncheckPwd()" value="&nbsp;&nbsp;提&nbsp;交&nbsp;&nbsp;">
			</div>
		 </div>


          
		</div>
        </form>
    </div>
    <!--_footer 作为公共模版分离出去-->
  <!--#include file="_footer.html"-->
    <!--/_footer /作为公共模版分离出去-->
    

    <script type="text/javascript">




function btncheckPwd()
{
   
    var pwd = $("#PWDB").val();

    checkPwd(pwd, bindCheckPWD);
}

function bindCheckPWD(a) {
    
    if (a.res_code == 1) {
        var index = parent.layer.getFrameIndex(window.name);
        parent.layer.close(index);
    } else {
        layer.msg(a.res_msg, { icon: 5 });
    
    }

}

</script> 


</body>
</html>