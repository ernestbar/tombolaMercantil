<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="sorteos_sys.aspx.cs" Inherits="tombolaMercantil.sorteos_sys" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content" class="content" style="background-image: url(Imagenes/FondoFull.png);background-repeat:no-repeat;">
		
		
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
		<asp:Label ID="lblNroDigitos" runat="server" Visible="false" Text=""></asp:Label> 
			<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
			<asp:Label ID="lblDominio" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblCodigo" runat="server" Text="3" Visible="false"></asp:Label>
		<asp:Label ID="lblCupon" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
			  <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
		<!-- begin page-header -->
		<h1 class="page-header" style="font-family:Calibri;color:white;font-size:xx-large"><strong>Administrador de Sorteos: </strong><small></small></h1>
		<br />
		
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<div class="row" style="font-size:medium">
				
				<div class="col justify-content-start">
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="form-label col-md-2" style="font-family:Calibri;color:white;font-size:larger">Seleccionar sorteo:</label>
						<div class="col-md-6">
							<asp:DropDownList ID="ddlSorteo" AutoPostBack="true" Font-Size="Medium" OnDataBound="ddlSorteo_DataBound" OnSelectedIndexChanged="ddlSorteo_SelectedIndexChanged" CssClass="form-control" DataSourceID="odsSorteos" DataTextField="DESCRIPCION" DataValueField="COD_SORTEO" runat="server">
							</asp:DropDownList>
						</div>
					</div>
					<!-- end form-group row -->
								<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="form-label col-md-2" style="font-family:Calibri;color:white;font-size:larger">Tipo sorteo:</label>
						<div class="col-md-6">
							<asp:Label ID="lblTipoSorteo" CssClass="form-control" Font-Size="Medium" runat="server" Text=""></asp:Label>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="form-label col-md-2" style="font-family:Calibri;color:white;font-size:larger">Cantidad de premios:</label>
						<div class="col-md-6">
							<asp:Label ID="lblCantidad" CssClass="form-control label-success" Font-Bold="true" Font-Size="Large" runat="server" Text=""></asp:Label>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10" >
						<label class="form-label col-md-2" style="font-family:Calibri;color:white;font-size:larger">Total  de cupones:</label>
						<div class="col-md-6">
							<asp:Label ID="lblTotalCupones" CssClass="form-control label-success" Font-Bold="true" Font-Size="Large" runat="server" Text=""></asp:Label>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10" >
						<label class="form-label col-md-2" style="font-family:Calibri;color:white;font-size:larger"></label>
						<div class="col-md-6">
							<asp:Image ID="Image14" Height="100px" ImageUrl="~/Imagenes/tituloFull.png" runat="server" />
						</div>
					</div>
					<!-- end form-group row -->
				</div>
				<br /><br />
				<div class="row justify-content-end">
				<div class="col">
					<asp:Image ID="imgLogo" Height="250px" runat="server" />
				</div>
				</div>
				
				</div>	
			
			<div class="row">
				<div class="col">
					<asp:Panel ID="panel_casillas_sorteo" Visible="false" runat="server">
						<table>
							<tr>
								<td>
										<asp:Image ID="Image9" Height="150" Width="100" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
							<asp:TextBox ID="txt9" Visible="false" Height="150" Width="100" runat="server"></asp:TextBox>
								</td>
								<td style="width:20px"></td>
								<td>
									<asp:Image ID="Image8" Height="150" Width="100" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
							<asp:TextBox ID="txt8" Visible="false" Height="150" Width="100" runat="server"></asp:TextBox>
								</td>
								<td style="width:20px"></td>
								<td>
									<asp:Image ID="Image7" Height="150" Width="100" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
							<asp:TextBox ID="txt7" Visible="false" Height="150" Width="100" runat="server"></asp:TextBox>
								</td>
								<td style="width:20px"></td>
								<td>
									<asp:Image ID="Image6" Height="150" Width="100" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
							<asp:TextBox ID="txt6" Visible="false" Height="150" Width="100" runat="server"></asp:TextBox>
								</td>
								<td style="width:20px"></td>
								<td>
									<asp:Image ID="Image5" Height="150" Width="100" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
							<asp:TextBox ID="txt5" Visible="false" Height="150" Width="100" runat="server"></asp:TextBox>
								</td>
								<td style="width:20px"></td>
								<td>
									<asp:Image ID="Image4" Height="150" Width="100" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
							<asp:TextBox ID="txt4" Visible="false" Height="150" Width="100" runat="server"></asp:TextBox>
								</td>
								<td style="width:20px"></td>
								<td>
									<asp:Image ID="Image3" Height="150" Width="100" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
							<asp:TextBox ID="txt3" Visible="false" Height="150" Width="100" runat="server"></asp:TextBox>
								</td>
								<td style="width:20px"></td>
								<td>
									<asp:Image ID="Image2" Height="150" Width="100" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
							<asp:TextBox ID="txt2" Visible="false" Height="150" Width="100" runat="server"></asp:TextBox>
								</td>
								<td style="width:20px"></td>
								<td>
									<asp:Image ID="Image1" Height="150" Width="100" ImageUrl="~/Imagenes/numeros digitales.gif" runat="server" />
							<asp:TextBox ID="txt1" Visible="false" Height="150" Width="100" runat="server"></asp:TextBox>
								</td>
							</tr>
						</table>
						<asp:Panel ID="Panel_digital" runat="server">
							<div class="row">
								<div class="col">
								<asp:Button ID="btnSiguiente" class="btn btn-success" OnClick="btnSiguiente_Click" runat="server" Text="Siguiente digito" />
								</div>
								<div class="col">
									<asp:Button ID="btnGuardarGanadorDigital" class="btn btn-success" OnClick="btnGuardarGanadorDigital_Click" runat="server" Text="Guardar ganador" />
								</div>
								<div class="col">
									<asp:Button ID="btnOtroSorteoDigital" class="btn btn-success" OnClick="btnOtroSorteoDigital_Click" Visible="false" runat="server" Text="Realizar otro sorteo" />
								</div>
							</div>
						</asp:Panel>
					</asp:Panel>
				</div>
			</div>

			<div class="row">
				<div class="col">
					<asp:Panel ID="panel_casillas_manuales" Visible="false" runat="server">
						<table style="text-align:center">
							<tr>
								<td>
									<asp:TextBox ID="txtM9" Height="150" Width="100" CssClass="rounded-corner" BackColor="#548b6b" ForeColor="White" Font-Names="Arial" Font-Size="100" MaxLength="1" runat="server"></asp:TextBox>
								</td>
								<td style="width:20px"></td>
								<td>
									<asp:TextBox ID="txtM8" Height="150" Width="100" CssClass="rounded-corner" BackColor="#548b6b" ForeColor="White" Font-Names="Arial" Font-Size="100"  MaxLength="1" runat="server"></asp:TextBox>
								</td>
								<td style="width:20px"></td>
								<td>
									<asp:TextBox ID="txtM7" Height="150" Width="100" CssClass="rounded-corner" BackColor="#548b6b" ForeColor="White" Font-Names="Arial" Font-Size="100"  MaxLength="1" runat="server"></asp:TextBox>
								</td>
								<td style="width:20px"></td>
								<td>
									<asp:TextBox ID="txtM6" Height="150" Width="100" CssClass="rounded-corner" BackColor="#548b6b" ForeColor="White" Font-Names="Arial" Font-Size="100"  MaxLength="1" runat="server"></asp:TextBox>
								</td>
								<td style="width:20px"></td>
								<td>
									<asp:TextBox ID="txtM5" Height="150" Width="100" CssClass="rounded-corner" BackColor="#548b6b" ForeColor="White" Font-Names="Arial" Font-Size="100"  MaxLength="1" runat="server"></asp:TextBox>
								</td>
								<td style="width:20px"></td>
								<td>
									<asp:TextBox ID="txtM4" Height="150" Width="100" CssClass="rounded-corner" BackColor="#548b6b" ForeColor="White" Font-Names="Arial" Font-Size="100"  MaxLength="1" runat="server"></asp:TextBox>
								</td>
								<td style="width:20px"></td>
								<td>
									<asp:TextBox ID="txtM3" Height="150" Width="100" CssClass="rounded-corner" BackColor="#548b6b" ForeColor="White" Font-Names="Arial" Font-Size="100"  MaxLength="1" runat="server"></asp:TextBox>
								</td>
								<td style="width:20px"></td>
								<td>
									<asp:TextBox ID="txtM2" Height="150" Width="100" CssClass="rounded-corner" BackColor="#548b6b" ForeColor="White" Font-Names="Arial" Font-Size="100"  MaxLength="1"  runat="server"></asp:TextBox>
								</td>
								<td style="width:20px"></td>
								<td>
									<asp:TextBox ID="txtM1" Height="150" Width="100" CssClass="rounded-corner" BackColor="#548b6b" ForeColor="White" Font-Names="Arial" Font-Size="100"  MaxLength="1" runat="server" ></asp:TextBox>
								</td>
							</tr>
						</table>
						<div class="row">
							<%--<div class="col">
								<asp:Button ID="btnVerificarCuponManual" class="btn btn-success" OnClick="btnVerificarCuponManual_Click" runat="server" Text="Verificar Cupon" />
							</div>--%>
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
								<label class="col-md-3 text-md-right col-form-label" style="font-family:Calibri;color:white;font-size:larger">GANADOR SORTEO</label>
								<div class="col-md-6">
									<asp:Label ID="lblGanador" CssClass="form-control label-success" Font-Bold="true" Font-Size="Large" runat="server" Text=""></asp:Label>
								</div>
							</div>
							<!-- end form-group row -->
							<!-- begin form-group row -->
							<div class="form-group row m-b-10">
								<label class="col-md-3 text-md-right col-form-label" style="font-family:Calibri;color:white;font-size:larger">PREMIO</label>
								<div class="col-md-6">
									<asp:Label ID="lblPremio" CssClass="form-control label-success" Font-Bold="true" Font-Size="Large" runat="server" Text=""></asp:Label>
								</div>
							</div>
							<!-- end form-group row -->
							<!-- begin form-group row -->
							<div class="form-group row m-b-10">
								<label class="col-md-3 text-md-right col-form-label"></label>
								<div class="col-md-6">
									<asp:Button ID="btnListaGanadores" CssClass="btn" BackColor="BurlyWood" ForeColor="White" OnClick="btnListaGanadores_Click" runat="server" Text="Lista Ganadores" />
								</div>
							</div>
							<!-- end form-group row -->
					</asp:Panel>
				
			</div>
			<div class="row justify-content-center">
				<div class="col">
					<asp:Image ID="Image13" runat="server" ImageUrl="~/Imagenes/AJFull.png" />
					</div>
				<asp:Panel ID="panel_opciones_sorteo" CssClass="row" Visible="false" runat="server">
					
					<div class="col">
						<asp:Panel ID="Panel_masivo_opcion" runat="server">
							<div class="row">
							<asp:Image ID="Image10" ImageUrl="~/Imagenes/generar_sorteo.png" Height="50" runat="server" />
						</div>
						<div class="row">
							<asp:Button ID="btnIniciar" CssClass="btn btn-success" OnClick="btnGenerar_Click" runat="server" Text="Generar sorteo" />
						</div>
						</asp:Panel>
						
					</div>
					<div class="col">
						<div class="row">
							<asp:Image ID="Image12" ImageUrl="~/Imagenes/clean.png" Height="50" runat="server" />
							
						</div>
						<div class="row">
							<asp:Button ID="btnLimpiar" CssClass="btn btn-success" OnClick="btnReset_Click" OnClientClick="return confirm('Seguro que desea limpar la pantalla???')" runat="server" Text="Limpiar pantalla" />
							
						</div>
					</div>
					<div class="col">
						<div class="row">
							<asp:Image ID="Image11" ImageUrl="~/Imagenes/reset.png" Height="50" runat="server" />
						</div>
						<div class="row">
							<asp:Button ID="btnReset" CssClass="btn btn-success" OnClick="btnLimpiar_Click" OnClientClick="return confirm('Seguro que desea resetear el sorteo???')" runat="server" Text="Resetea sorteo" />
						</div>
					</div>
				</asp:Panel>
				<div class="col">
					<asp:Image ID="Image15" runat="server" ImageUrl="~/Imagenes/logobmscFull.PNG" Height="200px" />
					</div>
				</div>
				
        </asp:View>
		<asp:View ID="View2" runat="server">
			<!-- begin page-header -->
				<h1 class="page-header" style="color:white">Lista de Ganadores<small></small></h1>
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
				<table id="data-table-default" class="table table-striped table-bordered" style="background-color:white">
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
