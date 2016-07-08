<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chaegerecord.aspx.cs" Inherits="Poke.ProxyWeb.User.gameuser.chaegerecord" %>

<!DOCTYPE HTML>
<html>
<head>
   <!--#include file="../_meta.html"-->
    <script type="text/javascript" src="/lib/My97DatePicker/WdatePicker.js"></script> 
<link href="/lib/page.css" rel="stylesheet" />
<title>充值记录</title>
</head>
<body>
<nav class="breadcrumb"><i class="Hui-iconfont">&#xe67f;</i> 首页 <span class="c-gray en">&gt;</span> 充值管理 <span class="c-gray en">&gt;</span> 充值记录 <a class="btn btn-success radius r" style="line-height:1.6em;margin-top:3px" href="javascript:loadhtml();" title="刷新" ><i class="Hui-iconfont">&#xe68f;</i></a></nav>
    <div class="page-container">
  <div class="panel panel-primary">
	<div class="panel-header">充卡人次  ：   &nbsp;&nbsp;   <span class="label label-default radius" id="usercount">正在获取....</span>    &nbsp;&nbsp;    卖卡总数  ：   &nbsp;&nbsp;   <span class="label label-default radius" id="cardcount">正在获取....</span></div>
	<div class="panel-body"> 
        <div class="text-l"> 日期范围：
		<input type="text" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'datemax\')||\'%y-%M-%d\'}'})" id="datemin" class="input-text Wdate" style="width:120px;">
		-
		<input type="text" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'datemin\')}',maxDate:'%y-%M-%d'})" id="datemax" class="input-text Wdate" style="width:120px;">
		<input type="text" class="input-text" style="width:250px" placeholder="输入玩家ID" id="uid" name="uid">
		<button type="submit" class="btn btn-success" id="" name="" onclick="return search();"><i class="Hui-iconfont">&#xe665;</i> 搜记录</button>
	</div>
    

<div class="mt-20 div-body" id="div-body">

    <table class="table table-border table-bordered table-hover table-bg ">
        <thead>
            <tr class="text-c">

                <th width="70">购卡时间</th>
                <th width="50">玩家ID</th>
                <th width="100">昵称</th>
                <th width="90">数量</th>
            </tr>
        </thead>
        <tbody id="dataTable"></tbody>
    </table>


</div>
<div class="row cl">
    <div id="pager"></div>
</div>


</div>
     </div> </div>
  <!--#include file="../_footer.html"-->

<script type="text/javascript" src="/lib/js-extend.js"></script>
<script type="text/javascript" src="/lib/jquery-ajax-pager.js"></script>
<script type="text/javascript">


    $(function () {
        init();
    })

    function search()
    {
        init();
    }

    function init()
    {
        divresize(240);
        //FixedTableHeader("#table1", $(window).height() - 151);
        layer.msg('加载中', { icon: 16 });
        $('#pager').sjAjaxPager({
            url: "/Ajax/GetPage.ashx",

            pageSize: 10,
            searchParam: {
                /*
                * 如果有其他的查询条件，直接在这里传入即可
                */
                datemin: $("#datemin").val(),
                datemax: $("#datemax").val(),
                uid: $("#uid").val()
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
                layer.closeAll('loading');

                $("#cardcount").text(-data.sumcard);
                $("#usercount").text(data.total);
                var tableStr = "";
                var s = '';
                $.each(data.items, function (i, v) {
                    tableStr += "<tr lass=\"text-c\">";
                    tableStr += "<td>" + formatDate_S((v.createdatetime)) + "</td>";
                    tableStr += "<td>" + v.uid + "</td>";
                    tableStr += "<td>" + v.name + "</td>";
                    tableStr += "<td>" + (-v.card) + "</td>";
                   
                    tableStr += "</tr>";
                    s = v.REGDATE;

                });
                $('#dataTable').html(tableStr);
               
            },
            complete: function () {
            }
        });
    }

    $(function () {

       
    })



</script> 
</body>
</html>