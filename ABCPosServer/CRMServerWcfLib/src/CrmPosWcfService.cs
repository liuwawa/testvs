﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ChangYi.Pub;
using ChangYi.Crm.Server;

namespace ChangYi.Crm.Server.Wcf
{
    public class POSService : IPOSService
    {
        public POSService()
        {
            CrmServerPlatform.InitiateData();
        }

        public bool GetVipCard(out string msg, out VipCard vipCard, int condType, string condValue, string cardCodeToCheck, string verifyCode)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            vipCard = null;
            CrmVipCard crmCard = null;
            bool ok = false;
            try
            {
                ok = PosProc.GetVipCard(out msg, out crmCard, condType, condValue, cardCodeToCheck, verifyCode);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }
            if (ok)
            {
                vipCard = new VipCard();
                vipCard.CardId = crmCard.CardId;
                vipCard.CardTypeId = crmCard.CardTypeId;
                vipCard.CardCode = crmCard.CardCode;
                vipCard.VipName = crmCard.VipName;
                vipCard.CardTypeName = crmCard.CardTypeName;
                vipCard.CanCent = crmCard.CanCent;
                vipCard.CanDisc = crmCard.CanDisc;
                vipCard.CanReturn = crmCard.CanReturn;
                vipCard.CanOwnCoupon = crmCard.CanOwnCoupon;
                vipCard.ValidCent = crmCard.ValidCent;
                vipCard.YearCent = crmCard.YearCent;
                vipCard.StageCent = crmCard.StageCent;
                vipCard.Hello = crmCard.Hello;
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" GetVipCard Request, ");
            logStr.Append("\r\n    condType=").Append(condType).Append(", condValue=").Append(condValue).Append(", cardCodeToCheck=").Append(cardCodeToCheck).Append(", verifyCode=").Append(verifyCode);
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    vipCard=");
                vipCard.Log(logStr);
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool UpdateVipInfo(out string msg, VipInfoUpdated vipInfo)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            bool ok = false;

            CrmVipInfo crmVipInfo = new CrmVipInfo();
            crmVipInfo.CardId = vipInfo.CardId;
            crmVipInfo.EMail = vipInfo.EMail;
            crmVipInfo.Address = vipInfo.Address;
            crmVipInfo.Mobile = vipInfo.Mobile;
            try
            {
                ok = PosProc.UpdateVipInfo(out msg, crmVipInfo);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }
            
            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" UpdateVipInfo Request, ");
            logStr.Append("\r\n    vipInfo=");
            vipInfo.Log(logStr);
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool UpdateVipCent(out string msg, int vipId, double updateCent, int updateType, string storeCode, string posId, int billId)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            bool ok = false;

