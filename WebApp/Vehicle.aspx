<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vehicle.aspx.cs" Inherits="WebApp.Vehicle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   <form id="VehiclePage" runat="server">
        <asp:SqlDataSource ID="sdsVehicle" runat ="server"></asp:SqlDataSource>
        <center>
        <asp:Label ID ="lblTitle" runat ="server" Text= "Список транспортных средств" 
                Font-Size ="20" Font-Names ="Arial"></asp:Label>
        </center>
        <div style ="float : left">
            <asp:Label ID="lblTypeOfVehicle" runat ="server"
             CssClass ="font_style" Text ="Рабочие дни"></asp:Label>
            <br>
            <asp:TextBox ID="tbTypeOfVehicle" runat ="server"  CssClass ="tb_Style" Text ="Введите тип транспортного средства" Width="259px"></asp:TextBox>
            <br>
            <center>
             <br>
             <asp:Button ID = "btInsert" runat ="server" CssClass ="bt_Style" 
                    Text ="Добавить новое транспортное средство" OnClick="btInsert_Click" /><br> 
                <asp:Button ID = "btUpdate" runat ="server" CssClass ="bt_Style" 
                    Text ="Изменить данные о транспортном средстве" OnClick="btUpdate_Click" /><br>
                 <asp:Button ID = "btDelete" runat ="server" CssClass ="bt_Style" 
                    Text ="Удалить транспортное средство" OnClick="btDelete_Click" /><br>
            </div>
       <center>
                    <asp:Label ID ="lblSearch" runat ="server" 
                        Text ="Введите значение для поиска" CssClass="font_style"></asp:Label>
                     <br>
                    <asp:TextBox ID="tbSearch" runat ="server" 
                        CssClass ="tb_Style"></asp:TextBox>
                    <br>
                    <asp:Button ID ="btSearch" runat ="server" 
                        CssClass ="bt_Style" Text ="Поиск" OnClick="btSearch_Click" />
                    <asp:Button ID ="btFilter" runat ="server" 
                        CssClass ="bt_Style" Text ="Фильтр" OnClick="btFilter_Click"  />
                    <asp:Button ID ="btCancel" runat ="server" 
                        CssClass ="bt_Style" Text ="Отмена" OnClick="btCancel_Click" />
                    <asp:GridView ID ="gvVehicle" runat ="server" 
                    AllowSorting ="true"
                    CssClass ="gvStyle" OnRowDataBound="gvVehicle_RowDataBound" 
                    OnSelectedIndexChanged="gvVehicle_SelectedIndexChanged" OnSorting ="gvVehicle_Sorting"
                    CurrentSortField ="" CurrentSortDirection ="ASC" >
                    <Columns>
                        <asp:CommandField ShowSelectButton ="true" />
                    </Columns>
                </asp:GridView>

                      <div style ="float : left">
                     <asp:Label ID ="lblPreviousPage" runat ="server" 
                        Text ="Список рабочих дней" CssClass="font_style"></asp:Label>
                     <br>
                      <asp:Button ID ="btPreviousPage" runat ="server" 
                        CssClass ="bt_Style" Text ="Предыдущая страница" OnClick="btPreviousPage_Click" />
                     </div>

                    <div style ="float : right">
                     <asp:Label ID ="lblNextPage" runat ="server" 
                        Text ="Список сотрудников" CssClass="font_style"></asp:Label>
                     <br>
                      <asp:Button ID ="btNextPage" runat ="server" 
                        CssClass ="bt_Style" Text ="Следующая страница" OnClick="btNextPage_Click" />
                    </div>
    </form>
</body>
</html>
