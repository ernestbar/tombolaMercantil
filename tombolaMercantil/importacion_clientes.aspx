<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="importacion_clientes.aspx.cs" Inherits="tombolaMercantil.importacion_clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    
	
	<style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .ErrorControl
        {
            background-color: #FBE3E4;
            border: solid 1px Red;
        }
    </style>
	<script type="text/javascript">
        function WebForm_OnSubmit() {
            if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                for (var i in Page_Validators) {
                    try {
                        var control = document.getElementById(Page_Validators[i].controltovalidate);
                        if (!Page_Validators[i].isvalid) {
                            control.className = "form-control ErrorControl";
                        } else {
                            control.className = "form-control";
                        }
                    } catch (e) { }
                }
                return false;
            }
            return true;
        }
    </script>
    
	<asp:ObjectDataSource ID="odsTipoArchivo" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="tombolaMercantil.Clases.Dominios">
        <SelectParameters>
            <asp:Parameter DefaultValue="TIPO ARCHIVO" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsSorteos" runat="server" SelectMethod="PR_SOR_GET_SORTEOS_ASIGNAR" TypeName="tombolaMercantil.Clases.Sorteos">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsImportacion" runat="server" SelectMethod="lista" TypeName="tombolaMercantil.Clases.Importacion">
	</asp:ObjectDataSource>    
	<!-- begin #content -->
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<Triggers>
			<asp:PostBackTrigger ControlID="Repeater1" />
		</Triggers>
		<ContentTemplate>--%>

		
		<div id="content" class="content">
			<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
			<asp:Label ID="lblCodImportacionDatos" runat="server" Text="0" Visible="false"></asp:Label>
			<asp:Label ID="lblCodImportacionDetalle" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
             <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			
									
										<!-- begin page-header -->
											<h1 class="page-header">Administrar Importacion de clientes <small></small></h1>
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">											
											<div class="col-md-6">
                                                <asp:Button ID="btnNuevoCliente" class="btn btn-success" ValidationGroup="archivo" OnClick="btnNuevoCliente_Click" runat="server" Text="Importar Clientes" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Archivo a importar:</label>
											<div class="col-md-6">
												<asp:FileUpload ID="fuArchivo" ValidationGroup="archivo" runat="server" />
												<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="archivo" runat="server" ErrorMessage="*" ControlToValidate="fuArchivo" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										 <!-- begin form-group row -->
											<div class="form-group row m-b-10">
												<label class="col-md-3 text-md-right col-form-label">Tipo Archivo:</label>
												<div class="col-md-6">
														<asp:DropDownList ID="ddlTipoArchivo" class="form-control" ValidationGroup="archivo" OnDataBound="ddlTipoArchivo_DataBound" DataSourceID="odsTipoArchivo" DataTextField="descripcion" DataValueField="codigo" ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ValidationGroup="archivo" ForeColor="Red" ControlToValidate="ddlTipoArchivo" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
												</div>  
											</div>
											<!-- end form-group row --> 
											  <!-- begin form-group row -->
											<div class="form-group row m-b-10">
												<label class="col-md-3 text-md-right col-form-label">Tipo sorteo:</label>
												<div class="col-md-6">
														 <asp:DropDownList ID="ddlTipoSorteo" class="form-control" DataSourceID="odsSorteos" ValidationGroup="archivo" OnDataBound="ddlTipoSorteo_DataBound" DataTextField="descripcion" DataValueField="cod_sorteo"  ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMesssage="*" ForeColor="Red" ValidationGroup="archivo" ControlToValidate="ddlTipoSorteo" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
												</div>
											</div>
											<!-- end form-group row -->
											<!-- end page-header -->
											<!-- begin panel -->
											<div class="panel panel-inverse">
												<!-- begin panel-heading -->
												<div class="panel-heading">
													<div class="panel-heading-btn">
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-redo"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
													</div>
													<h4 class="panel-title">Registros</h4>
												</div>
												<!-- end panel-heading -->
												
												<div class="table-responsive">
												<!-- begin panel-body -->
												<div class="panel-body">
										<%--<div class="table-responsive">--%>
												<table id="data-table-default" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-nowrap">COD IMPORTACION</th>
															<th class="text-nowrap">ARCHIVO</th>
															<th class="text-nowrap">TIPO ARCHIVO</th>
															<th class="text-nowrap">FECHA</th>
															<th class="text-nowrap">SORTEO</th>
															<th class="text-nowrap">NRO. REGISTROS</th>
															<th class="text-nowrap">ESTADO</th>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsImportacion" runat="server">
														<ItemTemplate>
															<tr class="gradeA">																
															<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("COD_IMPORTACION_DATOS") %>'></asp:Label></td>
																<td><asp:Label ID="lblPias" runat="server" Text='<%# Eval("RUTA") %>'></asp:Label></td>
																<td><asp:Label ID="lblCiudad" runat="server" Text='<%# Eval("DESC_TIPO_ARCHIVO") %>'></asp:Label></td>
																<td><asp:Label ID="lblNombreSucursal" runat="server" Text='<%# Eval("FECHA_IMPORTACION") %>'></asp:Label></td>
															<td><asp:Label ID="lblLatitud" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label></td>
															<td><asp:Label ID="lblLongitud" runat="server" Text='<%# Eval("CANTIDAD_REGISTROS") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>
															<td>
																<asp:Button ID="btnGenerar" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("COD_IMPORTACION_DATOS") %>' OnClick="btnGenerar_Click1" runat="server" Text="Generar cupones" ToolTip="Genera los cupones" />
																<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("COD_IMPORTACION_DATOS") + "|" + Eval("DESC_ESTADO") %>' OnClick="btnEliminar_Click"  runat="server" Text="Activar/Desactivar" OnClientClick="return confirm('Seguro que desea eliminar el registro???')" ToolTip="Borrar registro" />
																<%--<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("SUC_ID_SUCURSAL") +"|" + Eval("DESC_ESTADO")  %>' OnClick="btnEliminar_Click" runat="server" OnClientClick="return confirm('Seguro que desea eliminar el registro???')" Text="Activar/Desactivar" ToolTip='<%# Eval("CLI_ESTADO") %>' />--%>
                                                                
																<%--<asp:Button ID="btnActivar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("CLI_ID_CLIENTE") %>' OnClick="btnActivar_Click" runat="server" Text="Nuevo" ToolTip="Nueva simulacion" />--%>
															</td>
															
															
														</tr>
														</ItemTemplate>
														</asp:Repeater>
														
													
													</tbody>
												</table>
											</div>
											<!-- end table-responsive -->
													</div>
										</div>
        </asp:View>
		 <asp:View ID="View2" runat="server">
						<!-- begin row -->
			<div class="row">
				<!-- begin col-8 -->
				<div class="col-md-6 offset-md-2">
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos Sucursal</legend>
                    <!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Codigo Sucursal:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtCodigo" class="form-control" style="text-transform:uppercase" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtCodigo" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Nombre Sucursal:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtNombreSucursal" class="form-control" style="text-transform:uppercase" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtNombreSucursal" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Dirección:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtDireccion" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="txtDireccion" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
                   
                  
					
				    
                    <!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Latitud:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtLatitud" class="form-control" runat="server"></asp:TextBox>
							<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="txtLatitud" Font-Bold="True"></asp:RequiredFieldValidator>--%>
						</div>
					</div>
					<!-- end form-group row -->
                    <!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Longitud:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtLongitud" class="form-control" runat="server"></asp:TextBox>
							<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ControlToValidate="txtLongitud" Font-Bold="True"></asp:RequiredFieldValidator>--%>
						</div>
					</div>
					<!-- end form-group row -->
					 
				
					<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardar" CssClass="btn btn-success" runat="server"  Text="Guardar" />
							<asp:Button ID="btnVolver" CssClass="btn btn-success"  runat="server" CausesValidation="false" Text="Cancelar" />
						</div>
					</div>
				</div>				
				<!-- end col-8 -->
        </asp:View>
    </asp:MultiView>
	
	
		</div>
			<%--</ContentTemplate>
    </asp:UpdatePanel>--%>
		<!-- end #content -->
	
</asp:Content>
