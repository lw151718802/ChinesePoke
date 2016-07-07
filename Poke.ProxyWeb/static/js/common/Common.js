//=============================切换验证码======================================


var wx = !1,
	rebuild = !1,
	ua = navigator.userAgent.toLowerCase();
"micromessenger" == ua.match(/MicroMessenger/i) && (wx = !0);
var goodsImg = "_400x400.png",
	goodsDetailImg = "_640x640.png",
	bannerImg = "_640x640.png",
	rebuildTime = "15:20 - 15:40",
	countDownTime = 18E4,
	refundTime = 7776E6,
	domain = "http://img02.ygqq.com/",
	imageURL = "http://img02.ygqq.com",
	goodsBaseUrl = "http://img02.ygqq.com/upload/goodsfile/",
	dutyfreeGoodsBaseUrl = "http://img02.ygqq.com",
	dialog_val, timeout = 2E4;

$(function () {


});

function btncheckPwd() {

    var pwd = $("#PWDB").val();

    checkPwd(pwd, bindCheckPWD);
}

function FixedTableHeader(gv, scrollHeight) {
    var gvn = $(gv).clone(true).removeAttr("id");
    $(gvn).find("tr:not(:first)").remove();
    $(gv).before(gvn);
    $(gv).find("tr:first").remove();
    $(gv).wrap("<div id='FixedTable' style='width:auto;height:" + scrollHeight + "px;overflow-y: auto; overflow-x: hidden;scrollbar-face-color: #e4e4e4;scrollbar-heightlight-color: #f0f0f0;scrollbar-3dlight-color: #d6d6d6;scrollbar-arrow-color: #240024;scrollbar-darkshadow-color: #d6d6d6; padding: 0;margin: 0;'></div>");
    var lie = $(gvn).find('thead').find("td").length - 1;
    var arr = $(gvn).find('thead').find("td");
    if ($("#FixedTable").height() > scrollHeight) {
        var lastwidth = $(arr[lie]).width() + 17;
        $(arr[lie]).attr('style', 'width:' + lastwidth + 'px;border-right: 0px');
    } else {
        $(arr[lie]).attr('style', 'border-right: 0px')
    }
}
/**.div-body 自应表格高度**/
function divresize(height) {
   
    resizeU();
    $(window).resize(resizeU);
    function resizeU() {
        $(".div-body").css("height", $(window).height() - height);
    }
}



/**
数据验证完整性
**/
function CheckDataValid(id) {
   
    if (!JudgeValidate(id)) {
        return false;
    } else {
        return true;
    }
}

function ToggleCode(obj, codeurl) {
    $("#txtCode").val("");
    $("#" + obj).attr("src", codeurl + "?time=" + Math.random());
}

function LoadCheckPWD()
{
    var hurl = window.location.href;
  
    if (hurl.indexOf('index') > -1 || hurl.indexOf('MemberComplete') > -1 || hurl.indexOf('Notic') > -1) {
        
        loadhtml();
    }
    else
    {
        $(".page-container").load("/User/template/checkpwd.html", function () {

        });
    }
  
}

function bindCheckPWD(a) {

    if (a.res_code == 1) {
        loadhtml();


    } else {
        layer.msg(a.res_msg, { icon: 5 });
    }

}


function isNumberBy100(ssn) {
    var re = /^[0-9]*[0-9]$/i;       //校验是否为数字
    if (re.test(ssn) && ssn > 0 && ssn % 100 === 0) {
        return true;
    } else {
        return false;
    }
}
function moneyIntFormat(a) {
    if (0 == a) return a;
    if (0 > a) {
        n = 2;
        a = parseFloat((-1 * a + "").replace(/[^\d\.-]/g, "")).toFixed(n) + "";
        a = a.split(".")[0].split("").reverse();
        var c = "";
        for (i = 0; i < a.length; i++) c += a[i] + (0 == (i + 1) % 3 && i + 1 != a.length ? "," : "");
        return "-" + c.split("").reverse().join("")
    }
    n = 2;
    a = parseFloat((a + "").replace(/[^\d\.-]/g, "")).toFixed(n) + "";
    a = a.split(".")[0].split("").reverse();
    c = "";
    for (i = 0; i < a.length; i++) c += a[i] + (0 == (i + 1) % 3 && i + 1 != a.length ? "," : "");
    return c.split("").reverse().join("")
}

