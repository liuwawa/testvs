﻿vUrl = "../JKPT.ashx";
vCaption = "收款台消费次数监控日";

function InitGrid() {
	vColumnNames = ['收款台', '消费会员数量', '交易次数', '最大交易次数', '前5平均交易次数', '前10平均交易次数', '前20平均交易次数'];
	vColumnModel = [
			{ name: 'sSKTNO', width: 80, },
			{ name: 'fXFHYSL', width: 80 },
			{ name: 'fXFCS', width: 60 },
			{ name: 'fMAX_XFCS', width: 80, },
			{ name: 'fXFCS_5', width: 110 },
			{ name: 'fXFCS_10', width: 110 },
			{ name: 'fXFCS_20', width: 110, },
	];
}

$(document).ready(function () {
	$("#list").datagrid({
		onDblClickRow: function (rowIndex, rowData) {
			var date = new Date($("#TB_RQ").val());
			AddDays(date, -30);
			var rq1 = FormatDate(date, "yyyy-MM-dd");
			MakeNewTab("CrmWeb/JKPT/DSKTXFCSJKR/JKPT_DSKTXFCSJKR_Srch.aspx?sktno=" + rowData.sSKTNO + "&rq1=" + rq1 + "&rq2=" + $("#TB_RQ").val() + "&jxcs=" + $("#TB_TSJX").val() + "&mdid=" + $("#HF_MDID").val() + "&mdmc=" + $("#TB_MDMC").val(), "单款台监控日记录", vPageMsgID);
		}
	});


	BFButtonClick("TB_MDMC", function () {
	    SelectMD("TB_MDMC", "HF_MDID", "zHF_MDID", false);
	});


});
function OnLoadSuccess(rowIndex, rowData) {
	DrawChart();
}



function IsValidSearch() {
	if ($("#HF_MDID").val() == "" || $("#HF_MDID").val() == null) {
		ShowMessage("请选择门店");
		return false;
	}
	if ($("#TB_TSJX").val() == "") {
		ShowMessage("请输入极限次数");
		return false;
	}
	if ($("#TB_RQ").val() == "") {
		ShowMessage("请输入日期");
		return false;
	}

	if ($("#TB_SKTNO1").val() > $("#TB_SKTNO2").val()) {
		ShowMessage("开始号码不能大于结束号码");
		return false;
	}

	return true;
}

function MakeSearchCondition() {
	var arrayObj = new Array();
	MakeSrchCondition(arrayObj, "HF_MDID", "iMDID", "=", false);
	MakeSrchCondition(arrayObj, "TB_RQ", "dRQ", "=", true);
	MakeSrchCondition(arrayObj, "TB_SKTNO1", "sSKTNO", ">=", true);
	MakeSrchCondition(arrayObj, "TB_SKTNO2", "sSKTNO", "<=", true);
	return arrayObj;
};

function AddCustomerCondition(Obj) {
	Obj.fMAX_XFCS = $("#TB_TSJX").val();
}

function DrawChart() {
	var xAxisArray = new Array();
	var yAxisArray = new Array();
	var yAxisArray_max = new Array();
	var yAxisArray_5 = new Array();
	var yAxisArray_10 = new Array();
	var yAxisArray_20 = new Array();
	var lst = new Array();
	lst = $("#list").datagrid("getData").rows;
	for (i = 0; i < lst.length ; i++) {
		var rowData = lst[i];
		xAxisArray.push(rowData.sSKTNO);
		yAxisArray_max.push(parseInt(rowData.fMAX_XFCS));
		yAxisArray_5.push(parseInt(rowData.fXFCS_5));
		yAxisArray_10.push(parseInt(rowData.fXFCS_10));
		yAxisArray_20.push(parseInt(rowData.fXFCS_20));
	}
	var obj = new Object();
	obj.name = "最大消费次数";
	obj.data = yAxisArray_max;
	yAxisArray.push(obj);

	var obj = new Object();
	obj.name = "前5平均交易次数";
	obj.data = yAxisArray_5;
	yAxisArray.push(obj);

	obj = new Object();
	obj.name = "前10平均交易次数";
	obj.data = yAxisArray_10;
	yAxisArray.push(obj);

	obj = new Object();
	obj.name = "前20平均交易次数";
	obj.data = yAxisArray_20;
	yAxisArray.push(obj);

	DrawChartOne("ContinarChart", "spline", xAxisArray, "收款台", yAxisArray);
}
