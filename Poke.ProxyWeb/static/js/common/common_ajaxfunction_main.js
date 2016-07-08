/*获取当前代理商信息*/
function GetProxy_Info(c)
{
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/Ajax/ProxyInfoHandler.ashx?t=" + Math.random(),
        data: {
        },
        success: function (b) {

            verification(b) && c(b)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
/*获取玩家信息*/
function Game_UserHandler(a,c) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/Ajax/Game_UserHandler.ashx?t=" + Math.random(),
        data: {
            uid:a
        },
        success: function (b) {

            verification(b,1) && c(b)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}


function Game_UserChrage(a,b,c)
{
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/Ajax/Game_UserHandler.ashx?t=" + Math.random(),
        data: {
            action:'charge',
            uid: a,
            card:b
        },
        success: function (rs) {

             c(rs)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxAddProxyUser(a, b, c,d,e,f) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/Ajax/Game_UserHandler.ashx?t=" + Math.random(),
        data: {
            action: 'charge',
            uid: a,
            card: b
        },
        success: function (rs) {

            f(rs)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}


/*
 * Description : 所有接口 请求函数
 * Author : gaoxiaopeng@ddtkj.com
 * Time : 2015年 6月10日
 *   */
/*
 * 方法描述：获取分类
 * 参数1： pid Int 父ID
 * 参数2：layer int  层次ID
 * 参数3：priceArea  价格区间  （10元 专区 100元专区）
 * 返回值：Json格式   往期揭晓集合
 * 返回值主体：class_list
 */
//验证二级密码
function checkPwd(a,d) {
   
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/User/Ajax/checkpwd.ashx?t=" + Math.random(),
        data: {
            pwd: a
        },
        success: function (rs) {

            d(rs);
        },
        error: function (a) {
            handlingException(a)
        }
    })
}


//验证推荐人账号是否正确
function ajaxcheckaccount(a, d) {

  
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/User/Ajax/checkaccount.ashx?t=" + Math.random(),
        data: {
             account: a
        },
        success: function (rs) {
           
            d(rs);
        },
        error: function (a) {
            handlingException(a)
        }
    })
}

//验证推荐人账号是否正确
function ajaxUserInfo(a, d) {

    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/User/Ajax/GetUserInfo.ashx?t=" + Math.random(),
        data: {
            account: a
        },
        success: function (rs) {

            d(rs);
        },
        error: function (a) {
            handlingException(a)
        }
    })
}


function ajaxIsLogin(c) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/member_controller/islogin.do?t=" + Math.random(),
        success: function (b) {
            verification(b) && c(b)
        },
        error: function (b) {
            handlingException(b)
        }
    })
}
//获取当前登录用户基本信息GetCurrentPerson
function ajaxGetCurrentPerson(d) {

    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/User/Ajax/GetCurrentPerson.ashx?t=" + Math.random(),
        data: {
           
        },
        success: function (rs) {

            d(rs);
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
//注册新会员

function ajaxAddUser(buymoney, realname, idno, bankname, bankaddress, bankcardno, email, phone, d)
{
   
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/User/Ajax/AddUser.ashx?t=" + Math.random(),
        data: {
            buymoney: escape(buymoney),
            realname: realname,
            idno: idno,
            bankname: bankname,
            bankaddress: bankaddress,
            bankcardno: bankcardno,
            email: email,
            phone: phone

        },
        success: function (rs) {
             d(rs);
        },
        error: function (a) {
            handlingException(a)
        }
    })
}


//完善会员资料

function ajaxCompleteUser( realname, idno, bankname, bankaddress, bankcardno, email, phone, d) {

    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/User/Ajax/MemberComplete.ashx?t=" + Math.random(),
        data: {
            realname: realname,
            idno: idno,
            bankname: bankname,
            bankaddress: bankaddress,
            bankcardno: bankcardno,
            email: email,
            phone: phone

        },
        success: function (rs) {
            d(rs);
        },
        error: function (a) {
            handlingException(a)
        }
    })
}



