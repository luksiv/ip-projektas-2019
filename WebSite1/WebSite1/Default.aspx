<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">
        function confirmDelete() { return (confirm('Are you sure that you want to delete the item?')); }
    </script>
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
    <form class="container mb-4" runat="server">
        <div class="row">
            <div class="col-12">
                <div class="table-responsive">
                    
                                    <div class="text-left">
                                        <asp:LinkButton runat="server" PostBackUrl="~/Default2.aspx" CssClass="btn btn-sm btn-success"><i class="fa fa-plus"></i> Add new</asp:LinkButton>
                                    </div>
                    <asp:Repeater runat="server" ID="Glass_data_table">
                        <HeaderTemplate>
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th scope="col">ID</th>
                                        <th scope="col">Refractive index</th>
                                        <th scope="col">Sodium</th>
                                        <th scope="col">Magnesium</th>
                                        <th scope="col">Aluminum</th>
                                        <th scope="col">Silicon</th>
                                        <th scope="col">Potassium</th>
                                        <th scope="col">Calcium</th>
                                        <th scope="col">Barium</th>
                                        <th scope="col">Iron</th>
                                        <th scope="col">Type of glass</th>
                                        <th></th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tbody runat="server" id="Table_data_holder">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCustomerId" runat="server" Text='<%# Eval("id") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Refractive_index") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Sodium") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Magnesium") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("Aluminum") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Silicon") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("Potassium") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Calcium") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("Barium") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("Iron") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("type") %>' />
                                    </td>
                                    <td class="text-right">
                                        <asp:LinkButton runat="server" CssClass="btn btn-sm btn-danger" ID="Delete_btn" OnClientClick="return confirmDelete();" OnClick="Delete_btn_Click" CommandArgument='<%# Eval("id") %>' CommandName="Delete"><i class="fa fa-trash"></i></asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-sm btn-primary" ID="Edit_btn" CommandName="Edit" OnClick="Edit_btn_Click" CommandArgument='<%# Eval("id") %>'><i class="fa fa-edit"></i></asp:LinkButton>
                                    </td>
                                </tr>
                            </tbody>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </form>

    <!-- Footer -->
    <footer class="text-light">
        <div class="col-12 mt-3 fixed-bottom">
            <%--<form runat="server">
                <asp:LinkButton CssClass="btn btn-sm btn-primary" runat="server" ID="LinkButton1" href="#"><i class="fa fa-arrow-up"></i></asp:LinkButton>
            </form>--%>
        </div>
    </footer>
</body>
</html>
