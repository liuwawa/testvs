﻿vUrl = "../HYKGL.ashx";
var iMDID, iYHQID, iHYKTYPE, sSKTNO, iSEARCHMODE = 0;

function InitGrid() {
    vColumnNames = ["卡名称", "卡类型", "门店名称", "MDID", '优惠券名称', "YHQID", "前台放券金额", "并卡金额","取款金额", ];
    vColumnModel = [          
            { name: 'sHYKNAME', width: 70 },
            { name:'iHYKTYPE',width:70},
            { name: 'sMDMC', width: 70 },
            { name: 'iMDID', hidden: true },           
            { name: 'sYHQMC', width: 70, },//sortable默认为true width默认150
            { name: 'iYHQID', hidden: true },
            { name: 'fQTFQJE', width: 70 },
            { name: 'fBKJE', width: 70 },
            { name: 'fQKJE', width: 70 },			

    ];

    vMDKTXFColumnNames = ['款台', "卡名称", "卡类型", "门店名称", "MDID", '优惠券名称', "YHQID", "前台放券金额", "并卡金额", "取款金额", ];
    vMDKTXFColumnModel = [
            { name: 'sSKTNO', width: 70, },
            { name: 'sHYKNAME', width: 70 },
            { name: 'iHYKTYPE', width: 70 },
            { name: 'sMDMC', width: 70 },
            { name: 'iMDID', hidden: true },
            { name: 'sYHQMC', width: 70, },
            { name: 'iYHQID', hidden: true },
            { name: 'fQTFQJE', width: 70 },
            { name: 'fBKJE', width: 70 },
            { name: 'fQKJE', width: 70 },
    ];
    vMDKTSKYXFColumnNames = ['款台', '门店名称', '卡号', '优惠券名称', '借方金额', '贷方金额', '余额', '摘要'];
    vMDKTSKYXFColumnModel = [
           { name: 'sSKTNO', width: 70, },
           { name: 'sMDMC', width: 70, },
           { name: 'sHYK_NO', width: 70, },
           { name: 'sYHQMC', width: 70, },
           { name: 'fJFJE', width: 70, },
           { name: 'fDFJE', width: 70, },
           { name: 'fYE', width: 70, },
           { name: 'sZY', width: 70, },
    ];

};

$(document).ready(function () {
    $("#B_Exec").hide();
    $("#B_Insert").hide();
    $("#B_Update").hide();
    $("#B_Delete").hide();
    DrawGrid("list1", vMDKTXFColumnNames, vMDKTXFColumnModel);
    DrawGrid("list2", vMDKTSKYXFColumnNames, vMDKTSKYXFColumnModel);



    BFButtonClick("TB_YHQMC", function () {
        SelectYHQ("TB_YHQMC", "HF_YHQID", "zHF_YHQID", false);
    });
    BFButtonClick("TB_MDMC", function () {
        SelectMD("TB_MDMC", "HF_MDID", "zHF_MDID", false);
    });

    $("#list1").datagrid({
        onClickRow: function (rowIndex, rowData) {
            iMDID = rowData.iMDID;
            iYHQID = rowData.iYHQID;
            iHYKTYPE = rowData.iHYKTYPE;
            sSKTNO = rowData.sSKTNO;
            iSEARCHMODE = 2;
            SearchData(undefined, undefined, undefined, undefined, 'list2');
        },
    });
    RefreshButtonSep();
});
function OnClickRow(rowIndex, rowData) {
    $('#list2').datagrid("loadData", { total: 0, rows: [] });
    iMDID = rowData.iMDID;
    iYHQID = rowData.iYHQID;
    iHYKTYPE = rowData.iHYKTYPE;
    iSEARCHMODE = 1;
    SearchData(undefined, undefined, undefined, undefined, 'list1');

}

function SearchClick() {
    if (!IsValidSearch())
        return;
    iSEARCHMODE = 0;
    SearchData();
    SetControlBaseState();
};

function MakeSearchCondition() {
    var arrayObj = new Array();
    if (iSEARCHMODE == 0) {
        MakeSrchCondition(arrayObj, "HF_YHQID", "iYHQID", "in", false);
        MakeSrchCondition(arrayObj, "HF_MDID", "iMDID", "in", false);
    }
    MakeSrchCondition(arrayObj, "TB_XFRQ1", "dRQ", ">=", true);
    MakeSrchCondition(arrayObj, "TB_XFRQ2", "dRQ", "<=", true);
    MakeMoreSrchCondition(arrayObj);
    return arrayObj;
};

function AddCustomerCondition(Obj) {
    Obj.iMDID = iMDID;
    Obj.iYHQID = iYHQID;
    Obj.iHYKTYPE = iHYKTYPE;
    Obj.sSKTNO = sSKTNO;
    Obj.iSEARCHMODE = iSEARCHMODE;
}

