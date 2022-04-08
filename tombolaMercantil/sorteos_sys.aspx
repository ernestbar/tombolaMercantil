<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="sorteos_sys.aspx.cs" Inherits="tombolaMercantil.sorteos_sys" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content" class="content">

			<asp:ObjectDataSource ID="odsSorteos" runat="server" SelectMethod="PR_SOR_GET_SORTEOS_ASIGNAR_SORTEO" TypeName="tombolaMercantil.Clases.Sorteos">
			</asp:ObjectDataSource>
			<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
			<asp:Label ID="lblDominio" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblCodigo" runat="server" Text="3" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
			  <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
		<!-- begin page-header -->
		<h1 class="page-header">Administrador de Sorteos: <small></small></h1>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<div class="row" style="font-size:large">
				<div class="col">
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Seleccionar sorteo:</label>
						<div class="col-md-6">
							<asp:DropDownList ID="ddlSorteo" AutoPostBack="true" Font-Bold="true" Font-Size="Large" OnDataBound="ddlSorteo_DataBound" OnSelectedIndexChanged="ddlSorteo_SelectedIndexChanged" CssClass="form-control" DataSourceID="odsSorteos" DataTextField="DESCRIPCION" DataValueField="COD_SORTEO" runat="server">
							</asp:DropDownList>
						</div>
					</div>
					<!-- end form-group row -->
								<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Tipo sorteo:</label>
						<div class="col-md-6">
							<asp:Label ID="lblTipoSorteo" CssClass="form-control" Font-Bold="true" Font-Size="Large" runat="server" Text=""></asp:Label>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Cantidad de sorteos:</label>
						<div class="col-md-6">
							<asp:Label ID="lblCantidad" CssClass="form-control label-success" Font-Bold="true" Font-Size="Large" runat="server" Text=""></asp:Label>
						</div>
					</div>
					<!-- end form-group row -->


			
				</div>
				<div class="col">
					<asp:Image ID="imgLogo" runat="server" />
				</div>
				
				</div>	
			<div class="row">
				<asp:Panel ID="panel_opciones_sorteo" CssClass="row" Visible="false" runat="server">
					
					<div class="col">
						<div class="row">
							<asp:Image ID="Image10" ImageUrl="~/Imagenes/tombola2.png" Height="100" runat="server" />
						</div>
						<div class="row">
							<asp:Button ID="btnIniciar" CssClass="btn btn-success sidebar-minify" OnClick="btnIniciar_Click" runat="server" Text="Generar sorteo" />
						</div>
					</div>
					<div class="col">
						<div class="row">
							<asp:Image ID="Image11" ImageUrl="~/Imagenes/reset2.png" Height="100" runat="server" />
						</div>
						<div class="row">
							<asp:Button ID="btnReset" CssClass="btn btn-success" OnClick="btnReset_Click" runat="server" Text="Resetea sorteo" />
						</div>
					</div>
					<div class="col">
						<div class="row">
							<asp:Image ID="Image12" ImageUrl="~/Imagenes/limpiar2.png" Height="100" runat="server" />
						</div>
						<div class="row">
							<asp:Button ID="btnLimpiar" CssClass="btn btn-success" OnClick="btnLimpiar_Click" runat="server" Text="Limpa sorteo" />
						</div>
					</div>
				</asp:Panel>
				
				</div>
			<div class="row">
				<div class="col">
					<asp:Panel ID="panel_casillas_sorteo" Visible="false" runat="server">
						<div class="row" style="font-size:150px">
						<div class="col">
							<asp:Image ID="Image2" Height="200" Width="150" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
							<asp:TextBox ID="txt1" Height="200" Width="150" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:Image ID="Image1" Height="200" Width="150" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
							<asp:TextBox ID="txt2" Height="200" Width="150" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:Image ID="Image3" Height="200" Width="150" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
							<asp:TextBox ID="txt3" Height="200" Width="150" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:Image ID="Image4" Height="200" Width="150" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
							<asp:TextBox ID="txt4" Height="200" Width="150" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:Image ID="Image5" Height="200" Width="150" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
							<asp:TextBox ID="txt5" Height="200" Width="150" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:Image ID="Image6" Height="200" Width="150" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
							<asp:TextBox ID="txt6" Height="200" Width="150" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:Image ID="Image7" Height="200" Width="150" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
							<asp:TextBox ID="txt7" Height="200" Width="150" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:Image ID="Image8" Height="200" Width="150" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
							<asp:TextBox ID="txt8" Height="200" Width="150" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:Image ID="Image9" Height="200" Width="150" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
							<asp:TextBox ID="txt9" Height="200" Width="150" runat="server"></asp:TextBox>
						</div>
					</div>
					</asp:Panel>
				</div>
				
			</div>
			<div class="row" style="font-size:large">
					<asp:Panel ID="panel_ganador" CssClass="col" Visible="false" runat="server">
							<!-- begin form-group row -->
							<div class="form-group row m-b-10">
								<label class="col-md-3 text-md-right col-form-label">GANADOR SORTEO</label>
								<div class="col-md-6">
									<asp:Label ID="lblGanador" CssClass="form-control label-success" Font-Bold="true" Font-Size="Large" runat="server" Text=""></asp:Label>
								</div>
							</div>
							<!-- end form-group row -->
							<!-- begin form-group row -->
							<div class="form-group row m-b-10">
								<label class="col-md-3 text-md-right col-form-label">PREMIO</label>
								<div class="col-md-6">
									<asp:Label ID="lblPremio" CssClass="form-control label-success" Font-Bold="true" Font-Size="Large" runat="server" Text=""></asp:Label>
								</div>
							</div>
							<!-- end form-group row -->
							<!-- begin form-group row -->
							<div class="form-group row m-b-10">
								<label class="col-md-3 text-md-right col-form-label"></label>
								<div class="col-md-6">
									<asp:Button ID="btnListaGanadores" CssClass="btn btn-success" OnClick="btnListaGanadores_Click" runat="server" Text="Lista Ganadores" />
								</div>
							</div>
							<!-- end form-group row -->
					</asp:Panel>
				
			</div>
        </asp:View>
		<asp:View ID="View2" runat="server">

        </asp:View>
	</asp:MultiView>
</div>
	<script>
		function AniDice()
		{
			MyVar=setInterval(rolldice,1)
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
