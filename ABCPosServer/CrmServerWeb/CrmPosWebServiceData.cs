﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace ChangYi.Crm.Server.Web
{
    public class MyParamValue
    {
        public string Name;
        public string Value;

        public void Log(StringBuilder sb)
        {
            sb.Append(Name).Append("=").Append(Value);
        }
    }

    public class VipCard
    {
        public int CardId;
        public string CardCode;
        public string VipName;
        public int CardTypeId;
        public string CardTypeName;
        public bool CanCent;
        public bool CanOwnCoupon;
        public bool CanDisc;
        //public bool CanReturn;
        public double ValidCent;
        public double YearCent;
        public double StageCent;
        public string Hello;

        public string IdCardCode;
        public string Birthday;
        public int SexType;
        public string Mobile;
        public string Address;
        public string EMail;

        public void Log(StringBuilder sb)
        {
            sb.Append("( CardId=").Append(CardId);
            sb.Append(",CardCode=").Append(CardCode);
            sb.Append(",VipName=").Append(VipName);
            sb.Append(",CardTypeId=").Append(CardTypeId);
            sb.Append(",CardTypeName=").Append(CardTypeName);
            sb.Append(",CanCent=").Append(CanCent);
            sb.Append(",CanOwnCoupon=").Append(CanOwnCoupon);
            sb.Append(",CanDisc=").Append(CanDisc);
            //sb.Append(",CanReturn=").Append(CanReturn);
            sb.Append(",ValidCent=").Append(ValidCent);
            sb.Append(",YearCent=").Append(YearCent);
            sb.Append(",StageCent=").Append(StageCent);
            sb.Append(",Hello=").Append(Hello);
            sb.Append(",IdCardCode=").Append(IdCardCode);
            sb.Append(",SexType=").Append(SexType);
            sb.Append(",Mobile=").Append(Mobile);
            sb.Append(",Address=").Append(Address);
            sb.Append(",EMail=").Append(EMail);
            sb.Append(" )");
        }
    }

    public class VipInfoUpdated
    {
        public int CardId;

        public string Mobile;
        public string Address;
        public string EMail;

        public void Log(StringBuilder sb)
        {
            sb.Append("( CardId=").Append(CardId);
            sb.Append(",Mobile=").Append(Mobile);
            sb.Append(",Address=").Append(Address);
            sb.Append(",EMail=").Append(EMail);
            sb.Append(" )");
        }
    }

    public class CashCard
    {
        public int CardId;
        public string CardCode;
        public int CardTypeId;
        public double Balance;

        public void Log(StringBuilder sb)
        {
            sb.Append("( CardId=").Append(CardId);
            sb.Append(",CardCode=").Append(CardCode);
            sb.Append(",CardTypeId=").Append(CardTypeId);
            sb.Append(",Balance=").Append(Balance);
            sb.Append(" )");
        }
    }


    public class CashCardPayment
    {
        public int CardId;
        public double PayMoney;

        public void Log(StringBuilder sb)
        {
            sb.Append("( CardId=").Append(CardId);
            sb.Append(",PayMoney=").Append(PayMoney);
            sb.Append(" )");
        }
    }

    public class Coupon
    {
        public int CouponType;
        public string CouponTypeName;
        //public string ValidDate;
        public double Balance;

        public void Log(StringBuilder sb)
        {
            sb.Append("( CouponType=").Append(CouponType);
            sb.Append(",CouponTypeName=").Append(CouponTypeName);
            sb.Append(",Balance=").Append(Balance);
            sb.Append(" )");
        }
    }

    public class CouponPayLimit
    {
        public int CouponType;
        public double LimitMoney;
        public void Log(StringBuilder sb)
        {
            sb.Append("( CouponType=").Append(CouponType);
            sb.Append(",LimitMoney=").Append(LimitMoney);
            sb.Append(" )");
        }
    }

    public class CouponPayment
    {
        public int VipId;
        public int CouponType;
        //public string ValidDateStr;
        public double PayMoney;

        public void Log(StringBuilder sb)
        {
            sb.Append("( VipId=").Append(VipId);
            sb.Append(",CouponType=").Append(CouponType);
            sb.Append(",PayMoney=").Append(PayMoney);
            sb.Append(" )");
        }
    }

    public class CouponPayback
    {
        public int CouponType = 0;
        public string CouponTypeName = string.Empty;
        public double PayMoney = 0;

        public void Log(StringBuilder sb)
        {
            sb.Append("( CouponType=").Append(CouponType);
            sb.Append(",CouponTypeName=").Append(CouponTypeName);
            sb.Append(",PayMoney=").Append(PayMoney);
            sb.Append(" )");
        }
    }
    
    public class DeptArticleCode
    {
        public string DeptCode;
        public string ArticleCode;

        public void Log(StringBuilder sb)
        {
            sb.Append("( DeptCode=").Append(DeptCode);
            sb.Append(",ArticleCode=").Append(ArticleCode);
            sb.Append(" )");
        }
    }

    public class ArticleVipDisc
    {
        public double DiscRate;
        public double MultiDiscRate;
        public int PrecisionType;
        public int DiscCombinationType;
        public int DiscBillId;

        public void Log(StringBuilder sb)
        {
            sb.Append("( DiscRate=").Append(DiscRate);
            sb.Append(",MultiDiscRate=").Append(MultiDiscRate);
            sb.Append(",PrecisionType=").Append(PrecisionType);
            sb.Append(",DiscCombinationType=").Append(DiscCombinationType);
            sb.Append(",DiscBillId=").Append(DiscBillId);
            sb.Append(" )");
        }
    }

    public class RSaleBillHead
    {
        public string StoreCode;
        public string PosId;
        public int BillId;
        public int BillType;
        public int VipId;
        public string SaleTime;
        public string AccountDate;
        public string Cashier;
        public string OriginalPosId;
        public int OriginalBillId;

        public void Log(StringBuilder sb)
        {
            sb.Append("StoreCode=").Append(StoreCode);
            sb.Append(",PosId=").Append(PosId);
            sb.Append(",BillId=").Append(BillId);
            sb.Append(",BillType=").Append(BillType);
            sb.Append(",VipId=").Append(VipId);
            sb.Append(",SaleTime=").Append(SaleTime);
            sb.Append(",AccountDate=").Append(AccountDate);
            sb.Append(",Cashier=").Append(Cashier);
            sb.Append(",OriginalPosId=").Append(OriginalPosId);
            sb.Append(",OriginalBillId=").Append(OriginalBillId);
            sb.Append(" )");
        }
    }

    public class RSaleBillArticle
    {
        public int Inx;
        public string DeptCode;
        public string ArticleCode;
        public int ArticleId = 0;

        public double SaleNum;
        public double SaleMoney;
        public double DiscMoney;
        public double VipDiscMoney;
        public double VipDiscRate;
        public int VipDiscBillId;
        public bool IsNoCent;
        public bool IsNoProm;

        public void Log(StringBuilder sb)
        {
            sb.Append("( Inx=").Append(Inx);
            sb.Append(",DeptCode=").Append(DeptCode);
            sb.Append(",ArticleCode=").Append(ArticleCode);
            sb.Append(",ArticleId=").Append(ArticleId);

            sb.Append(",SaleNum=").Append(SaleNum);
            sb.Append(",SaleMoney=").Append(SaleMoney);
            sb.Append(",DiscMoney=").Append(DiscMoney);
            sb.Append(",VipDiscMoney=").Append(VipDiscMoney);
            sb.Append(",VipDiscRate=").Append(VipDiscRate);
            sb.Append(",VipDiscBillId=").Append(VipDiscBillId);
            sb.Append(",IsNoCent=").Append(IsNoCent);
            sb.Append(",IsNoProm=").Append(IsNoProm);
            sb.Append(" )");
        }
    }
    public class RSaleBillPayment
    {
        public string PayTypeCode;
        public double PayMoney;

        public void Log(StringBuilder sb)
        {
            sb.Append("( PayTypeCode=").Append(PayTypeCode);
            sb.Append(",PayMoney=").Append(PayMoney);
            sb.Append(" )");
        }
    }
    public class RSaleBillArticleCoupon
    {
        public int CouponType;
        public int ArticleInx;
        public double SharedMoney;

        public void Log(StringBuilder sb)
        {
            sb.Append("( CouponType=").Append(CouponType);
            sb.Append(",ArticleInx=").Append(ArticleInx);
            sb.Append(",SharedMoney=").Append(SharedMoney);
            sb.Append(" )");
        }
    }

    public class RSaleBillArticleCent
    {
        public int ArticleInx;
        public double Cent;

        public void Log(StringBuilder sb)
        {
            sb.Append("( ArticleInx=").Append(ArticleInx);
            sb.Append(",Cent=").Append(Cent);
            sb.Append(" )");
        }
    }

    public class RSaleBillArticlePromFlag
    {
        public int ArticleInx;
        public bool JoinPromCent;
        public bool JoinOfferCoupon;
        public bool JoinDecMoney;
        public void Log(StringBuilder sb)
        {
            sb.Append("( ArticleInx=").Append(ArticleInx);
            sb.Append(",JoinPromCent=").Append(JoinPromCent);
            sb.Append(",JoinOfferCoupon=").Append(JoinOfferCoupon);
            sb.Append(",JoinDecMoney=").Append(JoinDecMoney);
            sb.Append(" )");
        }
    }
    public class RSaleBillArticleDecMoney
    {
        public int ArticleInx;
        public double DecMoney;
        public bool DecMoneyIsExpense;//20130819LBC

        public void Log(StringBuilder sb)
        {
            sb.Append("( ArticleInx=").Append(ArticleInx);
            sb.Append(",DecMoney=").Append(DecMoney);
            sb.Append(",DecMoneyIsExpense=").Append(DecMoneyIsExpense);
            sb.Append(" )");
        }

    }
    public class OfferCoupon
    {
        public int CouponType;
        public string CouponTypeName;
        public string ValidDate;
        public double OfferMoney;
        public double Balance;

        public void Log(StringBuilder sb)
        {
            sb.Append("( CouponType=").Append(CouponType);
            sb.Append(",CouponTypeName=").Append(CouponTypeName);
            sb.Append(",ValidDate=").Append(ValidDate);
            sb.Append(",GainedMoney=").Append(OfferMoney);
            sb.Append(",Balance=").Append(Balance);
            sb.Append(" )");
        }
    }

    public class OfferBackCoupon
    {
        public int CouponType;
        public string CouponTypeName;
        public string ValidDate;
        public double OfferMoney;
        public double Balance;
        public double Difference;

        public void Log(StringBuilder sb)
        {
            sb.Append("( CouponType=").Append(CouponType);
            sb.Append(",CouponTypeName=").Append(CouponTypeName);
            sb.Append(",ValidDate=").Append(ValidDate);
            sb.Append(",GainedMoney=").Append(OfferMoney);
            sb.Append(",Balance=").Append(Balance);
            sb.Append(",Difference=").Append(Difference);
            sb.Append(" )");
        }
    }
    
    public class SaleMoneyLeftWhenPromCalc
    {
        public string AddupTypeDesc;
        public string PromotionName;
        public string CouponTypeName;
        public string RuleName;
        public double SaleMoney;

        public void Log(StringBuilder sb)
        {
            sb.Append("( AddupTypeDesc=").Append(AddupTypeDesc);
            sb.Append(",PromotionName=").Append(PromotionName);
            sb.Append(",CouponTypeName=").Append(CouponTypeName);
            sb.Append(",RuleName=").Append(RuleName);
            sb.Append(",SaleMoney=").Append(SaleMoney);
            sb.Append(" )");
        }
    }

}
