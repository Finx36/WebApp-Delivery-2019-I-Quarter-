using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace WebApp
{
    public class DBConnection
    {
        public static SqlConnection connection = new SqlConnection(
            @"Data Source = BOROV\SQLEXPRESS; " +
                " Initial Catalog = Slujba; Persist Security Info = true;" +
                " User ID = sa; Password = \"\"");
        public DataTable dtWorkerInformation = new DataTable("WorkerInformation");
        public DataTable dtGraph = new DataTable("Graph");
        public DataTable dtVehicle = new DataTable("Vehicle");
        public DataTable dtWorkerPosition = new DataTable("WorkerPosition");

        public static string qrWorkerInformation = "SELECT [ID_Worker], [Surname] as \"Фамилия\", " +
            "[Name] as \"Имя\", [Middle_Name] as \"Отчество\" " +
            ",[Date_Of_Birth] as \"Дата рождения\" , [User_Name] as \"Логин\",[Password] as \"Пароль\", " +
            " [dbo].[Worker_Information].[Vehicle_ID], [Type_Of_Vehicle] as \"Тип транспортного средства\", " +
            " [dbo].[Worker_Information].[Position_ID], [Position] as \"Должность\", [Salary] as \"Заплата\" FROM [dbo].[Worker_Information] " +
            "INNER JOIN [dbo].[Vehicle] " +
            "ON [dbo].[Worker_Information].[Vehicle_ID] " +
            "= [dbo].[Vehicle].[ID_Vehicle] " +
            " INNER JOIN [dbo].[Worker_Position] " +
            "ON [dbo].[Worker_Information].[Position_ID] " +
            "= [dbo].[Worker_Position].[ID_Position]  ";

        public static string qrGraph = "SELECT [ID_Graph], [Work_Days] as \"Рабочие дни\" FROM [dbo].[Graph]";

        public static string qrVehicle = "SELECT [ID_Vehicle], [Type_Of_Vehicle] as \"Тип транспортного средства\" FROM [dbo].[Vehicle]";

        public static string qrWorkerPosition = "SELECT [ID_Position], [Position] as \"Должность\", " +
            "[Salary] as \"Зарплата\", [dbo].[Worker_Position].[Graph_ID], [Work_Days] as \"Рабочие дни\" FROM [dbo].[Worker_Position] " + 
            " INNER JOIN [dbo].[Graph] " +
            "ON [dbo].[Worker_Position].[Graph_ID] " +
            "= [dbo].[Graph].[ID_Graph]";

        private SqlCommand command = new SqlCommand("", connection);
        public static Int32 IDsotrudnik, IDgrap, IDvehicle, IDpos, IDuser;

        public void dbEnter(string login, string password)
        {
            command.CommandText = "SELECT count(*) FROM [dbo].[Worker_Information] " +
                "where [User_Name] = '" + login + "' and [Password] = '" +
                password + "'";
            connection.Open();
            IDuser = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
        }

        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }

        public void SotrudnikFill()
        {
            dtFill(dtWorkerInformation, qrWorkerInformation);
        }

        public void GraphFill()
        {
            dtFill(dtGraph, qrGraph);
        }

        public void VehicleFill()
        {
            dtFill(dtVehicle, qrVehicle);
        }

        public void PositionFill()
        {
            dtFill(dtWorkerPosition, qrWorkerPosition);
        }
    }
}