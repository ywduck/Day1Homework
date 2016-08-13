using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

using Day1Homework.Models.ViewModels;

namespace Day1Homework.Service
{
    public class MoneryService
    {
        private string strConn { get; set; }

        public MoneryService()
        {
            this.strConn = WebConfigurationManager.ConnectionStrings["SkillTree"].ToString();
        }

        public List<MoneyRecViewModel> GetAccountBook()
        {

            string strSQL = "select Id, Categoryyy, convert(varchar, Dateee, 111) as Dateee, Amounttt from AccountBook";
            try
            {
                DataSet ds = new DataSet();

                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = strSQL;
                        cmd.CommandTimeout = 120;

                        //conn.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(ds, "targetTable");
                        }
                    }
                }

                List<MoneyRecViewModel> listMoneyRec = new List<MoneyRecViewModel>();
                for (int i = 0; i < ds.Tables["targetTable"].Rows.Count; i++) {
                    MoneyRecViewModel oMoney = new MoneyRecViewModel();
                    oMoney.Id = ds.Tables["targetTable"].Rows[i]["Id"].ToString();
                    oMoney.MoneyType = (ds.Tables["targetTable"].Rows[i]["Categoryyy"].ToString() == "0") ? "支出" : "收入";
                    oMoney.CreDate = ds.Tables["targetTable"].Rows[i]["Dateee"].ToString();
                    oMoney.Amount = int.Parse(ds.Tables["targetTable"].Rows[i]["Amounttt"].ToString());

                    listMoneyRec.Add(oMoney);
                }

                return listMoneyRec;

            }
            catch (Exception ex)
            {
                return null;
            }

        }


    }
}