//获取账号资金总额
function ajaxUserMoneyInfo(d) {

    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/User/Ajax/UserMoenyInfo.ashx?t=" + Math.random(),
        data: {
         
        },
        success: function (rs) {
           
            d(rs);
        },
        error: function (a) {
            handlingException(a)
        }
    })
}


function ajaxUserDrawInfo(d)
{
  
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/User/Ajax/UserDrawInfo.ashx?t=" + Math.random(),
        data: {
            ac:'info'
        },
        success: function (rs) {

            d(rs);
        },
        error: function (a) {
            handlingException(a)
        }
    })
}



function ajaxBackUserDraw(a,o,d) {

    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/User/Ajax/UserDrawInfo.ashx?t=" + Math.random(),
        data: {
            ac: 'back',
            id:a
        },
        success: function (rs) {

            d(rs, o);
        },
        error: function (a) {
            handlingException(a)
        }
    })
}


function ajaxAddDraw(loginpwd, RealName, DrawSumMoney, bankname, bankaddress, bankcardno, d)
{
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/User/Ajax/UserDrawInfo.ashx?t=" + Math.random(),
        data: {
            ac: 'add',
            loginpwd: loginpwd,
            RealName: RealName,
            DrawSumMoney: DrawSumMoney,
            bankname: bankname,
            bankaddress: bankaddress,
            bankcardno: bankcardno
        },
        success: function (rs) {

            d(rs);
        },
        error: function (a) {
            handlingException(a)
        }
    })

}
//提交转账信息
function ajaxAddTrans(loginpwd, recaccount, tomoney, d)
{
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/User/Ajax/AddTrans.ashx?t=" + Math.random(),
        data: {
            loginpwd: loginpwd,
            recaccount: recaccount,
            tomoney: tomoney
        },
        success: function (rs) {

            d(rs);
        },
        error: function (a) {
            handlingException(a)
        }
    })
}

//修改密码
function ajaxModify(ac,pwda,pwdb,pwdc, d) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/User/Ajax/ModifyPwd.ashx?t=" + Math.random(),
        data: {
            ac: ac,
            pwda: pwda,
            pwdb: pwdb,
            pwdc: pwdc
        },
        success: function (rs) {

            d(rs);
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxWelcomeStat(d)
{
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/User/Ajax/GetUserStatDetail.ashx?t=" + Math.random(),
        data: {
        },
        success: function (rs) {

            d(rs);
        },
        error: function (a) {
            handlingException(a)
        }
    })
}


