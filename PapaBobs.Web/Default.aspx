﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PapaBobs.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="page-header">
            <h2>Papa Bob's Pizza</h2>
            <p>Pizza to Code By</p>
        </div>

        <div class="form-group">
            <label>Size:</label>
            <asp:DropDownList ID="sizeDropDown" runat="server" CssClass="form-control" OnSelectedIndexChanged="recalculateTotalCost" AutoPostBack="true">
                <asp:ListItem Text="Chose One..." Selected="True" Value=""></asp:ListItem>
                <asp:ListItem Text="Small (12 inch - $12)" Value="Small"></asp:ListItem>
                <asp:ListItem Text="Medium (14 inch - $14)" Value="Medium"></asp:ListItem>
                <asp:ListItem Text="Large (16 inch - $16)" Value="Large"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <label>Crust:</label>
            <asp:DropDownList ID="crustDropDown" runat="server" CssClass="form-control" OnSelectedIndexChanged="recalculateTotalCost" AutoPostBack="true">
                <asp:ListItem Text="Choose one..." Selected="True" Value=""></asp:ListItem>
                <asp:ListItem Text="Regular" Value="Regular"></asp:ListItem>
                <asp:ListItem Text="Thin" Value="Thin"></asp:ListItem>
                <asp:ListItem Text="Thick (+ $2)" Value="Thick"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <div class="checkbox">
                <label><asp:CheckBox ID="sausageCheckBox" runat="server" OnCheckedChanged="recalculateTotalCost" AutoPostBack="true" />Sausage</label><br />
                <label><asp:CheckBox ID="pepperoniCheckbox" runat="server" OnCheckedChanged="recalculateTotalCost" AutoPostBack="true" />Pepperoni</label><br />
                <label><asp:CheckBox ID="onionCheckBox" runat="server" OnCheckedChanged="recalculateTotalCost" AutoPostBack="true" />Onions</label><br />
                <label><asp:CheckBox ID="greenPepperCheckBox" runat="server" OnCheckedChanged="recalculateTotalCost" AutoPostBack="true" />Green Peppers</label>
            </div>

        </div>

        <h3>Deliver To:</h3>

        <div class="form-group">

            <label>Name:</label>
            <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <br />
            <label>Address:</label>
            <asp:TextBox ID="addressTextbox" runat="server" CssClass="form-control"></asp:TextBox>
            <br />
            <label>Zip Code:</label>
            <asp:TextBox ID="zipCodeTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <br />
            <label>Phone:</label>
            <asp:TextBox ID="phoneTextBox" runat="server" CssClass="form-control"></asp:TextBox>

        </div>

        <h3>Payment:</h3>

        <div class="form-group">

            <div class="custom-radio">
                <label>
                    <asp:RadioButton ID="cashRadio" runat="server" GroupName="PaymentGroup" Checked="true" />
                    Cash
                </label>
            </div>
            <div class="custom-radio">
                <label>
                    <asp:RadioButton ID="creditRadio" runat="server" GroupName="PaymentGroup" />
                    Credit
                </label>
            </div>

        </div>

        <div class="form-group">

            <asp:Button ID="orderButton" Text="Order" runat="server" OnClick="orderButton_Click" CssClass="btn btn-lg btn-primary" />

        </div>

        <asp:Label ID="validationLabel" Text="" Visible="false" runat="server" CssClass="bg-danger"></asp:Label>

        <h3>Total Cost:</h3>
        <div class="form-group">

            <asp:Label ID="resultLabel" runat="server"></asp:Label>

        </div>
    
    </div>
    </form>

    <script src="scripts/jquery-3.0.0.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>

</body>
</html>
