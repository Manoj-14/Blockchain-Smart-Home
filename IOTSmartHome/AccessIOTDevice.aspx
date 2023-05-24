<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true"
    CodeBehind="AccessIOTDevice.aspx.cs" Inherits="IOTSmartHome.AccessIOTDevice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Device management</h3>
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
                                        Select IOT Device</label>
                                    <asp:DropDownList ID="ddlIOTDevice" runat="server" class="form-control">
                                    </asp:DropDownList>
                                   
                                </div>
                                
                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
                                <div class="pull-right">
                                 <asp:Button ID="btnRecover" runat="server" Text="Recover"  class="btn btn-primary btn-sm pull-right"
                                        Style="padding: 10px 20px;" onclick="btnRecover_Click" />
                                    <asp:Button ID="btnON" runat="server" Text="ON"  class="btn btn-primary btn-sm pull-right"
                                        Style="padding: 10px 20px;" onclick="btnON_Click" />
                                    <asp:Button ID="btnOff" runat="server" Text="OFF"  class="btn btn-primary btn-sm pull-right"
                                        Style="padding: 10px 20px;" onclick="btnOff_Click" />
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
