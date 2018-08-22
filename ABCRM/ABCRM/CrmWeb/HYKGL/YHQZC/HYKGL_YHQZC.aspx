﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HYKGL_YHQZC.aspx.cs" Inherits="BF.CrmWeb.HYKGL.YHQZC.HYKGL_YHQZC" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <%=V_Head_Input %>
    <script>
        vPageMsgID = '<%=CM_HYKGL_YHQZHZC%>';
        bCanEdit = CheckMenuPermit(iDJR, <%=CM_HYKGL_YHQZHZC_LR%>);
        bCanExec = CheckMenuPermit(iDJR, <%=CM_HYKGL_YHQZHZC_SH%>);
        bCanSrch = CheckMenuPermit(iDJR, <%=CM_HYKGL_YHQZHZC_CX%>);
    </script>
    <script src="../../CrmLib/CrmLib_GetData.js"></script>
    <script src="HYKGL_YHQZC.js"></script>
    <script src="../../CrmLib/CrmLib_FillBGDD.js"></script>
</head>
<body>
    <%=V_InputBodyBegin %>
    <div class="bfrow">
        <div class="bffld">
            <div id="jlbh"></div>
        </div>
        <div class="bffld">
            <div class="bffld_left">转入卡号</div>
            <div class="bffld_right">
                <input id="TB_ZRHYKNO" type="text" onblur="GetCheck();" />
                <input id="HF_HYID" type="hidden" />
            </div>
        </div>
    </div>
    <div class="bfrow">
        <div class="bffld">
            <div class="bffld_left">卡类型</div>
            <div class="bffld_right">
                <label id="LB_HYKNAME" runat="server" />
                <input id="HF_HYKTYPE" type="hidden" />
            </div>

        </div>
        <div class="bffld">
            <div class="bffld_left">操作地点</div>
            <div class="bffld_right">
                <input id="TB_BGDDMC" runat="server" />
                <input id="HF_BGDDDM" type="hidden" />

            </div>

        </div>
    </div>

    <div class="bfrow">
        <div class="bffld">
            <div class="bffld_left">摘要</div>
            <div class="bffld_right">
                <input id="TB_ZY" type="text" class="long" />
            </div>
        </div>
    </div>

    <div class="bfrow">
        <div class="bffld">
            <div class="bffld_left">转入总金额</div>
            <div class="bffld_right">
                <label id="LB_ZRJE" runat="server" />
            </div>
        </div>
    </div>

    <div class="bfrow bfrow_table">
        <table id="list" style="border: thin"></table>
    </div>
    <div id="tb" class="item_toolbar">
        <span style="float: left">卡号列表</span>
        <button id="AddItem" type='button' class="item_addtoolbar">添加卡</button>
        <button id="DelItem" type='button' class="item_deltoolbar">删除卡</button>
    </div>

    <%=V_InputBodyEnd %>
    <div id="menuContent" class="menuContent">
        <ul id="TreeBGDD" class="ztree"></ul>
    </div>
</body>
</html>


