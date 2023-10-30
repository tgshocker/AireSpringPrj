<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AireSpringPrj.index" %>

<!DOCTYPE html>

<html>
<head>
    <title>Employee Search</title>
</head>
<body>
    <form id="fEmployee" runat="server">  <%-- Form containing all the inputs and button --%>
        <asp:HiddenField id="hAction" Value="INSERT" runat="server"/> <%-- Field to store the Action --%>
        <h2>Create New Employee</h2>
        <div>
            <asp:Label ID="lblID" runat="server" Text="Employee ID:"></asp:Label>
            <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        </div>
        <br />

        <div>
            <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        </div>
        <br />

        <div>
            <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        </div>
        <br />

        <div>
            <asp:Label ID="lblPhone" runat="server" Text="Phone:"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" TextMode="Number" MaxLength="10"></asp:TextBox>
        </div>
        <br />

        <div>
            <asp:Label ID="lblZip" runat="server" Text="Zip:"></asp:Label>
            <asp:TextBox ID="txtZip" runat="server" TextMode="Number" MaxLength="5"></asp:TextBox>
        </div>
        <br />

        <div>
            <asp:Label ID="lblHireDate" runat="server" Text="Hire Date (MM/DD/YYYY):"></asp:Label>
            <asp:TextBox ID="txtHireDate" runat="server" TextMode="DateTime"></asp:TextBox>
        </div>
        <br />

        <asp:Button ID="btnCreateEmployee" runat="server" Text="Create New Employee" OnClick="btnCreateEmployee_Click" />

        <div>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
        <br />


        <!-- Search input and button -->
        <div>
            <asp:TextBox ID="txtSearch" runat="server" placeholder="Search by LastName or Phone"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        </div>

        <br />

        <!-- GridView for displaying data -->
        <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="False" OnRowEditing="gvEmployees_RowEditing" OnRowDeleting="gvEmployees_RowDeleting">
            <Columns>
                <asp:BoundField DataField="EmployeeID" HeaderText="ID" SortExpression="EmployeeID" />
                <asp:BoundField DataField="EmployeeLastName" HeaderText="Last Name" SortExpression="EmployeeLastName" />
                <asp:BoundField DataField="EmployeeFirstName" HeaderText="First Name" SortExpression="EmployeeFirstName" />
                <asp:BoundField DataField="EmployeePhone" HeaderText="Phone" SortExpression="EmployeePhone" />
                <asp:BoundField DataField="EmployeeZip" HeaderText="Zip" SortExpression="EmployeeZip" />
                <asp:BoundField DataField="HireDate" HeaderText="Hire Date" SortExpression="HireDate" DataFormatString="{0:MM/dd/yyyy}"/>
                <asp:CommandField ShowEditButton="True"/>
                <asp:CommandField ShowDeleteButton="True"/>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
