<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notice.aspx.cs" Inherits="Poke.ProxyWeb.User.notice" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        
.detail_box{ width:1100px; margin:30px auto;}
.detail_box .top_tit{ width:80%; padding:0 10%; overflow:hidden; border-bottom:1px solid #ddd; line-height:50px; font-size:16px; font-weight:bold; height:50px;position:relative; text-align:center;}
.detail_box .top_tit .back{ position:absolute; left:0; top:0; line-height:50px; display:block; color:#1282ca;}
.detail_box .top_tit .next{ position:absolute; right:0; top:0; line-height:50px;display:block; color:#1282ca;}
.detail_box .fb_time{ text-align:center; width:100%; line-height:40px; color:#666; font-size:14px;}
.detail_box .detail_info{ padding:15px 0; line-height:26px;}
.detail_box .detail_info p{ margin-bottom:15px; text-indent:2em; color:#333;}
.blue{ color:#1181c9; font-size:18px;}

    </style>
</head>
<body>
    <form id="form1" runat="server">
   <div class="detail_box">
<div class="top_tit"><%=title %></div>	
<div class="fb_time">发表时间：<%=time %>    </div>
<div class="detail_info">
    <%=content %>
</div>
</div>
    </form>
</body>
</html>