using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApp
{
    public partial class Vehicle : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBConnection.qrVehicle;
            if (!IsPostBack)
            {
                gvFill(QR);
            }
        }

        private void gvFill(string qr)
        {
            sdsVehicle.ConnectionString =
                DBConnection.connection.ConnectionString.ToString();
            sdsVehicle.SelectCommand = qr;
            sdsVehicle.DataSourceMode = SqlDataSourceMode.DataReader;
            gvVehicle.DataSource = sdsVehicle;
            gvVehicle.DataBind();
        }

        protected void gvVehicle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;

        }
        protected void gvVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvVehicle.SelectedRow;
            tbTypeOfVehicle.Text = row.Cells[2].Text.ToString();

            DBConnection.IDvehicle = Convert.ToInt32(row.Cells[1].Text.ToString());
        }

        protected void btInsert_Click(object sender, EventArgs e)
        {
            switch (tbTypeOfVehicle.Text == "")
            {
                case (true):
                    tbTypeOfVehicle.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbTypeOfVehicle.BackColor = System.Drawing.Color.White;
                    SqlCommand command = new SqlCommand("", DBConnection.connection);
                    command.CommandText = "insert into [dbo].[Vehicle] " +
                    "([Type_Of_Vehicle]) values ('" + tbTypeOfVehicle.Text + "')";
                    DBConnection.connection.Open();
                    command.ExecuteNonQuery();
                    DBConnection.connection.Close();
                    gvFill(QR);
                    break;
            }
        }



        protected void btUpdate_Click(object sender, EventArgs e)
        {
            switch (tbTypeOfVehicle.Text == "")
            {
                case (true):
                    tbTypeOfVehicle.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbTypeOfVehicle.BackColor = System.Drawing.Color.White;
                    SqlCommand command = new SqlCommand("", DBConnection.connection);
                    command.CommandText = "update [dbo].[Vehicle] set " +
                   "[Type_Of_Vehicle] ='" + tbTypeOfVehicle.Text + " '"+
                       " where ID_Vehicle = " + DBConnection.IDvehicle + "";
                    DBConnection.connection.Open();
                    command.ExecuteNonQuery();
                    DBConnection.connection.Close();
                    gvFill(QR);
                    break;
            }
        }




        protected void btDelete_Click(object sender, EventArgs e)
        {
            switch (System.Windows.Forms.MessageBox.Show(
                "Удалить выбранную запись?", "Удаление записи",
                System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Question))
            {
                case System.Windows.Forms.DialogResult.Yes:
                    SqlCommand command = new SqlCommand("", DBConnection.connection);
                    command.CommandText = "delete from [dbo].[Vehicle] " +
                        "where ID_Vehicle = " + DBConnection.IDvehicle + "";
                    DBConnection.connection.Open();
                    command.ExecuteNonQuery();
                    DBConnection.connection.Close();
                    gvFill(QR);
                    break;
            }
        }
        

        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvVehicle.Rows)
            {
                if (row.Cells[2].Text.Equals(tbSearch.Text))

                    row.BackColor = System.Drawing.Color.DarkGray;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }

        protected void btFilter_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [Type_Of_Vehicle] like '%" + tbSearch.Text + "%'";
            gvFill(newQr);
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);
        }

        protected void gvVehicle_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Тип транспортного средства"):
                    e.SortExpression = "[Type_Of_Vehicle]";
                    break;
            }
            sortGridView(gvVehicle, e, out sortDirection, out strField);
            string strDirection = sortDirection
                == SortDirection.Ascending ? "ASC" : "DESC";
            gvFill(QR + " order by " + e.SortExpression + " " + strDirection);
        }

        private void sortGridView(GridView gridView,
         GridViewSortEventArgs e,
         out SortDirection sortDirection,
         out string strSortField)
        {
            strSortField = e.SortExpression;
            sortDirection = e.SortDirection;

            if (gridView.Attributes["CurrentSortField"] != null &&
                gridView.Attributes["CurrentSortDirection"] != null)
            {
                if (strSortField ==
                    gridView.Attributes["CurrentSortField"])
                {
                    if (gridView.Attributes["CurrentSortDirection"]
                        == "ASC")
                    {
                        sortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        sortDirection = SortDirection.Ascending;
                    }
                }
            }
            gridView.Attributes["CurrentSortField"] = strSortField;
            gridView.Attributes["CurrentSortDirection"] =
                (sortDirection == SortDirection.Ascending ? "ASC"
                : "DESC");
        }

        protected void btPreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Graph.aspx");
        }

        protected void btNextPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sotrudnik Info.aspx");
        }
    }
}