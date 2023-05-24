<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs"
    Inherits="IOTSmartHome.UserRegistration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>Smart IOT System</title>
    <!-- Meta-Tags -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="utf-8">
    <meta name="keywords" content="Elite login Form a Responsive Web Template, Bootstrap Web Templates, Flat Web Templates, Android Compatible Web Template, Smartphone Compatible Web Template, Free Webdesigns for Nokia, Samsung, LG, Sony Ericsson, Motorola Web Design">
    <script>
        addEventListener("load", function () {
            setTimeout(hideURLbar, 0);
        }, false);

        function hideURLbar() {
            window.scrollTo(0, 1);
        }
    </script>
    <!-- //Meta-Tags -->
    <!-- Stylesheets -->
    <link href="css/font-awesome.css" rel="stylesheet">
    <!-- <link href="css/style_css.css" rel='stylesheet' type='text/css' /> -->
    <!--// Stylesheets -->
    <!--fonts-->
    <link href="//fonts.googleapis.com/css?family=Source+Sans+Pro:200,200i,300,300i,400,400i,600,600i,700,700i,900,900i"
        rel="stylesheet">
    <link href="css/new_style_css.css" rel='stylesheet' type='text/css' />
    <link
      rel="stylesheet"
      href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css"
      integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm"
      crossorigin="anonymous"
    />
    <!--//fonts-->
</head>
<body>
    <h1 class="text-center m-2">
        Registration Form
    </h1>
    <asp:Label ID="lblMsg" runat="server" CssClass="text-center text-danger d-block" Text=""></asp:Label><br />
    <div class="w3ls-login form-container">
        <!-- form starts here -->
        <form class="container w-50 mt-5" id="form1" runat="server">
        <div class="form-group">
            <label>
                <i class="fa fa-user" aria-hidden="true"></i>Enter User Name :</label>
            <asp:TextBox class="form-control" ID="txtUserName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter User Name"
                ValidationGroup="A" ControlToValidate="txtUserName" ForeColor="#fb0b57"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>
                <i class="fa fa-lock" aria-hidden="true"></i>Enter Mobile No :</label>
            <asp:TextBox class="form-control" ID="txtMobileNo" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Mobile No"
                ValidationGroup="A" ControlToValidate="txtMobileNo" ForeColor="#fb0b57"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Only 10 Digits"
                ControlToValidate="txtMobileNo" ForeColor="Red" ValidationExpression="[0-9]{10}"
                ValidationGroup="A"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label>
                <i class="fa fa-lock" aria-hidden="true"></i>Enter Email Id :</label>
            <asp:TextBox class="form-control" ID="txtEmailId" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter EmailId"
                ValidationGroup="A" ControlToValidate="txtEmailId" ForeColor="#fb0b57"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Email Id"
                ControlToValidate="txtEmailId" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ValidationGroup="A"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label>
                <i class="fa fa-lock" aria-hidden="true"></i>Enter Address:</label>
            <asp:TextBox class="form-control" ID="txtAddress" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Address"
                ValidationGroup="A" ControlToValidate="txtAddress" ForeColor="#fb0b57"></asp:RequiredFieldValidator>
        </div>
        <!-- //script for show password -->
        <div class="w3ls-login  w3l-sub">
            <asp:Button class="btn btn-block btn-primary" ID="btnRegister" runat="server" Text="Register" ValidationGroup="A" 
                onclick="btnRegister_Click" />
            <p class="text-center">or</p>
            <asp:Button ID="btnHome" class="btn btn-block btn-primary" runat="server" Text="Home" OnClick="btnHome_Click" />
        </div>
        </form>
    </div>
    <!-- //form ends here -->
    <!--copyright-->
    <div class="text-center copy-wthree mt-5">
        <p>
            © 2023 Smart IOT System . All Rights Reserved | Design by Smart IOT System , VVCE Mysore
        </p>
    </div>
    <!--//copyright-->
</body>
</html>
