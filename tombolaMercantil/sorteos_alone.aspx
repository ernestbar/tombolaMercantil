<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sorteos_alone.aspx.cs" Inherits="tombolaMercantil.sorteos_alone" %>

<!DOCTYPE html>

<html>
<head>
	<meta charset="utf-8" />
	<title>BMSC Sorteos</title>
	<meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport" />
	<meta content="" name="description" />
	<meta content="" name="author" />
	
	<!-- ================== BEGIN BASE CSS STYLE ================== -->
	<link href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700" rel="stylesheet" />
	<link href="assets/plugins/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
	<link href="assets/plugins/bootstrap/4.1.3/css/bootstrap.min.css" rel="stylesheet" />
	<link href="assets/plugins/font-awesome/5.3/css/all.min.css" rel="stylesheet" />
	<link href="assets/plugins/animate/animate.min.css" rel="stylesheet" />
	<link href="assets/css/default/style.min.css" rel="stylesheet" />
	<link href="assets/css/default/style-responsive.min.css" rel="stylesheet" />
	<link href="assets/css/default/theme/green.css" rel="stylesheet" id="theme" />
	<!-- ================== END BASE CSS STYLE ================== -->
	
	<!-- ================== BEGIN PAGE LEVEL STYLE ================== -->
	<link href="assets/plugins/jquery-smart-wizard/src/css/smart_wizard.css" rel="stylesheet" />
	<!-- ================== END PAGE LEVEL STYLE ================== -->
	
	<!-- ================== BEGIN PAGE LEVEL CSS STYLE ================== -->
	<link href="assets/plugins/jquery-jvectormap/jquery-jvectormap.css" rel="stylesheet" />
	<link href="assets/plugins/bootstrap-calendar/css/bootstrap_calendar.css" rel="stylesheet" />
	<link href="assets/plugins/gritter/css/jquery.gritter.css" rel="stylesheet" />
	<link href="assets/plugins/nvd3/build/nv.d3.css" rel="stylesheet" />

	<link href="assets/plugins/DataTables/media/css/dataTables.bootstrap.min.css" rel="stylesheet" />
	<link href="assets/plugins/DataTables/extensions/RowReorder/css/rowReorder.bootstrap.min.css" rel="stylesheet" />
	<link href="assets/plugins/DataTables/extensions/Responsive/css/responsive.bootstrap.min.css" rel="stylesheet" />
	<link href="assets/plugins/DataTables/extensions/Buttons/css/buttons.bootstrap.min.css" rel="stylesheet" />
	<link href="assets/plugins/DataTables/extensions/ColReorder/css/colReorder.bootstrap.min.css" rel="stylesheet" />
	<!-- ================== END PAGE LEVEL CSS STYLE ================== -->
	<link href="assets/plugins/jquery-smart-wizard/src/css/smart_wizard.css" rel="stylesheet" />
	<link href="assets/plugins/parsley/src/parsley.css" rel="stylesheet" />
	<!-- ================== BEGIN BASE JS ================== -->
	<script src="assets/plugins/pace/pace.min.js"></script>
	<!-- ================== END BASE JS ================== -->
	<script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB6XhmQ0TrlvdgfDu59q1lTyBp5NskGo7I&region=BO&callback=initMap"></script>
	 
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>

	 <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