            CrmStoreInfo storeInfo = new CrmStoreInfo();
            storeInfo.StoreCode = storeCode;
            try
            {
                ok = PosProc.UpdateVipCent(out msg, vipId, updateCent, updateType, storeInfo, posId, billId);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" UpdateVipInfo Request, ");
            logStr.Append("\r\n    vipId=").Append(vipId).Append(", updateCent=").Append(updateCent).Append(", updateType=").Append(updateType);
            logStr.Append(", storeCode=").Append(storeCode).Append(", posId=").Append(posId).Append(", billId=").Append(billId);
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool GetArticleVipDisc(out string msg, out ArticleVipDisc[] discs, int vipId, int vipType, string storeCode, DeptArticleCode[] articles)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            discs = null;
            List<CrmArticle> articleList = new List<CrmArticle>();
            foreach (DeptArticleCode articleCode in articles)
            {
                CrmArticle article = new CrmArticle();
                articleList.Add(article);
                article.ArticleId = 0;
                article.ArticleCode = articleCode.ArticleCode;
                article.DeptCode = articleCode.DeptCode;
            }
            CrmStoreInfo storeInfo = new CrmStoreInfo();
            storeInfo.StoreCode = storeCode;
            bool ok = false;
            try
            {
                ok = PosProc.GetArticleVipDisc(out msg, vipId, vipType, storeInfo, articleList);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }
            if (ok)
            {
                discs = new ArticleVipDisc[articleList.Count()];
                for (int i = 0; i < articleList.Count(); i++)
                {
                    CrmArticle crmArticle = articleList[i];
                    discs[i] = new ArticleVipDisc();
                    discs[i].DiscBillId = crmArticle.VipDiscBillId;
                    discs[i].DiscRate = crmArticle.VipDiscRate;
                    discs[i].PrecisionType = crmArticle.VipDiscPrecisionType;
                    discs[i].MultiDiscRate = crmArticle.VipMultiDiscRate;
                    discs[i].DiscCombinationType = crmArticle.VipDiscCombinationType;
                }
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" GetArticleVipDisc Request, ");
            logStr.Append("\r\n    vipId=").Append(vipId).Append(", vipType=").Append(vipType).Append(", storeCode=").Append(storeCode);
            logStr.Append("\r\n    articles: ");
            foreach (DeptArticleCode articleCode in articles)
            {
                logStr.Append("\r\n        ");
                articleCode.Log(logStr);
            }
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    discs: ");
                foreach (ArticleVipDisc disc in discs)
                {
                    logStr.Append("\r\n        ");
                    disc.Log(logStr);
                }
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool GetCashCard(out string msg, out CashCard cashCard, int condType, string condValue, string cardCodeToCheck, string verifyCode, string password, string storeCode)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            cashCard = null;
            CrmCashCard crmCard = null;
            CrmStoreInfo storeInfo = new CrmStoreInfo();
            storeInfo.StoreCode = storeCode;
            bool ok = false;
            try
            {
                int cardAreaId = 0;
                ok = PosProc.GetCashCard(out msg,out cardAreaId, out crmCard, condType, condValue, cardCodeToCheck, verifyCode, password,false, storeInfo);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }
            if (ok)
            {
                cashCard = new CashCard();
                cashCard.CardId = crmCard.CardId;
                cashCard.CardTypeId = crmCard.CardTypeId;
                cashCard.CardCode = crmCard.CardCode;
                cashCard.Balance = crmCard.Balance;
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" GetCashCard Request, ");
            logStr.Append("\r\n    condType=").Append(condType).Append(", condValue=").Append(condValue).Append(", cardCodeToCheck=").Append(cardCodeToCheck).Append(", verifyCode=").Append(verifyCode).Append(", password=").Append(password).Append(", storeCode=").Append(storeCode);
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    cashCard=");
                cashCard.Log(logStr);
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool GetVipCoupon(out string msg, out int vipId, out string vipCode, out Coupon[] coupons, int condType, string condValue, string cardCodeToCheck, string verifyCode,string storeCode, bool requireValidDate)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            vipId = 0;
            vipCode = string.Empty;
            coupons = null;
            List<CrmCoupon> listCrmCoupon = new List<CrmCoupon>();
            CrmStoreInfo storeInfo = new CrmStoreInfo();
            storeInfo.StoreCode = storeCode;
            bool ok = false;
            try
            {
                ok = PosProc.GetVipCoupon(out msg, out vipId, out vipCode, listCrmCoupon, condType, condValue, cardCodeToCheck, verifyCode, storeInfo, requireValidDate);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }
            if (ok)
            {
                coupons = new Coupon[listCrmCoupon.Count()];
                for (int i = 0; i < listCrmCoupon.Count(); i++)
                {
                    CrmCoupon crmCoupon = listCrmCoupon[i];
                    coupons[i] = new Coupon();
                    coupons[i].CouponType = crmCoupon.CouponType;
                    coupons[i].CouponTypeName = crmCoupon.CouponTypeName;
                    coupons[i].Balance = crmCoupon.Balance;
                }
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" GetVipCoupon Request, ");
            logStr.Append("\r\n    condType=").Append(condType).Append(", condValue=").Append(condValue).Append(", cardCodeToCheck=").Append(cardCodeToCheck).Append(", verifyCode=").Append(verifyCode).Append(", storeCode=").Append(storeCode).Append(", requireValidDate=").Append(requireValidDate);
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    vipId=").Append(vipId).Append(", vipCode=").Append(vipCode);
                logStr.Append("\r\n    coupons: ");
                foreach (Coupon coupon in coupons)
                {
                    logStr.Append("\r\n        ");
                    coupon.Log(logStr);
                }
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool GetVipCouponToPay(out string msg, out int vipId, out string vipCode, out Coupon[] coupons, out CouponPayLimit[] payLimits, int condType, string condValue, string cardCodeToCheck, string verifyCode, string storeCode, int serverBillId)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            vipId = 0;
            vipCode = string.Empty;
            coupons = null;
            payLimits = null;
            List<CrmCoupon> listCrmCoupon = new List<CrmCoupon>();
            List<CrmCouponPayLimit> listCrmPayLimit = new List<CrmCouponPayLimit>();
            CrmStoreInfo storeInfo = new CrmStoreInfo();
            storeInfo.StoreCode = storeCode;
            bool ok = false;
            try
            {
                ok = PosProc.GetVipCouponToPay(out msg, out vipId, out vipCode, listCrmCoupon, listCrmPayLimit, condType, condValue, cardCodeToCheck, verifyCode, storeInfo, serverBillId);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }
            if (ok)
            {
                coupons = new Coupon[listCrmCoupon.Count()];
                for (int i = 0; i < listCrmCoupon.Count(); i++)
                {
                    CrmCoupon crmCoupon = listCrmCoupon[i];
                    coupons[i] = new Coupon();
                    coupons[i].CouponType = crmCoupon.CouponType;
                    coupons[i].CouponTypeName = crmCoupon.CouponTypeName;
                    coupons[i].Balance = crmCoupon.Balance;
                }
                payLimits = new CouponPayLimit[listCrmPayLimit.Count()];
                for (int i = 0; i < listCrmPayLimit.Count(); i++)
                {
                    CrmCouponPayLimit crmPayLimit = listCrmPayLimit[i];
                    payLimits[i] = new CouponPayLimit();
                    payLimits[i].CouponType = crmPayLimit.CouponType;
                    payLimits[i].LimitMoney = crmPayLimit.LimitMoney;
                }
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" GetVipCouponToPay Request, ");
            logStr.Append("\r\n    condType=").Append(condType).Append(", condValue=").Append(condValue).Append(", cardCodeToCheck=").Append(cardCodeToCheck).Append(", verifyCode=").Append(verifyCode).Append(", storeCode=").Append(storeCode).Append(", serverBillId=").Append(serverBillId);
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    vipId=").Append(vipId).Append(", vipCode=").Append(vipCode);
                logStr.Append("\r\n    coupons: ");
                foreach (Coupon coupon in coupons)
                {
                    logStr.Append("\r\n        ");
                    coupon.Log(logStr);
                }
                logStr.Append("\r\n    payLimits: ");
                foreach (CouponPayLimit payLimit in payLimits)
                {
                    logStr.Append("\r\n        ");
                    payLimit.Log(logStr);
                }
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool GetVipCouponPayLimit(out string msg, out CouponPayLimit[] payLimits, int vipType, int serverBillId, int[] couponTypes)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            payLimits = null;
            List<CrmCouponPayLimit> listCrmPayLimit = new List<CrmCouponPayLimit>();
            bool ok = false;
            try
            {
                ok = PosProc.GetVipCouponPayLimit(out msg, listCrmPayLimit, vipType, serverBillId, couponTypes);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }
            if (ok)
            {
                payLimits = new CouponPayLimit[listCrmPayLimit.Count()];
                for (int i = 0; i < listCrmPayLimit.Count(); i++)
                {
                    CrmCouponPayLimit crmPayLimit = listCrmPayLimit[i];
                    payLimits[i] = new CouponPayLimit();
                    payLimits[i].CouponType = crmPayLimit.CouponType;
                    payLimits[i].LimitMoney = crmPayLimit.LimitMoney;
                }
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" GetVipCouponToPay Request, ");
            logStr.Append("\r\n    vipType=").Append(vipType).Append(", serverBillId=").Append(serverBillId).Append(", couponTypes=").Append(couponTypes.ToString());
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    payLimits: ");
                foreach (CouponPayLimit payLimit in payLimits)
                {
                    logStr.Append("\r\n        ");
                    payLimit.Log(logStr);
                }
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool PrepareTransCashCardPayment(out string msg, out int transId, int serverBillId, CashCardPayment[] payments)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            transId = 0;
            CrmRSaleBillHead billHead = new CrmRSaleBillHead();
            billHead.ServerBillId = serverBillId;
            List<CrmCashCardPayment> listCrmPayment = new List<CrmCashCardPayment>();
            foreach (CashCardPayment payment in payments)
            {
                CrmCashCardPayment crmPayment = new CrmCashCardPayment();
                listCrmPayment.Add(crmPayment);
                crmPayment.CardId = payment.CardId;
                crmPayment.PayMoney = payment.PayMoney;
            }
            bool ok = false;
            try
            {
                ok = PosProc.PrepareTransCashCardPayment(out msg, out transId, billHead, listCrmPayment);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" PrepareTransCashCardPayment Request, ");
            logStr.Append("\r\n    serverBillId=").Append(serverBillId);
            logStr.Append("\r\n    payments: ");
            foreach (CashCardPayment payment in payments)
            {
                logStr.Append("\r\n        ");
                payment.Log(logStr);
            }
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    transId=").Append(transId);
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool ConfirmTransCashCardPayment(out string msg, int transId, int serverBillId, double transMoney)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            bool ok = false;
            try
            {
                ok = PosProc.ConfirmTransCashCardPayment(out msg, transId, serverBillId, transMoney);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" ConfirmTransCashCardPayment Request, ");
            logStr.Append("\r\n    transId=").Append(transId).Append(", serverBillId=").Append(serverBillId).Append(", transMoney=").Append(transMoney);
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms.");
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool PrepareTransCashCardPayment2(out string msg, out int transId, string storeCode, string posId, int billId, string cashier, DateTime accountDate, CashCardPayment[] payments)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            transId = 0;
            CrmRSaleBillHead billHead = new CrmRSaleBillHead();
            billHead.ServerBillId = 0;
            billHead.StoreCode = storeCode;
            billHead.PosId = posId;
            billHead.BillId = billId;
            billHead.Cashier = cashier;
            billHead.AccountDate = accountDate;

