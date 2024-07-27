using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace CarSystem
{
    public partial class _Default : Page
    {
        private SqlConnection con;
        public string lineData;

        public void Connection()
        {

            string sqlconnection = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
            con = new SqlConnection(sqlconnection);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            LoadDataToChart();
        }

        public void LoadDataToChart()
        {

            Connection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MonthValue, TotalMonthCount FROM [Wether] where EventType='HighTem'", con);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            // Display details in the GridView
            gvLineChart.DataSource = dt;
            gvLineChart.DataBind();

            lineData = "[";
            foreach (DataRow dr in dt.Rows)
            {

                lineData += "[" + dr["MonthValue"] + "," + dr["TotalMonthCount"] + "],";
            }

            if (lineData.Length > 1)
            {

                lineData = lineData.Remove(lineData.Length - 1);
            }
            lineData += "]";
            con.Close();
        }

        protected void gvLineChart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}