<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Default2" %>

<!DOCTYPE html>
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
        <nav class="navbar navbar-expand-md navbar-dark bg-dark">
        <div class="container">
            <a class="navbar-brand" href="Default.aspx">Glass system</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
        </div>
    </nav>
    <section class="jumbotron text-center">
        <div class="container">
            <h1 class="jumbotron-heading">Glass</h1>
        </div>
    </section>
    <form id="form1" runat="server">
        <div class="col-md-8 order-md-1">
            <h4 class="mb-3">Glass Data:</h4>
            <div class="row">
                <div class="col-md-6 mb-3">
                    <label  >Aluminum</label>
                    <asp:TextBox ID="Aluminum" CssClass="form-control" runat="server" type="number" step="any"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Aluminum" ErrorMessage="Please input number" Display="Dynamic" ForeColor="Red" ValidationGroup="forma" />
                </div>
                <div class="col-md-6 mb-3">
                    <label  >Barium</label>
                    <asp:TextBox ID="Barium" CssClass="form-control" runat="server" type="number" step="any"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="BariumReq" runat="server" ControlToValidate="Barium" ErrorMessage="Please input number" Display="Dynamic" ForeColor="Red" ValidationGroup="forma" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 mb-3">
                    <label  >Calcium</label>
                    <asp:TextBox ID="Calcium" CssClass="form-control" runat="server" type="number" step="any"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Calcium" ErrorMessage="Please input number" Display="Dynamic" ForeColor="Red" ValidationGroup="forma" />
                </div>
                <div class="col-md-6 mb-3">
                    <label  >Iron</label>
                    <asp:TextBox ID="Iron" CssClass="form-control" runat="server" type="number" step="any"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Iron" ErrorMessage="Please input number" Display="Dynamic" ForeColor="Red" ValidationGroup="forma" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 mb-3">
                    <label  >Magnesium</label>
                    <asp:TextBox ID="Magnesium" CssClass="form-control" runat="server" type="number" step="any"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Magnesium" ErrorMessage="Please input number" Display="Dynamic" ForeColor="Red" ValidationGroup="forma" />
                </div>
                <div class="col-md-6 mb-3">
                    <label  >Potassium</label>
                    <asp:TextBox ID="Potassium" CssClass="form-control" runat="server" type="number" step="any"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Potassium" ErrorMessage="Please input number" Display="Dynamic" ForeColor="Red" ValidationGroup="forma" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 mb-3">
                    <label  >Refractive index</label>
                    <asp:TextBox ID="Refractiveindex" CssClass="form-control" runat="server" type="number" step="any"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Refractiveindex" ErrorMessage="Please input number" Display="Dynamic" ForeColor="Red" ValidationGroup="forma" />
                </div>
                <div class="col-md-6 mb-3">
                    <label  >Silicon</label>
                    <asp:TextBox ID="Silicon" CssClass="form-control" runat="server" type="number" step="any"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Silicon" ErrorMessage="Please input number" Display="Dynamic" ForeColor="Red" ValidationGroup="forma" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 mb-3">
                    <label  >Sodium</label>
                    <asp:TextBox ID="Sodium" CssClass="form-control" runat="server" type="number" step="any"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Sodium" ErrorMessage="Please input number" Display="Dynamic" ForeColor="Red" ValidationGroup="forma" />
                </div>
                <div class="col-md-6 mb-3">
                    <label  >Group</label>
                    <asp:DropDownList runat="server" ID="groupType" CssClass="form-control">
                        <asp:ListItem Text="building_windows_float_processed" Value="1"></asp:ListItem>
                        <asp:ListItem Text="building_windows_non_float_processed" Value="2"></asp:ListItem>
                        <asp:ListItem Text="vehicle_windows_float_processed" Value="3"></asp:ListItem>
                        <asp:ListItem Text="vehicle_windows_non_float_processed" Value="4"></asp:ListItem>
                        <asp:ListItem Text="containers" Value="5"></asp:ListItem>
                        <asp:ListItem Text="tableware" Value="6"></asp:ListItem>
                        <asp:ListItem Text="headlamps" Value="7"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 mb-3">
                    <asp:LinkButton CssClass="btn btn-dark" runat="server" Text="Back" PostBackUrl="~/Default.aspx"/>
                </div>
                <div class="col-md-6 mb-3">
                    <asp:Button CssClass="btn btn-dark" runat="server" ID="SaveBtn" Text="Save" OnClick="Unnamed_Click" ValidationGroup="forma"/>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
