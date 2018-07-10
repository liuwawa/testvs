﻿var ReportServer = "";

$(document).ready(function () {
    ReportServer = GetReportServer();
    FillSH($("#cbSH2"));
    $("#TB_MDMC").click(function () {
        if ($("#cbSH2").val() != "") {
            SelectMD("TB_MDMC", "HF_MDID", "zHF_MDID", false, $("#cbSH2").val(), "", "", "", true);
        }
        else {
            SelectMD("TB_MDMC", "HF_MDID", "zHF_MDID", false, "", "", "", "", true);
        }
    });

    $("#edRQ1").click(function () {
        BindDateEvent($("#cbRQLX").val());
    })
    $("#edRQ2").click(function () {
        BindDateEvent($("#cbRQLX").val());
    })


});

function btnSrch1Click() {
    var addr = ReportServer + "?reportlet=XZHYXFFX.cpt";

    var rqlx = parseInt($("#cbRQLX").val());
    var srq1;
    var srq2;
    var stq1;
    var stq2;
    if (rqlx == 0) {
        var rq1 = new Date($("#edRQ1").val());
        var rq2 = new Date($("#edRQ2").val());
        var tq1 = GetContrastDate($("#edRQ1").val(), rqlx);
        var tq2 = GetContrastDate($("#edRQ2").val(), rqlx);
        srq1 = GetDateString(rq1, rqlx);
        srq2 = GetDateString(rq2, rqlx);
        stq1 = GetDateString(tq1, rqlx);
        stq2 = GetDateString(tq2, rqlx);
    }
    else {
        srq1 = $("#edRQ1").val();
        srq2 = $("#edRQ2").val();
        stq1 = GetContrastDate($("#edRQ1").val(), rqlx);
        stq2 = GetContrastDate($("#edRQ2").val(), rqlx);
    }

    if ($("#cbSH2").val() != "") {
        addr += "&SHDM=" + $("#cbSH2").val();
    }
    if ($("#HF_MDID").val() != "") {
        addr += "&MDID=" + $("#HF_MDID").val();
    }
    else {
        art.dialog({ lock: true, content: "请选择门店", time: true });
        return;
    }
    addr += "&LX=" + rqlx;
    if (srq1 != "" && srq2 != "") {
        addr += "&RQ1=" + srq1 + "&RQ2=" + srq2;
    }
    addr += "&menu_id=" + vPageMsgID + "&PERSON_ID=" + iDJR;
    $("#fr1").attr("src", addr);
};

function SH2Change() {
    $("#TB_MDMC").val("");
    $("#HF_MDID").val("");
    $("#zHF_MDID").val("");
};