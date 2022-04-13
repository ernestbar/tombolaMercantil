<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="sorteos_sys.aspx.cs" Inherits="tombolaMercantil.sorteos_sys" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content" class="content">

			<asp:ObjectDataSource ID="odsSorteos" runat="server" SelectMethod="PR_SOR_GET_SORTEOS_ASIGNAR_SORTEO" TypeName="tombolaMercantil.Clases.Sorteos">
			</asp:ObjectDataSource>

		<asp:ObjectDataSource ID="odsPremios" runat="server" SelectMethod="PR_SOR_GET_SORTEO_EN_ORDEN" TypeName="tombolaMercantil.Clases.Sorteos">
			<SelectParameters>
				<asp:ControlParameter ControlID="ddlSorteo" Name="PV_SORTEO" />
			</SelectParameters>
			</asp:ObjectDataSource>

		<asp:ObjectDataSource ID="odsGanadores" runat="server" SelectMethod="PR_SOR_GET_LISTA_SORTEO_EN_ORDEN" TypeName="tombolaMercantil.Clases.Sorteos">
			<SelectParameters>
				<asp:ControlParameter ControlID="ddlSorteo" Name="PV_SORTEO" />
			</SelectParameters>
			</asp:ObjectDataSource>

			<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
			<asp:Label ID="lblDominio" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblCodigo" runat="server" Text="3" Visible="false"></asp:Label>
		<asp:Label ID="lblCupon" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
			  <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
		<!-- begin page-header -->
		<h1 class="page-header">Administrador de Sorteos: <small></small></h1>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<div class="row" style="font-size:medium">
				<div class="col">
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-5 text-md-right col-form-label">Seleccionar sorteo:</label>
						<div class="col-md-6">
							<asp:DropDownList ID="ddlSorteo" AutoPostBack="true" Font-Size="Medium" OnDataBound="ddlSorteo_DataBound" OnSelectedIndexChanged="ddlSorteo_SelectedIndexChanged" CssClass="form-control" DataSourceID="odsSorteos" DataTextField="DESCRIPCION" DataValueField="COD_SORTEO" runat="server">
							</asp:DropDownList>
						</div>
					</div>
					<!-- end form-group row -->
								<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-5 text-md-right col-form-label">Tipo sorteo:</label>
						<div class="col-md-6">
							<asp:Label ID="lblTipoSorteo" CssClass="form-control" Font-Size="Medium" runat="server" Text=""></asp:Label>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-5 text-md-right col-form-label">Cantidad de sorteos:</label>
						<div class="col-md-6">
							<asp:Label ID="lblCantidad" CssClass="form-control label-success" Font-Bold="true" Font-Size="Large" runat="server" Text=""></asp:Label>
						</div>
					</div>
					<!-- end form-group row -->


			
				</div>

				<div class="col align-content-end">
					<asp:Image ID="imgLogo" runat="server" />
				</div>
				
				</div>	
			<div class="row">
				<asp:Panel ID="panel_opciones_sorteo" CssClass="row border shadow rounded" Visible="false" runat="server">
					
					<div class="col">
						<div class="row">
							<asp:Image ID="Image10" ImageUrl="~/Imagenes/tombola2.png" Height="100" runat="server" />
						</div>
						<div class="row">
							<asp:Button ID="btnIniciar" CssClass="btn btn-success" OnClick="btnGenerar_Click" runat="server" Text="Generar sorteo" />
						</div>
					</div>
					<div class="col">
						<div class="row">
							<asp:Image ID="Image12" ImageUrl="~/Imagenes/limpiar2.png" Height="100" runat="server" />
							
						</div>
						<div class="row">
							<asp:Button ID="btnLimpiar" CssClass="btn btn-success" OnClick="btnReset_Click" OnClientClick="return confirm('Seguro que desea limpar la pantalla???')" runat="server" Text="Limpiar pantalla" />
							
						</div>
					</div>
					<div class="col">
						<div class="row">
							<asp:Image ID="Image11" ImageUrl="~/Imagenes/reset2.png" Height="100" runat="server" />
						</div>
						<div class="row">
							<asp:Button ID="btnReset" CssClass="btn btn-success" OnClick="btnLimpiar_Click" OnClientClick="return confirm('Seguro que desea resetear el sorteo???')" runat="server" Text="Resetea sorteo" />
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

			<div class="row">
				<div class="col">
					<asp:Panel ID="panel_casillas_manuales" Visible="false" runat="server">
						<div class="row" style="font-size:150px">
						<div class="col">
							<asp:TextBox ID="txtM1" Height="200" Width="150" AutoPostBack="true" MaxLength="1" OnTextChanged="txtM1_TextChanged" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:TextBox ID="txtM2" Height="200" Width="150" AutoPostBack="true" MaxLength="1" OnTextChanged="txtM2_TextChanged" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:TextBox ID="txtM3" Height="200" Width="150" AutoPostBack="true" MaxLength="1" OnTextChanged="txtM3_TextChanged" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:TextBox ID="txtM4" Height="200" Width="150" AutoPostBack="true" MaxLength="1" OnTextChanged="txtM4_TextChanged" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:TextBox ID="txtM5" Height="200" Width="150" AutoPostBack="true" MaxLength="1" OnTextChanged="txtM5_TextChanged" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:TextBox ID="txtM6" Height="200" Width="150" AutoPostBack="true" MaxLength="1" OnTextChanged="txtM6_TextChanged" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:TextBox ID="txtM7" Height="200" Width="150" AutoPostBack="true" MaxLength="1" OnTextChanged="txtM7_TextChanged" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:TextBox ID="txtM8" Height="200" Width="150" AutoPostBack="true" MaxLength="1" OnTextChanged="txtM8_TextChanged" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:TextBox ID="txtM9" Height="200" Width="150" AutoPostBack="true" MaxLength="1" OnTextChanged="txtM9_TextChanged" runat="server"></asp:TextBox>
						</div>
					</div>
						<div class="row">
							<div class="col">
								<asp:Button ID="btnGuardarCuponManual" class="btn btn-success" OnClick="btnGuardarCuponManual_Click" runat="server" Text="Guardar cupon ganador" />
							</div>
							<div class="col">
								<asp:Button ID="btnLimpiarCasillas" class="btn btn-success" OnClick="btnLimpiarCasillas_Click" runat="server" Text="Limpiar casillas" />
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
			<!-- begin page-header -->
				<h1 class="page-header">Lista de Ganadores<small></small></h1>
			<!-- begin form-group row -->
			<div class="form-group row m-b-10">											
				<div class="col-md-6">
					<asp:Button ID="btnVolverSorteos" class="btn btn-success" OnClick="btnVolverSorteos_Click" runat="server" Text="Volver a sorteos" />
					<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
				</div>
			</div>
			<!-- end form-group row -->
			<div class="table-responsive">
				<!-- begin panel-body -->
				<div class="panel-body">
		<%--<div class="table-responsive">--%>
				<table id="data-table-default" class="table table-striped table-bordered">
					<thead>
						<tr>
							<th class="text-nowrap">NRO SORTEO</th>
							<th class="text-nowrap">CUPON</th>
							<th class="text-nowrap">PREMIO</th>
							<th class="text-nowrap">NOMBRE CLIENTE</th>
							<th class="text-nowrap">SUCURSAL</th>
							<th class="text-nowrap">CUENTA</th>
							<th class="text-nowrap">IDENTIFICACION</th>
							<th class="text-nowrap">BANCA</th>
							<th class="text-nowrap">MONEDA</th>
															
							</tr>
					</thead>
					<tbody>
                        <asp:Repeater ID="Repeater2" DataSourceID="odsGanadores" runat="server">
						<ItemTemplate>
							<tr class="gradeA">																
							<td><asp:Label ID="lblNro" runat="server" Text='<%# Eval("NRO_SORTEO") %>'></asp:Label></td>
								<td><asp:Label ID="lblPias" runat="server" Text='<%# Eval("CUPON") %>'></asp:Label></td>
								<td><asp:Label ID="lblCiudad" runat="server" Text='<%# Eval("PREMIO") %>'></asp:Label></td>
								<td><asp:Label ID="lblNombreSucursal" runat="server" Text='<%# Eval("NOMBRE_CLIENTE") %>'></asp:Label></td>
							<td><asp:Label ID="lblLatitud" runat="server" Text='<%# Eval("SUCURSAL") %>'></asp:Label></td>
							<td><asp:Label ID="lblLongitud" runat="server" Text='<%# Eval("CUENTA") %>'></asp:Label></td>
								<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("IDENTIFICACION") %>'></asp:Label></td>
								<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("BANCA") %>'></asp:Label></td>
								<td><asp:Label ID="Label3" runat="server" Text='<%# Eval("MONEDA") %>'></asp:Label></td>
															
						</tr>
						</ItemTemplate>
						</asp:Repeater>
														
													
					</tbody>
				</table>
			</div>
			<!-- end table-responsive -->
			</div>
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
