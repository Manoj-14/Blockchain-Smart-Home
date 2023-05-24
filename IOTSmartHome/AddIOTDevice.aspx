<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddIOTDevice.aspx.cs" Inherits="IOTSmartHome.AddIOTDevice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Add IOT Device Information</h3>
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
                                        Enter Device Id</label>
                                    <asp:TextBox ID="txtDeviceId" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter Device Id"
                                        ForeColor="Red" ValidationGroup="A" ControlToValidate="txtDeviceId"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Enter Device Name</label>
                                    <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Name"
                                        ForeColor="Red" ValidationGroup="A" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Enter Device Description</label>
                                    <asp:TextBox ID="txtDescription" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Description"
                                        ForeColor="Red" ValidationGroup="A" ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
                                </div>
                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
                                <div class="pull-right">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="A" class="btn btn-primary btn-sm pull-right"
                                        Style="padding: 10px 20px;" OnClick="btnSave_Click" />
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
