<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="sorteos_sys.aspx.cs" Inherits="tombolaMercantil.sorteos_sys" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content" class="content">
        <asp:ObjectDataSource ID="odsSorteos" runat="server" SelectMethod="PR_SOR_GET_SORTEOS_ASIGNAR_SORTEO" TypeName="tombolaMercantil.Clases.Sorteos"></asp:ObjectDataSource>
        <asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label>
        <asp:Label ID="lblDominio" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblCodigo" runat="server" Text="3" Visible="false"></asp:Label>
        <asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
        <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
        <!-- begin page-header -->
        <h1 class="page-header">Administrador <small>Sorteos:</small></h1>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div class="row">
                    <div class="col">
                        <!-- begin form-group row -->
                        <div class="form-group row m-b-10">
                            <label class="col-md-3 text-md-right col-form-label">Seleccionar sorteo:</label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlSorteo" AutoPostBack="true" OnDataBound="ddlSorteo_DataBound" OnSelectedIndexChanged="ddlSorteo_SelectedIndexChanged" CssClass="form-control" DataSourceID="odsSorteos" DataTextField="DESCRIPCION" DataValueField="COD_SORTEO" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <!-- end form-group row -->
                        <!-- begin form-group row -->
                        <div class="form-group row m-b-10">
                            <label class="col-md-3 text-md-right col-form-label">Tipo sorteo:</label>
                            <div class="col-md-6">
                                <asp:Label ID="lblTipoSorteo" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <!-- end form-group row -->
                        <!-- begin form-group row -->
                        <div class="form-group row m-b-10">
                            <label class="col-md-3 text-md-right col-form-label">Cantidad de sorteos:</label>
                            <div class="col-md-6">
                                <asp:Label ID="lblCantidad" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <!-- end form-group row -->
                    </div>

                    <div class="col">
                        <asp:Image ID="imgLogo" runat="server" />
                    </div>

                </div>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-10">
                                <div class="row">
                                    <div class="col">
                                        <div class="row" style="font-size: 150px;">
                                            <div class="col">
                                                <asp:Image ID="Image2" Height="150" Width="100" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server"/>
                                                <asp:TextBox ID="txt1" Height="150" Width="100" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col">
                                                <asp:Image ID="Image1" Height="150" Width="100" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server"/>
                                                <asp:TextBox ID="txt2" Height="150" Width="100" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col">
                                                <asp:Image ID="Image3" Height="150" Width="100" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
                                                <asp:TextBox ID="txt3" Height="150" Width="100" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col">
                                                <asp:Image ID="Image4" Height="150" Width="100" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
                                                <asp:TextBox ID="txt4" Height="150" Width="100" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col">
                                                <asp:Image ID="Image5" Height="150" Width="100" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
                                                <asp:TextBox ID="txt5" Height="150" Width="100" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col">
                                                <asp:Image ID="Image6" Height="150" Width="100" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
                                                <asp:TextBox ID="txt6" Height="150" Width="100" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col">
                                                <asp:Image ID="Image7" Height="150" Width="100" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
                                                <asp:TextBox ID="txt7" Height="150" Width="100" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col">
                                                <asp:Image ID="Image8" Height="150" Width="100" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
                                                <asp:TextBox ID="txt8" Height="150" Width="100" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col">
                                                <asp:Image ID="Image9" Height="150" Width="100" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
                                                <asp:TextBox ID="txt9" Height="150" Width="100" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-2">
                                <asp:Button ID="btnGenerar" runat="server" CssClass="btn btn-success" Text="Genera Sorteo" Height="150" Width="150" OnClick="btnGenerar_Click" />
                                <br />
                                <br />
                                <asp:Button ID="btnResetear" runat="server" CssClass="btn btn-success" Text="Resetea Sorteo" Height="150" Width="150" OnClick="btnResetear_Click" />
                                <br />
                                <br />
                                <asp:Button ID="btnLimpiar" runat="server" CssClass="btn btn-success" Text="Limpia Sorteo" Height="150" Width="150" OnClick="btnLimpiar_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>
            <asp:View ID="View2" runat="server">
            </asp:View>
        </asp:MultiView>
    </div>
    <script>
        function AniDice() {
            MyVar = setInterval(rolldice, 1)
        }

        function rolldice() {
            var ranNum = Math.floor(1 + Math.random() * 6);
            document.getElementById('dice').innerHTML = ranNum;

        }
        function stopDice() {
            clearInterval(MyVar);
        }
    </script>
</asp:Content>