            List<CrmCashCardPayment> listCrmPayment = new List<CrmCashCardPayment>();
            foreach (CashCardPayment payment in payments)
            {
                CrmCashCardPayment crmPayment = new CrmCashCardPayment();
                listCrmPayment.Add(crmPayment);
                crmPayment.CardId = payment.CardId;
                crmPayment.PayMoney = payment.PayMoney;
            }

            bool ok = false;
            try
            {
                ok = PosProc.PrepareTransCashCardPayment(out msg, out transId, billHead, listCrmPayment);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" PrepareTransCashCardPayment2 Request, ");
            logStr.Append("\r\n    storeCode=").Append(storeCode).Append(", posId=").Append(posId).Append(", billId=").Append(billId).Append(", cashier=").Append(cashier).Append(", accountDate=").Append(accountDate);
            logStr.Append("\r\n    payments: ");
            foreach (CashCardPayment payment in payments)
            {
                logStr.Append("\r\n        ");
                payment.Log(logStr);
            }
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    transId=").Append(transId);
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool CancelTransCashCardPayment(out string msg, int transId, int serverBillId, double transMoney)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            bool ok = false;
            try
            {
                ok = PosProc.CancelTransCashCardPayment(out msg, transId, serverBillId, transMoney);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" CancelTransCashCardPayment Request, ");
            logStr.Append("\r\n    transId=").Append(transId).Append(", serverBillId=").Append(serverBillId).Append(", transMoney=").Append(transMoney);
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms.");
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool PrepareTransCouponPayment(out string msg, out int transId, int serverBillId, CouponPayment[] payments)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            transId = 0;
            CrmRSaleBillHead billHead = new CrmRSaleBillHead();
            billHead.ServerBillId = serverBillId;
            List<CrmCouponPayment> listCrmPayment = new List<CrmCouponPayment>();
            foreach (CouponPayment payment in payments)
            {
                CrmCouponPayment crmPayment = new CrmCouponPayment();
                listCrmPayment.Add(crmPayment);
                crmPayment.VipId = payment.VipId;
                crmPayment.CouponType = payment.CouponType;
                crmPayment.PayMoney = payment.PayMoney;

            }

