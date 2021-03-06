﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace RRR
{
    public class RSQL
    {
        StringBuilder sql = new StringBuilder();
        public void Add(string s)
        {
            if (sql.Length == 0)
                sql.Append(s);
            else
                sql.Append("\r\n").Append(s); //改成和AddLine一样sql.Append(s);
                                              //query.ParseSql();
        }
        public string Text
        {
            get { return sql.ToString(); }
            set
            {
                sql.Length = 0;
                Add(value);
            }
        }
        public int Length { get { return sql.Length; } }
    }
    public class RParam
    {
        public DbParameter param;
        public int AsInteger
        {
            set
            {
                param.DbType = DbType.Int32;
                param.Value = value;
            }
        }
        public double AsFloat
        {
            set
            {
                param.DbType = DbType.Double;
                param.Value = value;
            }
        }
        public string AsString
        {
            set
            {
                param.DbType = DbType.String;
                param.Value = value;
            }
        }
    }
    public class RField
    {
        public object Data;
        public int AsInteger
        {
            get
            {
                return Data.ToString() == string.Empty ? 0 : (int)Data;
            }
        }
        public double AsFloat
        {
            get
            {
                return Data.ToString() == string.Empty ? 0 : (double)Data;
            }
        }
        public string AsString
        {
            get
            {
                return Data.ToString() == string.Empty ? string.Empty : (string)Data;
            }
        }
        public byte[] AsBytes
        {
            get
            {
                return Data.ToString() == string.Empty ? new byte[8] : (byte[])Data;
            }
        }
    }
    public class RQuery
    {
        public RQuery(DbConnection conn)
        {
            command = conn.CreateCommand();
            command.CommandTimeout = 3600;

        }
        DbCommand command;
        DbDataReader dataReader;
        public RSQL SQL = new RSQL();
        public string ParamSymbol = "@";

        private bool eof = false;
        public bool Eof { get { return eof; } }

        private bool active = false;
        public bool Active
        {
            get { return active; }
            set
            {
                if (value)
                {
                    if (!active)
                    {
                        Open();
                        active = true;
                    }
                }
                else
                {
                    if (active)
                    {
                        Close();
                        active = false;
                    }
                }
            }
        }

        private bool isEmpty = true;
        public bool IsEmpty
        {
            get { return isEmpty; }
        }

        private void PrepareSQLParam()
        {
            if (SQL.Length == 0)
                throw new Exception("No SQL.");
            command.CommandType = CommandType.Text;
            command.CommandText = SQL.Text;
            foreach (DbParameter one in command.Parameters)
            {
                command.CommandText = command.CommandText.Replace(":" + one.ParameterName, ParamSymbol + one.ParameterName);
            }
        }
        public int ExecSQL()
        {
            PrepareSQLParam();
            return command.ExecuteNonQuery();
        }
        public void Open()
        {
            if (dataReader != null && !dataReader.IsClosed)
                dataReader.Close();
            PrepareSQLParam();
            dataReader = command.ExecuteReader();
            isEmpty = !dataReader.HasRows;
            eof = (!dataReader.Read());
            active = true;
        }
        public DataTable GetDataTable()
        {
            if (!dataReader.IsClosed)
                dataReader.Close();
            PrepareSQLParam();
            dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            return dataTable;
        }
        public void Close()
        {
            if (active)
            {
                dataReader.Close();
                active = false;
            }
        }
        public void Next()
        {
            if (!active) throw new Exception("Query is not active.");
            if (!eof)
            {
                eof = (!dataReader.Read());
            };
        }
        public RParam ParamByName(string name)
        {
            RParam pm = new RParam();
            pm.param = command.CreateParameter();
            pm.param.ParameterName = name;
            //pm.DbType = ParamType;
            //pm.Value = ParamValue;
            //pm.Direction = In;
            //if (pm.DbType == DbType.String)
            //    pm.Size = 255;
            command.Parameters.Add(pm.param);
            return pm;

        }
        public RField FieldByName(string name)
        {
            RField fld = new RField();
            fld.Data = dataReader[name];
            return fld;
        }
    }
    public class RTools
    {
        public static string GetTMStr(byte[] bytes)
        {
            string tm = "0x";
            for (int i = 0; i < bytes.Length; i++)
                tm += bytes[i].ToString("x2");
            return tm;
        }
    }
}
