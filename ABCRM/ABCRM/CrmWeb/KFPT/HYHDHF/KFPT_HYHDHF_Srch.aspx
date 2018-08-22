﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KFPT_HYHDHF_Srch.aspx.cs" Inherits="BF.CrmWeb.KFPT.HYHDHF.KFPT_HYHDHF_Srch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <%=V_Head_Search %>
    <script src="KFPT_HYHDHF_Srch.js"></script>
    <script>
        vPageMsgID = '<%=CM_KFPT_HYHDHF%>';
        bCanSrch = CheckMenuPermit(iDJR, '<%=CM_KFPT_HYHDHF_CX%>');
    </script>
    <script src="../../CrmLib/CrmLib_GetData.js"></script>

</head>
<body>
    <%=V_SearchBodyBegin %>

    <div class="bfrow">
        <div class="bffld">
            <div class="bffld_left">是否回访</div>
            <div class="bffld_right">
                <input class="magic-radio" type="radio" name="sfhf" id="R_ALL" value="all" checked="checked" />
                <label for="R_ALL">全部</label>
                <input class="magic-radio" type="radio" name="sfhf" id="R_WHF" value="0" />
                <label for="R_WHF">未回访</label>
                <input class="magic-radio" type="radio" name="sfhf" id="R_HF" value="1" />
                <label for="R_HF">已回访</label>
            </div>
        </div>
        <div class="bffld">
            <div class="bffld_left">活动名称</div>
            <div class="bffld_right">
                <select id="S_HDID">
                    <option></option>
                </select>
            </div>
        </div>
    </div>
    <div class="bfrow">
        <div class="bffld">
            <div class="bffld_left">会员卡号</div>
            <div class="bffld_right">
                <input id="TB_HYK_NO" type="text" />
            </div>
        </div>
        <div class="bffld">
            <div class="bffld_left">姓名</div>
            <div class="bffld_right">
                <input id="TB_GKNAME" type="text" />
            </div>
        </div>
    </div>
        <div class="bfrow">
        <div class="bffld">
            <div class="bffld_left">回访时间</div>
            <div class="bffld_right twodate">
                <input id="TB_HFSJ1" type="text" class="Wdate" onfocus="WdatePicker({isShowWeek:true})" />
                <span class="Wdate_span">至</span>
                <input id="TB_HFSJ2" type="text" class="Wdate" onfocus="WdatePicker({isShowWeek:true})" />
            </div>
        </div>
    </div>

    <%=V_SearchBodyEnd %>
</body>
</html>