</head>
<body>
	<!-- begin #page-loader -->
	<div id="page-loader" class="fade show"><span class="spinner"></span></div>
	<!-- end #page-loader -->
	<!-- begin #page-container -->
	<div id="page-container" class="fade page-sidebar-fixed page-header-fixed">
		<!-- begin #header -->
		<div id="header" class="header navbar-default">
			<!-- begin navbar-header -->
			<div class="navbar-header">
				<img src="Imagenes/logo_bmsc.png" />
				
				<button type="button" class="navbar-toggle" data-click="sidebar-toggled">
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
				</button>
			</div>
			<!-- end navbar-header -->
			
			<!-- begin header-nav -->
			<ul class="navbar-nav navbar-right">
				<%--<li>
					<form class="navbar-form">
						<div class="form-group">
							<input type="text" class="form-control" placeholder="Enter keyword" />
							<button type="submit" class="btn btn-search"><i class="fa fa-search"></i></button>
						</div>
					</form>
				</li>--%>
	<asp:Label ID="lblSistema" runat="server" Visible="false" Text="BO"></asp:Label>
				<li class="dropdown navbar-user">
					<a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown">
						<img src="assets/img/user/user-13.jpg" alt="" /> 
						<span class="d-none d-md-inline"><asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label> </span> <b class="caret"></b>
					</a>
					<div class="dropdown-menu dropdown-menu-right">
						<a href="cambio_password.aspx" class="dropdown-item">Cambiar password</a>
						<div class="dropdown-divider"></div>
						<a href="login.aspx" class="dropdown-item">Salir</a>
					</div>
				</li>
			</ul>
			<!-- end header navigation right -->
		</div>
		<!-- end #header -->
		</div>
    <form id="form1" class="form-control-with-bg" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="content">
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

			<asp:Label ID="Label1" runat="server" Visible="false" Text=""></asp:Label> 
			<asp:Label ID="lblDominio" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblCodigo" runat="server" Text="3" Visible="false"></asp:Label>
		<asp:Label ID="lblCupon" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
			  <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
		<!-- begin page-header -->
			<br /><br />
			<!-- begin form-group row -->
			<div class="form-group row m-b-10">											
				<div class="col-md-6">
                    <asp:Button ID="btnVolverHome" class="btn btn-success" ValidationGroup="archivo" OnClick="btnVolverHome_Click" runat="server" Text="Volver al home" />
					<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
				</div>
			</div>
			<!-- end form-group row -->
		<h1 class="page-header">Administrador de Sorteos: <small></small></h1>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<div class="row" style="font-size:medium">
				<div class="col">
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Seleccionar sorteo:</label>
						<div class="col-md-6">
							<asp:DropDownList ID="ddlSorteo" AutoPostBack="true" Font-Size="Medium" OnDataBound="ddlSorteo_DataBound" OnSelectedIndexChanged="ddlSorteo_SelectedIndexChanged" CssClass="form-control" DataSourceID="odsSorteos" DataTextField="DESCRIPCION" DataValueField="COD_SORTEO" runat="server">
							</asp:DropDownList>
						</div>
					</div>
					<!-- end form-group row -->
								<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Tipo sorteo:</label>
						<div class="col-md-6">
							<asp:Label ID="lblTipoSorteo" CssClass="form-control" Font-Size="Medium" runat="server" Text=""></asp:Label>
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

				<div class="col">
					<div class="row">
						<div class="col-12 col-md-4">
							<asp:Panel ID="panel_premios" runat="server">
								<table id="data-table" class="table table-striped table-bordered">
									<thead>
										<tr>
											<th class="text-nowrap">NRO. PREMIO</th>
											<th class="text-nowrap">DESCRIPCION</th>
											<%--<th class="text-nowrap">OPCIONES</th>--%>
											</tr>
									</thead>
									<tbody>
										<asp:Repeater ID="Repeater1" DataSourceID="odsPremios" runat="server">
											<ItemTemplate>
													<tr class="gradeA">		
														<td><asp:Label ID="Label3" runat="server" Text='<%# Eval("NRO_SORTEO") %>'></asp:Label></td>
														<td><asp:Label ID="Label4" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label></td>
														<%--<td> <asp:Button ID="btnAsignarCupon" CssClass="btn btn-success" OnClick="btnAsignarCupon_Click" CommandArgument='<%# Eval("COD_SORTEO_DETALLE") %>' runat="server" Text="Asignar cupon a premio" /></td>--%>
													</tr>
											</ItemTemplate>
										</asp:Repeater>
                       
							
														
													
									</tbody>
								</table>
							</asp:Panel>
							
						</div>
				
					</div>
				</div>
				</div>	
			<div class="row">
				<asp:Panel ID="panel_opciones_sorteo" CssClass="row" Visible="false" runat="server">
					
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
							<asp:TextBox ID="txtM1" Height="200" Width="150" AutoPostBack="true" AutoCompleteType="Disabled" OnTextChanged="txtM1_TextChanged" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:TextBox ID="txtM2" Height="200" Width="150" AutoPostBack="true" AutoCompleteType="Disabled" OnTextChanged="txtM2_TextChanged" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:TextBox ID="txtM3" Height="200" Width="150" AutoPostBack="true" AutoCompleteType="Disabled" OnTextChanged="txtM3_TextChanged" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:TextBox ID="txtM4" Height="200" Width="150" AutoPostBack="true" AutoCompleteType="Disabled" OnTextChanged="txtM4_TextChanged" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:TextBox ID="txtM5" Height="200" Width="150" AutoPostBack="true" AutoCompleteType="Disabled" OnTextChanged="txtM5_TextChanged" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:TextBox ID="txtM6" Height="200" Width="150" AutoPostBack="true" AutoCompleteType="Disabled" OnTextChanged="txtM6_TextChanged" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:TextBox ID="txtM7" Height="200" Width="150" AutoPostBack="true" AutoCompleteType="Disabled" OnTextChanged="txtM7_TextChanged" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:TextBox ID="txtM8" Height="200" Width="150" AutoPostBack="true" AutoCompleteType="Disabled" OnTextChanged="txtM8_TextChanged" runat="server"></asp:TextBox>
						</div>
						<div class="col">
							<asp:TextBox ID="txtM9" Height="200" Width="150" AutoPostBack="true" AutoCompleteType="Disabled" OnTextChanged="txtM9_TextChanged" runat="server"></asp:TextBox>
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
    </form>
	<!-- ================== BEGIN BASE JS ================== -->
	<script src="assets/plugins/jquery/jquery-3.3.1.min.js"></script>
	<script src="assets/plugins/jquery-ui/jquery-ui.min.js"></script>
	<script src="assets/plugins/bootstrap/4.1.3/js/bootstrap.bundle.min.js"></script>
	<!--[if lt IE 9]>
		<script src="assets/crossbrowserjs/html5shiv.js"></script>
		<script src="assets/crossbrowserjs/respond.min.js"></script>
		<script src="assets/crossbrowserjs/excanvas.min.js"></script>
	<![endif]-->
	<script src="assets/plugins/slimscroll/jquery.slimscroll.min.js"></script>
	<script src="assets/plugins/js-cookie/js.cookie.js"></script>
	<script src="assets/js/theme/default.min.js"></script>
	<script src="assets/js/apps.min.js"></script>
	<!-- ================== END BASE JS ================== -->
	
	<!-- ================== BEGIN PAGE LEVEL JS ================== -->
	<script src="assets/plugins/d3/d3.min.js"></script>
	<script src="assets/plugins/nvd3/build/nv.d3.js"></script>
	<script src="assets/plugins/jquery-jvectormap/jquery-jvectormap.min.js"></script>
	<script src="assets/plugins/jquery-jvectormap/jquery-jvectormap-world-merc-en.js"></script>
	<script src="assets/plugins/bootstrap-calendar/js/bootstrap_calendar.min.js"></script>
	<%--<script src="assets/plugins/gritter/js/jquery.gritter.js"></script>--%>
	<script src="assets/js/demo/dashboard-v2.min.js"></script>
	<script src="assets/js/demo/form-wizards.demo.min.js"></script>
	<script src="assets/plugins/jquery-smart-wizard/src/js/jquery.smartWizard.js"></script>

	<script src="assets/plugins/DataTables/media/js/jquery.dataTables.js"></script>
	<script src="assets/plugins/DataTables/media/js/dataTables.bootstrap.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Responsive/js/dataTables.responsive.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/RowReorder/js/dataTables.rowReorder.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/ColReorder/js/dataTables.colReorder.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/dataTables.buttons.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/buttons.bootstrap.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/buttons.flash.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/jszip.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/pdfmake.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/vfs_fonts.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/buttons.html5.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/buttons.print.min.js"></script>
	<script src="assets/js/demo/table-manage-default.demo.min.js"></script>
	<script src="assets/js/demo/table-manage-buttons.demo.min.js"></script>
	<script src="assets/js/demo/table-manage-rowreorder.demo.min.js"></script>
	<script src="assets/js/demo/table-manage-colreorder.demo.min.js"></script>
	<!-- ================== END PAGE LEVEL JS ================== -->
	
	<script src="assets/plugins/parsley/dist/parsley.js"></script>
	<script src="assets/plugins/highlight/highlight.common.js"></script>
	<script src="assets/js/demo/render.highlight.js"></script>
	<script src="assets/plugins/jquery-smart-wizard/src/js/jquery.smartWizard.js"></script>
	<script src="assets/plugins/jquery-smart-wizard/src/js/jquery.smartWizard.js"></script>
	<script src="assets/js/demo/form-wizards-validation.demo.min.js"></script>
	<%--<script src="assets/js/demo/form-wizards-validation.demo.min.js"></script>--%>

	
	<script>
		$(document).ready(function() {
			App.init();
			DashboardV2.init();
            Highlight.init();
			FormWizard.init();
            
			TableManageDefault.init();
			TableManageRowReorder.init();
			TableManageButtons.init();
            TableManageResponsive.init();
			TableManageColReorder.init();
			
            
		});
        var map;
        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: -34.397, lng: 150.644 },
                zoom: 8
            });
        }
    </script>

	
</body>
</html>