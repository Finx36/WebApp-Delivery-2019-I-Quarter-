using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApp
{
    public partial class Sotrudnik_Info : System.Web.UI.Page
    {
            private string QR = "";
            protected void Page_Load(object sender, EventArgs e)
            {
                QR = DBConnection.qrWorkerInformation;
                if (!IsPostBack)
                {
                    gvFill(QR);
                    ddlVehicleFill();
                    ddlPositionFill();
                }
            }

            private void gvFill(string qr)
            {
                sdsSotrudnik.ConnectionString =
                    DBConnection.connection.ConnectionString.ToString();
                sdsSotrudnik.SelectCommand = qr;
                sdsSotrudnik.DataSourceMode = SqlDataSourceMode.DataReader;
                gvWorkInformation.DataSource = sdsSotrudnik;
                gvWorkInformation.DataBind();
            }

            private void ddlVehicleFill()
            {
            sdsSotrudnik.ConnectionString =
                DBConnection.connection.ConnectionString.ToString();
            sdsSotrudnik.SelectCommand = DBConnection.qrVehicle;
            sdsSotrudnik.DataSourceMode = SqlDataSourceMode.DataReader;
            ddlVehicle.DataSource = sdsSotrudnik;
            ddlVehicle.DataTextField = "Тип транспортного средства";
            ddlVehicle.DataValueField = "ID_Vehicle";
            ddlVehicle.DataBind();
            }
            private void ddlPositionFill()
             {
            sdsSotrudnik.ConnectionString =
                DBConnection.connection.ConnectionString.ToString();
            sdsSotrudnik.SelectCommand = DBConnection.qrWorkerPosition;
            sdsSotrudnik.DataSourceMode = SqlDataSourceMode.DataReader;
            ddlPosition.DataSource = sdsSotrudnik;
            ddlPosition.DataTextField = "Должность";
            ddlPosition.DataValueField = "ID_Position";
            ddlPosition.DataBind();
             }

        protected void gvWorker_RowDataBound(object sender, GridViewRowEventArgs e)
            {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[10].Visible = false;


        }

            protected void gvWorker_SelectedIndexChanged(object sender, EventArgs e)
            {
                GridViewRow row = gvWorkInformation.SelectedRow;
                tbSurname.Text = row.Cells[2].Text.ToString();
                tbName.Text = row.Cells[3].Text.ToString();
                tbMiddleName.Text = row.Cells[4].Text.ToString();
                tbDateOfBirth.Text = row.Cells[5].Text.ToString();
                tbUserName.Text = row.Cells[6].Text.ToString();
                 ddlVehicle.SelectedValue = row.Cells[8].Text;
                ddlPosition.SelectedValue = row.Cells[10].Text;
                DBConnection.IDsotrudnik = Convert.ToInt32(row.Cells[1].Text.ToString());
            }

        protected void btInsert_Click(object sender, EventArgs e)
        {
            switch (tbSurname.Text == "")
            {
                case (true):
                    tbSurname.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbSurname.BackColor = System.Drawing.Color.White;
                    switch (tbName.Text == "")
                    {
                        case (true):
                            tbName.BackColor = System.Drawing.Color.Red;
                            break;
                        case (false):
                            tbName.BackColor = System.Drawing.Color.White;
                            switch (tbMiddleName.Text == "")
                            {
                                case (true):
                                    tbMiddleName.BackColor = System.Drawing.Color.Red;
                                    break;
                                case (false):
                                    tbMiddleName.BackColor = System.Drawing.Color.White;
                                    switch (tbDateOfBirth.Text == "")
                                    {
                                        case (true):
                                            tbDateOfBirth.BackColor = System.Drawing.Color.Red;
                                            break;
                                        case (false):
                                            tbDateOfBirth.BackColor = System.Drawing.Color.White;
                                            switch (tbUserName.Text == "")
                                            {
                                                case (true):
                                                    tbUserName.BackColor = System.Drawing.Color.Red;
                                                    break;
                                                case (false):
                                                    tbUserName.BackColor = System.Drawing.Color.White;
                                                    switch (tbPassword.Text == "")
                                                    {
                                                        case (true):
                                                            tbPassword.BackColor = System.Drawing.Color.Red;
                                                            break;
                                                        case (false):
                                                            tbPassword.BackColor = System.Drawing.Color.White;
                                                            switch (tbConfirmPassword.Text == "")
                                                            {
                                                                case (true):
                                                                    tbConfirmPassword.BackColor = System.Drawing.Color.Red;
                                                                    break;
                                                                case (false):
                                                                    tbConfirmPassword.BackColor = System.Drawing.Color.White;
                                                                    switch (tbConfirmPassword.Text != tbPassword.Text)
                                                                    {
                                                                        case (true):
                                                                            tbConfirmPassword.BackColor = System.Drawing.Color.Red;
                                                                            tbPassword.BackColor = System.Drawing.Color.Red;
                                                                            Console.WriteLine("пароли отличаются");
                                                                            break;
                                                                        case (false):
                                                                            tbConfirmPassword.BackColor = System.Drawing.Color.White;
                                                                            tbPassword.BackColor = System.Drawing.Color.White;
                                                                            SqlCommand command = new SqlCommand("", DBConnection.connection);
                                                                            command.CommandText = "insert into [dbo].[Worker_Information] " +
                                                                            "([Surname], " +
                                                                            "[Name], [Middle_Name], [Date_Of_Birth], " +
                                                                            "[User_name], [Password], [Vehicle_ID], [Position_ID]) values ('" + tbSurname.Text + "','"
                                                                            + tbName.Text + "','" + tbMiddleName.Text + "','"
                                                                            + tbDateOfBirth.Text + "','" + tbUserName.Text + "','"
                                                                            + tbPassword.Text + "', '" + ddlVehicle.SelectedValue + "', '" + ddlPosition.SelectedValue + "')";
                                                                            DBConnection.connection.Open();
                                                                            command.ExecuteNonQuery();
                                                                            DBConnection.connection.Close();
                                                                            gvFill(QR);
                                                                            
                                                                            break;
                                                                    }
                                                                    break;
                                                            }
                                                            break;
                                                    }
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }


        protected void btUpdate_Click(object sender, EventArgs e)
        {
            switch (tbSurname.Text == "")
            {
                case (true):
                    tbSurname.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbSurname.BackColor = System.Drawing.Color.White;
                    switch (tbName.Text == "")
                    {
                        case (true):
                            tbName.BackColor = System.Drawing.Color.Red;
                            break;
                        case (false):
                            tbName.BackColor = System.Drawing.Color.White;
                            switch (tbMiddleName.Text == "")
                            {
                                case (true):
                                    tbMiddleName.BackColor = System.Drawing.Color.Red;
                                    break;
                                case (false):
                                    tbMiddleName.BackColor = System.Drawing.Color.White;
                                    switch (tbDateOfBirth.Text == "")
                                    {
                                        case (true):
                                            tbDateOfBirth.BackColor = System.Drawing.Color.Red;
                                            break;
                                        case (false):
                                            tbDateOfBirth.BackColor = System.Drawing.Color.White;
                                            switch (tbUserName.Text == "")
                                            {
                                                case (true):
                                                    tbUserName.BackColor = System.Drawing.Color.Red;
                                                    break;
                                                case (false):
                                                    tbUserName.BackColor = System.Drawing.Color.White;
                                                    switch (tbPassword.Text == "")
                                                    {
                                                        case (true):
                                                            tbPassword.BackColor = System.Drawing.Color.Red;
                                                            break;
                                                        case (false):
                                                            tbPassword.BackColor = System.Drawing.Color.White;
                                                            switch (tbConfirmPassword.Text == "")
                                                            {
                                                                case (true):
                                                                    tbConfirmPassword.BackColor = System.Drawing.Color.Red;
                                                                    break;
                                                                case (false):
                                                                    tbConfirmPassword.BackColor = System.Drawing.Color.White;
                                                                    switch (tbConfirmPassword.Text != tbPassword.Text)
                                                                    {
                                                                        case (true):
                                                                            tbConfirmPassword.BackColor = System.Drawing.Color.Red;
                                                                            tbPassword.BackColor = System.Drawing.Color.Red;
                                                                            Console.WriteLine("пароли отличаются");
                                                                            break;
                                                                        case (false):
                                                                            tbConfirmPassword.BackColor = System.Drawing.Color.White;
                                                                            tbPassword.BackColor = System.Drawing.Color.White;
                                                                            SqlCommand command = new SqlCommand("", DBConnection.connection);
                                                                            command.CommandText = "update [dbo].[Worker_Information] set " +
                                                                              "[Surname] ='" + tbSurname.Text + "', " +
                                                                              "[Name] ='" + tbName.Text + "', " +
                                                                              "[Middle_Name] ='" + tbMiddleName.Text + "', " +
                                                                              "[Date_Of_Birth] ='" + tbDateOfBirth.Text + "', " +
                                                                              "[User_Name] ='" + tbUserName.Text + "', " +
                                                                              "[Password] ='" + tbPassword.Text + "', " +
                                                                              "[Vehicle_ID]='" + ddlVehicle.SelectedValue + "'," +
                                                                              "[Position_ID]='" + ddlPosition.SelectedValue + "'" +
                                                                              " where ID_Worker = " + DBConnection.IDsotrudnik + "";
                                                                            DBConnection.connection.Open();
                                                                            command.ExecuteNonQuery();
                                                                            DBConnection.connection.Close();
                                                                            gvFill(QR);
                                                                            
                                                                            break;
                                                                    }
                                                                    break;
                                                            }
                                                            break;
                                                    }
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }
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
                    command.CommandText = "delete from [dbo].[Worker_Information] " +
                        "where ID_Worker = " + DBConnection.IDsotrudnik + "";
                    DBConnection.connection.Open();
                    command.ExecuteNonQuery();
                    DBConnection.connection.Close();
                    Page_Load(sender, e);
                    break;
            }
        } 

        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvWorkInformation.Rows)
            {
                if (row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[3].Text.Equals(tbSearch.Text)
                    || row.Cells[4].Text.Equals(tbSearch.Text)
                    || row.Cells[5].Text.Equals(tbSearch.Text)
                    || row.Cells[6].Text.Equals(tbSearch.Text)
                    || row.Cells[9].Text.Equals(tbSearch.Text)
                    || row.Cells[11].Text.Equals(tbSearch.Text)
                    || row.Cells[12].Text.Equals(tbSearch.Text))
                   
                    row.BackColor = System.Drawing.Color.DarkGray;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }

        protected void btFilter_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [Surname] like '%" + tbSearch.Text + "%' or " +
                "[Name] like '%" + tbSearch.Text + "%' or " +
                "[Middle_Name] like '%" + tbSearch.Text + "%' or " +
                "[Date_Of_Birth] like '%" + tbSearch.Text + "%' or " +
                "[User_Name] like '%" + tbSearch.Text + "%' or " +
                "[Type_Of_Vehicle] like '%" + tbSearch.Text + "%' or " +
                "[Position] like '%" + tbSearch.Text + "%' or " +
                "[Salary] like '%" + tbSearch.Text + "%'";
            gvFill(newQr);
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);
        }

        protected void gvWorker_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Фамилия"):
                    e.SortExpression = "[Surname]";
                    break;
                case ("Имя"):
                    e.SortExpression = "[Name]";
                    break;
                case ("Отчество"):
                    e.SortExpression = "[Middle_Name]";
                    break;
                case ("Дата рождения"):
                    e.SortExpression = "[Date_Of_Birth]";
                    break;
                case ("Логин"):
                    e.SortExpression = "[User_Name]";
                    break;
                case ("Тип транспортного средства"):
                    e.SortExpression = "[Type_Of_Vehicle]";
                    break;
                case ("Должность"):
                    e.SortExpression = "[Position]";
                    break;
                case ("Зарплата"):
                    e.SortExpression = "[Salary]";
                    break;
            }
            sortGridView(gvWorkInformation, e, out sortDirection, out strField);
            string strDirection = sortDirection
                == SortDirection.Ascending ? "ASC" : "DESC";
            gvFill(QR + " order by " + e.SortExpression + " " + strDirection);
        }

        public void sortGridView(GridView gridView,
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
            Response.Redirect("Vehicle.aspx");
        }

        protected void btNextPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Worker_Position.aspx");
        }

       
    }
}