function ajaxClassList(c, b, a, d) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/main_controller/class_list.do?t=" + Math.random(),
        data: {
            pid: c,
            layer: b
        },
        success: function (a) {
            verification(a) && d(a, c, b)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxGoodsList(c, b, a, d, e, f) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/main_controller/goods_list.do?t=" + Math.random(),
        data: {
            operation: c,
            category_id: b,
            brand_id: a,
            page: d,
            priceArea: e
        },
        beforeSend: ajaxBeforeSendOfList,
        complete: ajaxCompleteOfList,
        success: function (a) {
            verification(a) && f(a)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxGoodsListByIds(c, b) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        async: !1,
        url: "/main_controller/goods_List_byids.do?t=" + Math.random(),
        data: {
            goods_ids: c
        },
        beforeSend: ajaxBeforeSendOfList,
        complete: ajaxCompleteOfList,
        success: function (a) {
            verification(a) && b(a)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxGoods_ListByKeyWords(c, b, a, d) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/main_controller/goods_list_keywords.do?t=" + Math.random(),
        data: {
            keywords: c,
            operation: b,
            page: a
        },
        beforeSend: ajaxBeforeSendOfList,
        complete: ajaxCompleteOfList,
        success: function (a) {
            verification(a) && d(a)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxGoodsDetail(c, b) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/main_controller/goods_detail.do?t=" + Math.random(),
        data: {
            goods_id: c
        },
        beforeSend: ajaxBeforeSendOfDetail,
        complete: ajaxCompleteOfDetail,
        success: function (a) {
            verification(a) && b(a)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxGoodsBuyRecords(c, b, a, d) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/main_controller/goods_buy_records.do?t=" + Math.random(),
        data: {
            goods_id: c,
            period: b,
            page: a
        },
        beforeSend: ajaxBeforeSendOfList,
        complete: ajaxCompleteOfList,
        success: function (a) {
            verification(a) && d(a)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxPublishListResult(c, b, a, d, e) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/main_controller/publish_list.do?t=" + Math.random(),
        data: {
            jsdCard: c,
            page: b,
            pageSize: a,
            z_index: d
        },
        beforeSend: ajaxBeforeSendOfList,
        complete: ajaxCompleteOfList,
        success: function (a) {
            verification(a) && e(a)
        },
        error: function (f) {
            setTimeout(function () {
                ajaxPublishListResult(c, b, a, d, e)
            }, 1E3);
            handlingException(f)
        }
    })
}
function ajaxPublishListWait(c, b, a, d) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/main_controller/publish_list_wait.do?t=" + Math.random(),
        data: {
            jsdCard: c,
            page: b,
            pageSize: a
        },
        beforeSend: ajaxBeforeSendOfList,
        complete: ajaxCompleteOfList,
        success: function (a) {
            verification(a) && d(a)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxPublishWaitTime(c, b, a) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/main_controller/expect_publish_time.do?t=" + Math.random(),
        data: {
            goods_id: c,
            period: b
        },
        success: function (b) {
            verification(b) && a(b)
        },
        error: function (d) {
            setTimeout(function () {
                ajaxPublishWaitTime(c, b, a)
            }, 1E3);
            handlingException(d)
        }
    })
}
function ajaxPublishDetail(c, b, a) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/main_controller/publish_detail.do?t=" + Math.random(),
        data: {
            goods_id: c,
            period: b
        },
        success: function (d) {
            verification(d) && a(d, c, b)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxPublishListHistory(c, b, a, d, e) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/main_controller/publish_history.do?t=" + Math.random(),
        data: {
            goods_id: c,
            period: b,
            page: a,
            size: d
        },
        beforeSend: ajaxBeforeSendOfList,
        complete: ajaxCompleteOfList,
        success: function (a) {
            verification(a) && e(a)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxPublishDetailCalculate(c, b, a) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/main_controller/publish_detail_calculate.do?t=" + Math.random(),
        data: {
            goods_id: c,
            period: b
        },
        beforeSend: ajaxBeforeSendOfDetail,
        complete: ajaxCompleteOfDetail,
        success: function (b) {
            verification(b) && a(b)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxPerson_Record_List_Buy(c, b, a) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/main_controller/person_records_buy.do?t=" + Math.random(),
        data: {
            user_id: c,
            page: b
        },
        beforeSend: ajaxBeforeSendOfList,
        complete: ajaxCompleteOfList,
        success: function (b) {
            verification(b) && a(b)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxPerson_Record_List_Win(c, b, a, d) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/main_controller/person_records_win.do?t=" + Math.random(),
        data: {
            user_id: c,
            isMobileCard: b,
            page: a
        },
        beforeSend: ajaxBeforeSendOfList,
        complete: ajaxCompleteOfList,
        success: function (a) {
            verification(a) && d(a)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxExposeList(c, b, a, d, e) {
    $.ajax({
        type: "get",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/main_controller/expose_list.do",
        data: {
            goods_id: b,
            user_id: c,
            pageSize: d,
            page: a
        },
        beforeSend: ajaxBeforeSendOfList,
        complete: ajaxCompleteOfList,
        success: function (a) {
            verification(a) && e(a)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxExposeDetail(c, b, a, d) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/main_controller/expose_detail.do?t=" + Math.random(),
        data: {
            show_id: c,
            user_id: b,
            page: a
        },
        beforeSend: ajaxBeforeSendOfDetail,
        complete: function () {
            layer.closeAll("loading");
            $("#loading").hide()
        },
        success: function (a) {
            verification(a) && d(a)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxGetHotSearch(c, b) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/main_controller/hot_search.do?t=" + Math.random(),
        data: {
            size: c
        },
        beforeSend: ajaxBeforeSendOfDetail,
        complete: ajaxCompleteOfDetail,
        success: function (a) {
            verification(a) && b(a)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxBannerImg(c, b) {
    $.ajax({
        type: "get",
        timeout: timeout,
        dataType: "json",
        cache: !0,
        url: "/main_controller/banner_img.do",
        data: {
            type: c
        },
        success: function (a) {
            verification(a) && b(a)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxSign(c, b) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/member_controller/sign.do?t=" + Math.random(),
        data: {
            signToken: c
        },
        success: function (a) {
            verification(a) ? b(a) : isSign = !0
        },
        error: function (a) {
            handlingException(a)
        }
    })
}

function ajaxQueryCodes(c, b, a) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        data: {
            goods_id: c,
            period: b
        },
        url: "/member_controller/querycodes.do?t=" + Math.random(),
        success: function (b) {
            verification(b) && a(b)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxBeforeWinnerCodes(c, b, a, d) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        data: {
            uid: c,
            goods_id: b,
            period: a
        },
        url: "/main_controller/querycodes.do?t=" + Math.random(),
        success: function (a) {
            verification(a) && d(a)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxGetToken(c, b) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/member_controller/getToken.do?t=" + Math.random(),
        data: {
            tokenName: c
        },
        beforeSend: ajaxBeforeSendOfDetail(),
        complete: ajaxCompleteOfDetail(),
        success: function (a) {
            verification(a) ? b(a) : "请登录" == a.res_msg && dialog(a.res_msg, "/login.html")
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxShowDetail(c, b, a, d) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/main_controller/expose_detail.do?t=" + Math.random(),
        data: {
            show_id: c,
            user_id: b,
            page: a
        },
        beforeSend: ajaxBeforeSendOfList,
        complete: ajaxCompleteOfList,
        success: function (a) {
            verification(a) && d(a)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxCheckPresellGoods(c, b) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        data: {
            cart: c
        },
        url: "/member_controller/checkPresellGoods.do?t=" + Math.random(),
        beforeSend: ajaxBeforeSendOfDetail,
        complete: ajaxCompleteOfDetail,
        success: function (a) {
            verification(a) && b(a)
        },
        error: function (a) {
            handlingException(a)
        }
    })
}
function ajaxIndexPublishList(c, b, a, d) {
    $.ajax({
        type: "get",
        timeout: timeout,
        dataType: "json",
        async: !1,
        url: "/main_controller/publish_list_index.do?t=" + Math.random(),
        data: {
            page: c,
            pageSize: b,
            z_index: d
        },
        success: function (b) {
            verification(b) && a(b)
        },
        error: function (d) {
            setTimeout(function () {
                ajaxIndexPublishList(c, b, a)
            }, 1E3);
            handlingException(d)
        }
    })
}
function ajaxAccumulativePeople(c) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/main_controller/total.do?t=" + Math.random(),
        success: function (b) {
            c(b)
        },
        error: function (b) {
            handlingException(b)
        }
    })
}
function ajaxMobileDiscovery(c) {
    $.ajax({
        type: "post",
        timeout: timeout,
        dataType: "json",
        url: "/main_controller/selectMobileDiscovery.do?t=" + Math.random(),
        data: {
            page: 1,
            size: 100
        },
        success: function (b) {
            c(b)
        },
        error: function (b) {
            handlingException(b)
        }
    })
};