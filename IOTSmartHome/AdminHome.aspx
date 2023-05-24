<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="IOTSmartHome.AdminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Change Password</h3>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <form id="Form1" role="form" runat="server">
                                
                                <div class="form-group">
                                    <label>
                                        Old Password</label>
                                    <asp:TextBox ID="txtOldPassword" class="form-control" runat="server" 
                                        placeholder="Old Password" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Old Password"
                                        ControlToValidate="txtOldPassword" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                
                                </div>
                                <div class="form-group">
                                    <label>
                                        New Password</label>
                                    <asp:TextBox ID="txtNewPassword" class="form-control" runat="server" 
                                        placeholder="New Password" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter New Password"
                                        ControlToValidate="txtNewPassword" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                 
                                </div>
                                <div class="form-group">
                                    <label>
                                        Confirm Password</label>
                                    <asp:TextBox ID="txtConfirmPassword" class="form-control" runat="server" 
                                        placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Confirm Password"
                                        ControlToValidate="txtConfirmPassword" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                        ErrorMessage="Password Not Match" ControlToCompare="txtNewPassword" 
                                        ControlToValidate="txtConfirmPassword" ForeColor="#FF3300" ValidationGroup="A"></asp:CompareValidator>
                                    </div>
                                 
                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
                                <div class="pull-right">
                                       <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="A"
                                            class="btn btn-primary btn-sm pull-right" style="padding:10px 20px;" 
                                            onclick="btnSave_Click" /> 
                                </div>
                                </form>
                            </div>
                            <!-- /.col-lg-6 (nested) -->
                            <!-- /.col-lg-6 (nested) -->
                        </div>
                        <!-- /.row (nested) -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