            bool ok = false;
            double payCent = 0;
            try
            {
                ok = PosProc.PrepareTransCouponPayment(out msg, out transId,out payCent, billHead, listCrmPayment);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" PrepareTransCouponPayment Request, ");
            logStr.Append("\r\n    serverBillId=").Append(serverBillId);
            logStr.Append("\r\n    payments: ");
            foreach (CouponPayment payment in payments)
            {
                logStr.Append("\r\n        ");
                payment.Log(logStr);
            }
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    transId=").Append(transId);
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool PrepareTransCouponPayment2(out string msg, out int transId, string storeCode, string posId, int billId, string cashier, DateTime accountDate, CouponPayment[] payments)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            transId = 0;
            CrmRSaleBillHead billHead = new CrmRSaleBillHead();
            billHead.ServerBillId = 0;
            billHead.StoreCode = storeCode;
            billHead.PosId = posId;
            billHead.BillId = billId;
            billHead.Cashier = cashier;
            billHead.AccountDate = accountDate;

            List<CrmCouponPayment> listCrmPayment = new List<CrmCouponPayment>();
            foreach (CouponPayment payment in payments)
            {
                CrmCouponPayment crmPayment = new CrmCouponPayment();
                listCrmPayment.Add(crmPayment);
                crmPayment.VipId = payment.VipId;
                crmPayment.CouponType = payment.CouponType;
                crmPayment.PayMoney = payment.PayMoney;

            }
            bool ok = false;
            double payCent = 0;
            try
            {
                ok = PosProc.PrepareTransCouponPayment(out msg, out transId,out payCent, billHead, listCrmPayment);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" PrepareTransCouponPayment2 Request, ");
            logStr.Append("\r\n    storeCode=").Append(storeCode).Append(", posId=").Append(posId).Append(", billId=").Append(billId).Append(", cashier=").Append(cashier).Append(", accountDate=").Append(accountDate);
            logStr.Append("\r\n    payments: ");
            foreach (CouponPayment payment in payments)
            {
                logStr.Append("\r\n        ");
                payment.Log(logStr);
            }
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    transId=").Append(transId);
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool ConfirmTransCouponPayment(out string msg, int transId, int serverBillId, double transMoney)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;

            bool ok = false;
            try
            {
                ok = PosProc.ConfirmTransCouponPayment(out msg, transId, serverBillId, transMoney);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" ConfirmTransCouponPayment Request, ");
            logStr.Append("\r\n    transId=").Append(transId).Append(", serverBillId=").Append(serverBillId).Append(", transMoney=").Append(transMoney);
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms.");
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool CancelTransCouponPayment(out string msg, int transId, int serverBillId, double transMoney)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;

            bool ok = false;
            try
            {
                ok = PosProc.CancelTransCouponPayment(out msg, transId, serverBillId, transMoney);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" CancelTransCouponPayment Request, ");
            logStr.Append("\r\n    transId=").Append(transId).Append(", serverBillId=").Append(serverBillId).Append(", transMoney=").Append(transMoney);
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms.");
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool SaveRSaleBillArticles(out string msg, out int serverBillId, out double decMoney, out RSaleBillArticleDecMoney[] articleDecMoneys, out RSaleBillArticlePromFlag[] articlePromFlags, RSaleBillHead billHead, RSaleBillArticle[] billArticles)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            serverBillId = 0;
            decMoney = 0;
            articleDecMoneys = null;
            articlePromFlags = null;
            CrmRSaleBillHead crmBillHead = new CrmRSaleBillHead();
            crmBillHead.StoreCode = billHead.StoreCode;
            crmBillHead.PosId = billHead.PosId.ToString();
            crmBillHead.BillId = billHead.BillId;
            crmBillHead.BillType = billHead.BillType;
            crmBillHead.VipId = billHead.VipId;
            crmBillHead.SaleTime = FormatUtils.ParseDatetimeString(billHead.SaleTime);
            crmBillHead.AccountDate = FormatUtils.ParseDateString(billHead.AccountDate);
            crmBillHead.OfferCouponDate = crmBillHead.SaleTime.Date;
            crmBillHead.Cashier = billHead.Cashier;

