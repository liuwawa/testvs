﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRMREPORT_SQXQXFFX.aspx.cs" Inherits="BF.CrmWeb.CRMREPORT.SQXQXFFX.CRMREPORT_SQXQXFFX" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=V_HeadConfig %>
    <script src="../../CrmLib/CrmLib_GetHYXX.js"></script>
    <script src="CRMREPORT_SQXQXFFX.js"></script>
    <script type="text/javascript">
        vPageMsgID = <%=CM_CRMREPORT_SQXQXFFX%>;
    </script>
    <script type="text/javascript">
        var $ = jQuery.noConflict();
        $(function () {
            $('#tabsmenu').tabify();
            $(".toggle_container").hide();
            $(".trigger").click(function () {
                $(this).toggleClass("active").next().slideToggle("slow");
                return false;
            });
        });        
    </script>
</head>
<body>
<div id="panelwrap">
        <div class="center_content">
            <div id="right_wrap">
                <div id="right_content">
                    <div id="btn-toolbar">
                    </div>
                    <ul id="tabsmenu" class="tabsmenu">
                        <li class="active"><a href="#tab1">商圈小区消费分析</a></li>
                    </ul>
                    <div id="tab1" class="tabcontent">
                        日期
                        <input id="TB_RQ1" type="text" class="Wdate"  />
                        ----------
                        <input id="TB_RQ2" type="text" class="Wdate"  />
                         <br />
                        同期
                        <input id="TB_TQ1" type="text" class="Wdate" onfocus="WdatePicker({isShowWeek:true})"/>
                        ----------
                        <input id="TB_TQ2" type="text" class="Wdate" onfocus="WdatePicker({isShowWeek:true})"/>
                        <br />
                        商户
                        <select id="cbSH" onchange="SHChange()">
                            <option></option>
                        </select>
                        门店名称
                        <input type="text" id="TB_MDMC" />
                        <input type="hidden" id="HF_MDID" />
                        <input type="hidden" id="zHF_MDID" />
                        <input id="btnSrch1" type="button" value="查询" onclick="btnSrch1Click()" />
                        <iframe class="iFrame" id="fr1" frameborder="no" style="height: 500px; width: 960px"></iframe>
                    </div>
                    <div class="clear"></div>
                </div>
            </div>
        </div>
        <div class="clear"></div>
    </div>
</body>
</html>