function goBack() {
    window.history.go(-1)
}

/*
 * 描述：页面弹窗
 * 参数：显示信息
 * */
function dialog(msg, href) {
    layer.msg(msg, {
        time: 2000 //2秒关闭（如果不配置，默认是3秒）
    }, function () {
        //do something
        if (typeof (href) != "undefined" && href != "") {
            window.location.href = href;
        }
    });
}

function checkIsNull(a) {
    return a || "undefined" == typeof a || null == a ? !1 : !0
}
function checkNum(a) {
    return /^[0-9]*$/.test(a)
}
function changeTab(a, c, b) {
    $(a).removeClass(b);
    $(a).eq(c).addClass(b)
}

function formatDate_S(date, format) {
    if (!date) return;
    if (!format) format = "yyyy-MM-dd HH:mm:ss";

   
    switch (typeof date) {
        case "string":
            date = new Date(date.replace(/-/, "/").replace('T',' '));
            break;
        case "number":
            date = new Date(date);
            break;
    }
    if (!date instanceof Date) return;
    var dict = {
        "yyyy": date.getFullYear(),
        "M": date.getMonth() + 1,
        "d": date.getDate(),
        "H": date.getHours(),
        "m": date.getMinutes(),
        "s": date.getSeconds(),
        "MM": ("" + (date.getMonth() + 101)).substr(1),
        "dd": ("" + (date.getDate() + 100)).substr(1),
        "HH": ("" + (date.getHours() + 100)).substr(1),
        "mm": ("" + (date.getMinutes() + 100)).substr(1),
        "ss": ("" + (date.getSeconds() + 100)).substr(1)
    };
    return format.replace(/(yyyy|MM?|dd?|HH?|ss?|mm?)/g, function () {
        return dict[arguments[0]];
    });
}

var formatDate = function (a, c) {
    c || (c = "yyyy-MM-dd HH:mm:ss");
    a = new Date(parseInt(a));
    var b = {
        yyyy: a.getFullYear(),
        M: a.getMonth() + 1,
        d: a.getDate(),
        H: a.getHours(),
        m: a.getMinutes(),
        s: a.getSeconds(),
        S: ("" + (a.getMilliseconds() + 1E3)).substr(1),
        MM: ("" + (a.getMonth() + 101)).substr(1),
        dd: ("" + (a.getDate() + 100)).substr(1),
        HH: ("" + (a.getHours() + 100)).substr(1),
        mm: ("" + (a.getMinutes() + 100)).substr(1),
        ss: ("" + (a.getSeconds() + 100)).substr(1)
    };
    return c.replace(/(y+|M+|d+|H+|s+|m+|S)/g, function (a) {
        return b[a]
    })
};

function lazyload(a) {
    $("img.lazy" + a).lazyload({
        effect: "fadeIn",
        placeholder: "/static/img/loading.jpg",
        threshold: 100,
        skip_invisible: !1
    })
}
function calcImgHeight(a, c) {
    var b = parseInt(document.body.scrollWidth - a) / c;
    200 < b && (b = 200);
    return b
}
function checkLoginState(a) {
    var c = $("#uid").val(),
		b = "/login.do?url=" + encodeURIComponent(window.location.pathname + window.location.search);
    return "" == c || null == c || "0" == c || 0 == c ? (1 == a && (window.location = b), !1) : !0
}
function handlingException(a) {

    layer.msg("亲！网络环境差,拼命加载中 ...", {
        time: 2000 //2秒关闭（如果不配置，默认是3秒）
    }, function () {
       
    });

 
}
function verification(a, c) {
    layer.closeAll('loading');
    if (null != a && "" != a && "undefined" != typeof a && 1 == a.res_code) return !0;
 
    0 != c && dialog(a.res_msg);
    return !1
}
function ajaxBeforeSendOfList() {
    $("#more").hide();
    $("#loading").show()
}
function ajaxCompleteOfList() {
    $("#loading").hide()
}
function ajaxBeforeSendOfDetail() {
    dialog_val = layer.open({
        type: 2
    })
}
function ajaxCompleteOfDetail() {
    layer.close(dialog_val)
}

function GetQueryString(a) {
    a = new RegExp("(^|&)" + a + "=([^&]*)(&|$)");
    a = window.location.search.substr(1).match(a);
    return null != a ? unescape(a[2]) : null
};