            List<CrmArticle> listCrmArticle = new List<CrmArticle>();
            foreach (RSaleBillArticle article in billArticles)
            {
                CrmArticle crmArticle = new CrmArticle();
                listCrmArticle.Add(crmArticle);
                crmArticle.Inx = article.Inx;
                crmArticle.DeptCode = article.DeptCode;
                crmArticle.ArticleCode = article.ArticleCode;
                crmArticle.SaleNum = article.SaleNum;
                crmArticle.SaleMoney = article.SaleMoney;
                crmArticle.DiscMoney = article.DiscMoney;
                crmArticle.VipDiscMoney = article.VipDiscMoney;
                crmArticle.VipDiscRate = article.VipDiscRate;
                crmArticle.VipDiscBillId = article.VipDiscBillId;
                crmArticle.IsNoCent = article.IsNoCent;
                crmArticle.IsNoProm = article.IsNoProm;
            }
            bool ok = false;
            try
            {
                ok = PosProc.SaveRSaleBillArticles(out msg, crmBillHead, listCrmArticle, null, null);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }
            if (ok)
            {
                serverBillId = crmBillHead.ServerBillId;
                decMoney = crmBillHead.TotalDecMoney;
                List<RSaleBillArticleDecMoney> listDecMoney = new List<RSaleBillArticleDecMoney>();
                List<RSaleBillArticlePromFlag> listPromFlag = new List<RSaleBillArticlePromFlag>();
                for (int i = 0; i < listCrmArticle.Count(); i++)
                {
                    CrmArticle crmArticle = listCrmArticle[i];
                    RSaleBillArticlePromFlag promFlag = new RSaleBillArticlePromFlag();
                    listPromFlag.Add(promFlag);
                    promFlag.ArticleInx = crmArticle.Inx;
                    promFlag.JoinPromCent = crmArticle.JoinPromCent;
                    promFlag.JoinOfferCoupon = crmArticle.JoinOfferCoupon;
                    promFlag.JoinDecMoney = (crmArticle.DecMoneyRuleId > 0);
                    if (!MathUtils.DoubleAEuqalToDoubleB(crmArticle.DecMoney, 0))
                    {
                        RSaleBillArticleDecMoney articleDecM = new RSaleBillArticleDecMoney();
                        listDecMoney.Add(articleDecM);
                        articleDecM.ArticleInx = crmArticle.Inx;
                        articleDecM.DecMoney = crmArticle.DecMoney;
                    }
                }
                if (listDecMoney.Count() > 0)
                    articleDecMoneys = listDecMoney.ToArray();
                if (listPromFlag.Count() > 0)
                    articlePromFlags = listPromFlag.ToArray();
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" SaveRSaleBillArticles Request, ");
            logStr.Append("\r\n    billHead=");
            billHead.Log(logStr);
            logStr.Append("\r\n    billArticles: ");
            foreach (RSaleBillArticle article in billArticles)
            {
                logStr.Append("\r\n        ");
                article.Log(logStr);
            }
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    serverBillId=").Append(serverBillId).Append(", decMoney=").Append(decMoney);
                logStr.Append("\r\n    articleDecMoneys: ");
                if (articleDecMoneys == null)
                    logStr.Append("null");
                else
                {
                    foreach (RSaleBillArticleDecMoney articleDecM in articleDecMoneys)
                    {
                        logStr.Append("\r\n        ");
                        articleDecM.Log(logStr);
                    }
                }
                logStr.Append("\r\n    articlePromFlags: ");
                if (articlePromFlags == null)
                    logStr.Append("null");
                else
                {
                    foreach (RSaleBillArticlePromFlag articlePromFlag in articlePromFlags)
                    {
                        logStr.Append("\r\n        ");
                        articlePromFlag.Log(logStr);
                    }
                }
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool SaveRSaleBackBillArticles(out string msg, out int serverBillId, out OfferBackCoupon[] offerBackCoupons, out CouponPayback[] paybackCoupons, RSaleBillHead billHead, RSaleBillArticle[] billArticles)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            serverBillId = 0;
            offerBackCoupons = null;
            paybackCoupons = null;
            CrmRSaleBillHead crmBillHead = new CrmRSaleBillHead();
            crmBillHead.StoreCode = billHead.StoreCode;
            crmBillHead.PosId = billHead.PosId;
            crmBillHead.BillId = billHead.BillId;
            crmBillHead.BillType = billHead.BillType;
            crmBillHead.VipId = billHead.VipId;
            crmBillHead.SaleTime = FormatUtils.ParseDatetimeString(billHead.SaleTime);
            crmBillHead.AccountDate = FormatUtils.ParseDateString(billHead.AccountDate);
            crmBillHead.OfferCouponDate = crmBillHead.SaleTime.Date;
            crmBillHead.Cashier = billHead.Cashier;

