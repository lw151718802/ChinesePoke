var arrySheng = new Array();
var arryShi = new Array();
var arryXian = new Array();
var areaSelect = {
    slt_sheng: $('<select class=\"select\" id=\"province\">', {
        name: "sheng"
    }),
    slt_shi: $('<select class=\"select\" id=\"city\">', {
        name: "shi"
    }),
    slt_xian: $('<select class=\"select\" id=\"area\">', {
        name: "xian"
    }),
    createSelect: function () {
        $(this.slt_sheng)[0].options.add(new Option("请选择省份", "-1"));
        $(this.slt_shi)[0].options.add(new Option("请选择市", "-1"));
        $(this.slt_xian)[0].options.add(new Option("请选择区、县", "-1"));
        areaSelect.bindSheng();
        areaSelect.showSelect();
    }
};
areaSelect.showSelect = function () // 显示select控件和添加事件
{
    $("#info #info1").append(areaSelect.slt_sheng);
    $("#info #info2").append(areaSelect.slt_shi);
    $("#info #info3").append(areaSelect.slt_xian);
    $(areaSelect.slt_sheng).change(function () {
        areaSelect.bindShi(this.value);
    });
    $(areaSelect.slt_shi).change(function () {
        areaSelect.bindXian(this.value);
    });
    $(areaSelect.slt_xian).change(function () {
        var from_nr;
        /*省*/
        var province_xz = document.getElementById("province").selectedIndex;
        var province_nr = document.getElementById("province").options[province_xz].text;
        /*市*/
        var city_xz = document.getElementById("city").selectedIndex;
        var city_nr = document.getElementById("city").options[city_xz].text;
        /*地*/
        var area_xz = document.getElementById("area").selectedIndex;
        var area_nr = document.getElementById("area").options[area_xz].text;
        from_nr = province_nr + "-" + city_nr + "-" + area_nr;
        $("#address_all").val(from_nr);
        $("#info").hide();

    });
};
areaSelect.bindSheng = function () // 绑定省
{
    $.each(arrySheng,
    function (infoIndex, info) {
        $(areaSelect.slt_sheng)[0].options.add(new Option(info[0], info[1]));
    });
};
areaSelect.bindShi = function (pId) // 绑定市
{
    $(areaSelect.slt_shi).empty();
    $(areaSelect.slt_shi)[0].options.add(new Option("请选择市", "-1"));
    $(areaSelect.slt_xian).empty();
    $(areaSelect.slt_xian)[0].options.add(new Option("请选择区、县", "-1"));
    $.each(arryShi,
    function (infoIndex, info) {
        if (info[2] == pId) {
            $(areaSelect.slt_shi)[0].options.add(new Option(info[0], info[1]));
        }
    });
};
areaSelect.bindXian = function (cId) // 绑定区县
{
    $(areaSelect.slt_xian).empty();
    $(areaSelect.slt_xian)[0].options.add(new Option("请选择区、县", "-1"));
    $.each(arryXian,
    function (infoIndex, info) {
        if (info[2] == cId) {
            $(areaSelect.slt_xian)[0].options.add(new Option(info[0], info[1]));



        }

    });
};
$(function () {
    $.getJSON("/static/js/common/region_info.json",
    function (data) {
        $.each(data["region_info"],
        function (infoIndex, info) {
            if (info["PARENT_ID"] == 1) {
                arrySheng.push([info["NAME"], info["ID"], info["PARENT_ID"]]);
            } else if (info["CODE"].substring(4, 6) == "00") {
                arryShi.push([info["NAME"], info["ID"], info["PARENT_ID"]]);
            } else {
                if (info["ID"] != 1) {
                    arryXian.push([info["NAME"], info["ID"], info["PARENT_ID"]]);
                }
            }
        }); areaSelect.createSelect();


        if (typeof (address_id) != "undefined" && address_id != null && address_id != "" && address_id != 0) {
            getAddresssById();
        }
    });
});

/*地区选择输出*/
function area_off() {
    $("#area").children("option").click(function () {
     
        var from_nr;
        /*省*/
        var province_xz = document.getElementById("province").selectedIndex;
        var province_nr = document.getElementById("province").options[province_xz].text;
        /*市*/
        var city_xz = document.getElementById("city").selectedIndex;
        var city_nr = document.getElementById("city").options[city_xz].text;
        /*地*/
        var area_xz = document.getElementById("area").selectedIndex;
        var area_nr = document.getElementById("area").options[area_xz].text;
        from_nr = province_nr + "-" + city_nr + "-" + area_nr;

       
        $("#address_all").val(from_nr);
        $("#info").hide();
    });

}
