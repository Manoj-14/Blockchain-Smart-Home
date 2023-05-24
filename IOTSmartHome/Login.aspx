<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IOTSmartHome.Login" %>

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
	<link
      rel="stylesheet"
      href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css"
      integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm"
      crossorigin="anonymous"
    />
	<!-- <link href="css/style_css.css" rel='stylesheet' type='text/css' /> -->	
	<link href="css/new_style_css.css" rel='stylesheet' type='text/css' />
	<!--// Stylesheets -->
	<!--fonts-->
	<link href="//fonts.googleapis.com/css?family=Source+Sans+Pro:200,200i,300,300i,400,400i,600,600i,700,700i,900,900i" rel="stylesheet">
	<!--//fonts-->
</head>

<body >
	<h1 class="text-center m-2">Login Form </h1>
	<div class="w3ls-login form-container">
		<asp:Label ID="lblMsg" runat="server" class="text-danger" style="text-align:center;color:red; display:inline-block !important" role="alert" Text=""></asp:Label>
		<!-- form starts here -->
		<form class="container w-50 mt-5" id="form1" runat="server">
        <div class="form-group">
		
				<label>
					<i class="fa fa-user" aria-hidden="true"></i> Select User Type :</label>
				
                            <asp:DropDownList class="form-control" ID="ddlUserType" runat="server">
                                <asp:ListItem>--Select--</asp:ListItem>
                                <asp:ListItem>Admin</asp:ListItem>
                                <asp:ListItem>User</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select User Type" InitialValue="--Select--" ValidationGroup="A" ControlToValidate="ddlUserType" ForeColor="#fb0b57"></asp:RequiredFieldValidator>
			</div>
			<div class="form-group" class="agile-field-txt">
				<label>
					<i class="fa fa-user" aria-hidden="true"></i>Enter User Id :</label>
				<asp:TextBox class="form-control" ID="txtUserId" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter User Id" ValidationGroup="A" ControlToValidate="txtUserId" ForeColor="#fb0b57"></asp:RequiredFieldValidator>
			</div>
			<div class="form-group" class="agile-field-txt">
				<label>
					<i class="fa fa-lock" aria-hidden="true"></i> Password :</label>
				
				<asp:TextBox ID="txtPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Password" ValidationGroup="A" ControlToValidate="txtPassword" ForeColor="#fb0b57"></asp:RequiredFieldValidator>
				
			</div>
		
			<!-- //script for show password -->
			<div class="w3ls-login  w3l-sub">
                            <asp:Button CssClass="btn btn-primary btn-block" ID="btnLogin" runat="server" Text="Login" 
                                onclick="btnLogin_Click" ValidationGroup="A"/>
							<p class="text-center">or</p>
                            <asp:Button CssClass="btn btn-primary btn-block" ID="btnHome" runat="server" Text="Home" onclick="btnHome_Click" />
			</div>
		</form>
	</div>
	<!-- //form ends here -->
	<!--copyright-->
	<!-- <div class="copy-wthree">
		<p>© 2023 Smart IOT System . All Rights Reserved | Design by
			Smart IOT System
		</p>
	</div> -->
	<!--//copyright-->
</body>

</html>