            List<CrmArticle> listCrmArticle = new List<CrmArticle>();
            foreach (RSaleBillArticle article in billArticles)
            {
                CrmArticle crmArticle = new CrmArticle();
                listCrmArticle.Add(crmArticle);
                crmArticle.Inx = article.Inx;
                crmArticle.DeptCode = article.DeptCode;
                crmArticle.ArticleCode = article.ArticleCode;
                crmArticle.SaleNum = article.SaleNum;
                crmArticle.SaleMoney = article.SaleMoney;
                crmArticle.DiscMoney = article.DiscMoney;
                crmArticle.VipDiscMoney = article.VipDiscMoney;
                crmArticle.VipDiscRate = article.VipDiscRate;
                crmArticle.VipDiscBillId = article.VipDiscBillId;
                crmArticle.IsNoCent = article.IsNoCent;
                crmArticle.IsNoProm = article.IsNoProm;
            }
            bool ok = false;
            List<CrmCouponPayment> payBackCouponList = new List<CrmCouponPayment>();
            List<CrmPromOfferCoupon> offerBackCouponList = new List<CrmPromOfferCoupon>();
            try
            {
                ok = PosProc.SaveRSaleBillArticles(out msg, crmBillHead, listCrmArticle, payBackCouponList, offerBackCouponList);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }
            if (ok)
            {
                List<RSaleBillArticleDecMoney> listDecMoney = new List<RSaleBillArticleDecMoney>();
                List<RSaleBillArticlePromFlag> listPromFlag = new List<RSaleBillArticlePromFlag>();
                for (int i = 0; i < listCrmArticle.Count(); i++)
                {
                    CrmArticle crmArticle = listCrmArticle[i];
                    RSaleBillArticlePromFlag promFlag = new RSaleBillArticlePromFlag();
                    listPromFlag.Add(promFlag);
                    promFlag.ArticleInx = crmArticle.Inx;
                    promFlag.JoinPromCent = crmArticle.JoinPromCent;
                    promFlag.JoinOfferCoupon = crmArticle.JoinOfferCoupon;
                    promFlag.JoinDecMoney = (crmArticle.DecMoneyRuleId > 0);
                    if (!MathUtils.DoubleAEuqalToDoubleB(crmArticle.DecMoney, 0))
                    {
                        RSaleBillArticleDecMoney articleDecM = new RSaleBillArticleDecMoney();
                        listDecMoney.Add(articleDecM);
                        articleDecM.ArticleInx = crmArticle.Inx;
                        articleDecM.DecMoney = crmArticle.DecMoney;
                    }
                }
                //if (listDecMoney.Count() > 0)
                //    articleDecMoneys = listDecMoney.ToArray();
                //if (listPromFlag.Count() > 0)
                //    articlePromFlags = listPromFlag.ToArray();
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" SaveRSaleBackBillArticles Request, ");
            logStr.Append("\r\n    billHead=");
            billHead.Log(logStr);
            logStr.Append("\r\n    billArticles: ");
            foreach (RSaleBillArticle article in billArticles)
            {
                logStr.Append("\r\n        ");
                article.Log(logStr);
            }
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    serverBillId=").Append(serverBillId);
                logStr.Append("\r\n    articleDecMoneys: ");
                //if (articleDecMoneys == null)
                //    logStr.Append("null");
                //else
                //{
                //    foreach (RSaleBillArticleDecMoney articleDecM in articleDecMoneys)
                //    {
                //        logStr.Append("\r\n        ");
                //        articleDecM.Log(logStr);
                //    }
                //}
                //logStr.Append("\r\n    articlePromFlags: ");
                //if (articlePromFlags == null)
                //    logStr.Append("null");
                //else
                //{
                //    foreach (RSaleBillArticlePromFlag articlePromFlag in articlePromFlags)
                //    {
                //        logStr.Append("\r\n        ");
                //        articlePromFlag.Log(logStr);
                //    }
                //}
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }
        public bool CalcRSaleBillDecMoney(out string msg, out double decMoney, out RSaleBillArticleDecMoney[] articleDecMoneys, int serverBillId, RSaleBillPayment[] payments)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            decMoney = 0;
            articleDecMoneys = null;
            List<CrmArticle> listCrmArticle = new List<CrmArticle>();
            List<CrmPayment> listCrmPayment = new List<CrmPayment>();
            foreach (RSaleBillPayment payment in payments)
            {
                CrmPayment crmPayment = new CrmPayment();
                listCrmPayment.Add(crmPayment);
                crmPayment.PayTypeCode = payment.PayTypeCode;
                crmPayment.PayMoney = payment.PayMoney;
            }

            bool ok = false;
            try
            {
                ok = PosProc.CalcRSaleBillDecMoney(out msg, out decMoney, listCrmArticle, serverBillId, listCrmPayment);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }
            if (ok)
            {
                List<RSaleBillArticleDecMoney> listDecMoney = new List<RSaleBillArticleDecMoney>();
                for (int i = 0; i < listCrmArticle.Count(); i++)
                {
                    CrmArticle crmArticle = listCrmArticle[i];
                    if (!MathUtils.DoubleAEuqalToDoubleB(crmArticle.DecMoney, 0))
                    {
                        RSaleBillArticleDecMoney articl = new RSaleBillArticleDecMoney();
                        listDecMoney.Add(articl);
                        articl.ArticleInx = crmArticle.Inx;
                        articl.DecMoney = crmArticle.DecMoney;
                    }
                }
                if (listDecMoney.Count() > 0)
                    articleDecMoneys = listDecMoney.ToArray();
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" CalcRSaleBillDecMoney Request, ");
            logStr.Append("\r\n    serverBillId=").Append(serverBillId);
            logStr.Append("\r\n    payments: ");
            foreach (RSaleBillPayment payment in payments)
            {
                logStr.Append("\r\n        ");
                payment.Log(logStr);
            }
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    decMoney=").Append(decMoney);
                logStr.Append("\r\n    articleDecMoneys: ");
                if (articleDecMoneys == null)
                    logStr.Append("null");
                else
                {
                    foreach (RSaleBillArticleDecMoney articleDecM in articleDecMoneys)
                    {
                        logStr.Append("\r\n        ");
                        articleDecM.Log(logStr);
                    }
                }
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool PrepareCheckOutRSaleBill(out string msg, out double billCent, out RSaleBillArticleCent[] articleCents, out RSaleBillArticleCoupon[] articleCoupons, int serverBillId, RSaleBillPayment[] payments, bool couponPaid)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            billCent = 0;
            articleCents = null;
            articleCoupons = null;
            List<CrmArticle> crmArticleList = new List<CrmArticle>();
            List<CrmPayment> crmPaymentList = new List<CrmPayment>();
            foreach (RSaleBillPayment payment in payments)
            {
                CrmPayment crmPayment = new CrmPayment();
                crmPaymentList.Add(crmPayment);
                crmPayment.PayTypeCode = payment.PayTypeCode;
                crmPayment.PayMoney = payment.PayMoney;
            }
            List<CrmPaymentArticleShare> couponArticleShareList = new List<CrmPaymentArticleShare>();
            bool needBuyCent = false;
            bool needVipToOfferCoupon = false;
            bool ok = false;
            try
            {
                string offerCouponVipCode = string.Empty;
                ok = PosProc.PrepareCheckOutRSaleBill(out msg, out billCent, out needVipToOfferCoupon, out needBuyCent, out offerCouponVipCode, crmArticleList, couponArticleShareList, null, null, serverBillId, crmPaymentList, 0, couponPaid);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }

            if (ok)
            {
                articleCents = new RSaleBillArticleCent[crmArticleList.Count()];
                for (int i = 0; i < crmArticleList.Count(); i++)
                {
                    CrmArticle crmArticle = crmArticleList[i];
                    RSaleBillArticleCent articleCent = new RSaleBillArticleCent();
                    articleCents[i] = articleCent;
                    articleCent.ArticleInx = crmArticle.Inx;
                    articleCent.Cent = crmArticle.GainedCent;
                }
                if ((couponArticleShareList != null) && (couponArticleShareList.Count > 0))
                {
                    List<RSaleBillArticleCoupon> articleCouponList = new List<RSaleBillArticleCoupon>();
                    foreach (CrmPaymentArticleShare share in couponArticleShareList)
                    {
                        if (share.Payment.CouponType >= 0)
                        {
                            RSaleBillArticleCoupon articleCoupon = new RSaleBillArticleCoupon();
                            articleCouponList.Add(articleCoupon);
                            articleCoupon.ArticleInx = share.Article.Inx;
                            articleCoupon.CouponType = share.Payment.CouponType;
                            articleCoupon.SharedMoney = share.ShareMoney;
                        }
                    }
                    if (articleCouponList.Count() > 0)
                        articleCoupons = articleCouponList.ToArray();
                }
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" PrepareCheckOutRSaleBill Request, ");
            logStr.Append("\r\n    serverBillId=").Append(serverBillId).Append(", couponPaid=").Append(couponPaid);
            logStr.Append("\r\n    payments: ");
            foreach (RSaleBillPayment payment in payments)
            {
                logStr.Append("\r\n        ");
                payment.Log(logStr);
            }
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    billCent=").Append(billCent);
                logStr.Append("\r\n    articleCents: ");
                if (articleCents == null)
                    logStr.Append("null");
                else
                {
                    foreach (RSaleBillArticleCent articleCent in articleCents)
                    {
                        logStr.Append("\r\n        ");
                        articleCent.Log(logStr);
                    }
                }
                logStr.Append("\r\n    articleCoupons: ");
                if (articleCoupons == null)
                    logStr.Append("null");
                else
                {
                    foreach (RSaleBillArticleCoupon articleCoupon in articleCoupons)
                    {
                        logStr.Append("\r\n        ");
                        articleCoupon.Log(logStr);
                    }
                }
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }

        public bool CheckOutRSaleBill(out string msg, out double billCent, out double vipCent, out OfferCoupon[] offerCoupons, out SaleMoneyLeftWhenPromCalc[] leftSaleMoneys, int serverBillId)
        {
            DateTime timeBegin = DateTime.Now;

            msg = string.Empty;
            billCent = 0;
            vipCent = 0;
            offerCoupons = null;
            leftSaleMoneys = null;
            List<CrmPromOfferCoupon> listOfferCoupon = new List<CrmPromOfferCoupon>();
            List<CrmSaleMoneyLeftWhenPromCalc> listLeftSaleMoney = new List<CrmSaleMoneyLeftWhenPromCalc>();

            bool ok = false;
            try
            {
                string offerCouponVipCode = string.Empty;
                double vipShopCent = 0;
                double vipCompanyCent = 0;
                ok = PosProc.CheckOutRSaleBill(out msg, out billCent,out vipCent, out vipShopCent, out vipCompanyCent, out offerCouponVipCode, listOfferCoupon, listLeftSaleMoney, serverBillId);
            }
            catch (Exception e)
            {
                if (CrmServerPlatform.Config.ShowErrorDetail)
                    msg = "CRM 服务处理出错 " + e.Message.ToString();
                else
                    msg = "CRM 服务处理出错";
                CrmServerPlatform.WriteErrorLog("\t\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  Server proc error: " + e.Message.ToString());
            }
            if (ok)
            {
                if (listOfferCoupon.Count > 0)
                {
                    offerCoupons = new OfferCoupon[listOfferCoupon.Count];
                    for (int i = 0; i < listOfferCoupon.Count; i++)
                    {
                        CrmPromOfferCoupon crmOfferCoupon = listOfferCoupon[i];
                        offerCoupons[i] = new OfferCoupon();
                        offerCoupons[i].CouponType = crmOfferCoupon.CouponType;
                        offerCoupons[i].CouponTypeName = crmOfferCoupon.CouponTypeName;
                        offerCoupons[i].ValidDate = FormatUtils.DateToString(crmOfferCoupon.ValidDate);
                        offerCoupons[i].OfferMoney = crmOfferCoupon.OfferMoney;
                        offerCoupons[i].Balance = crmOfferCoupon.Balance;
                    }
                }
                if (listLeftSaleMoney.Count > 0)
                {
                    leftSaleMoneys = new SaleMoneyLeftWhenPromCalc[listLeftSaleMoney.Count];
                    for (int i = 0; i < listLeftSaleMoney.Count; i++)
                    {
                        CrmSaleMoneyLeftWhenPromCalc crmSaleMoney = listLeftSaleMoney[i];
                        leftSaleMoneys[i] = new SaleMoneyLeftWhenPromCalc();
                        leftSaleMoneys[i].AddupTypeDesc = crmSaleMoney.AddupTypeDesc;
                        leftSaleMoneys[i].PromotionName = crmSaleMoney.PromotionName;
                        leftSaleMoneys[i].CouponTypeName = crmSaleMoney.CouponTypeName;
                        leftSaleMoneys[i].RuleName = crmSaleMoney.RuleName;
                        leftSaleMoneys[i].SaleMoney = crmSaleMoney.SaleMoney;
                    }
                }
            }

            DateTime timeEnd = DateTime.Now;
            StringBuilder logStr = new StringBuilder();
            logStr.Append("\r\n").Append(timeBegin.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" CheckOutRSaleBill Request, ");
            logStr.Append("\r\n    serverBillId=").Append(serverBillId);
            if (ok)
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response ok, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    billCent=").Append(billCent);
                logStr.Append("\r\n    offerCoupons: ");
                if (offerCoupons == null)
                    logStr.Append("null");
                else
                {
                    foreach (OfferCoupon offerCoupon in offerCoupons)
                    {
                        logStr.Append("\r\n        ");
                        offerCoupon.Log(logStr);
                    }
                }
                logStr.Append("\r\n    saleMoneys: ");
                if (leftSaleMoneys == null)
                    logStr.Append("null");
                else
                {
                    foreach (SaleMoneyLeftWhenPromCalc leftSaleMoney in leftSaleMoneys)
                    {
                        logStr.Append("\r\n        ");
                        leftSaleMoney.Log(logStr);
                    }
                }
            }
            else
            {
                logStr.Append("\r\n").Append(timeEnd.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append(" Response error, ").Append(timeEnd.Subtract(timeBegin).Milliseconds).Append(" ms:");
                logStr.Append("\r\n    ").Append(msg);
            }
            logStr.Append("\r\n");
            CrmServerPlatform.WriteDataLog(timeBegin.ToString("yyyy-MM-dd"), logStr.ToString());

            return ok;
        }
    }
}