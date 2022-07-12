<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="consulta_clientes.aspx.cs" Inherits="tombolaMercantil.consulta_clientes" %>
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
    
	<asp:ObjectDataSource ID="odsTipoArchivo" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="tombolaMercantil.Clases.Clientes">
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
											<h1 class="page-header">Administrar clientes <small></small></h1>
										<!-- begin form-group row -->
										<%--<div class="form-group row m-b-10">											
											<div class="col-md-6">
                                                <asp:Button ID="btnExportarCliente" class="btn btn-success" ValidationGroup="archivo" OnClick="btnExportarCliente_Click" runat="server" Text="Importar Clientes" />
											</div>
										</div>--%>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Nombre cliente:</label>
											<div class="col-md-6">
												<asp:TextBox ID="txtNombreCliente" CssClass="form-control" ValidationGroup="filtros" runat="server"></asp:TextBox>
												<%--<asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtNombreCliente" ValidationGroup="filtros" ID="RegularExpressionValidator2" ValidationExpression = "^[\s\S]{8,}$" runat="server" ErrorMessage="Minimum 8 characters required."></asp:RegularExpressionValidator>--%>
											</div>
										</div>
										<!-- end form-group row -->
										 <!-- begin form-group row -->
											<div class="form-group row m-b-10">
												<label class="col-md-3 text-md-right col-form-label">Codigo cliente:</label>
												<div class="col-md-6">
													<asp:TextBox ID="txtCodCliente" CssClass="form-control" runat="server"></asp:TextBox>
												</div>  
											</div>
											<!-- end form-group row --> 
								<!-- begin form-group row -->
											<div class="form-group row m-b-10">
												<label class="col-md-3 text-md-right col-form-label">Nro. de registros por pagina:</label>
												<div class="col-md-2">
													<asp:TextBox ID="txtNroReg" TextMode="Number" Text="1000" CssClass="form-control" runat="server"></asp:TextBox>
												</div>  
											</div>
											<!-- end form-group row --> 

			<!-- begin form-group row -->
											<div class="form-group row m-b-10">
												<label class="col-md-3 text-md-right col-form-label">Nro. de pagina:</label>
												<div class="col-md-2">
													<asp:TextBox ID="txtNroPagina" CssClass="form-control" TextMode="Number" Text="1" runat="server"></asp:TextBox>
												</div>  
											</div>
											<!-- end form-group row --> 
											  <!-- begin form-group row -->
											<div class="form-group row m-b-10">
												<label class="col-md-3 text-md-right col-form-label"></label>
												<div class="col-md-6">
														 <asp:Button ID="btnBuscar" class="btn btn-success" ValidationGroup="filtros" OnClick="btnBuscar_Click" runat="server" Text="Buscar" />
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
												<table id="data-table-buttons" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-nowrap">COD CLIENTE</th>
															<th class="text-nowrap">FECHA</th>
															<th class="text-nowrap">ARCHIVO</th>
															<th class="text-nowrap">CUENTA</th>
															<th class="text-nowrap">CANT.CUPONES</th>
															<th class="text-nowrap">NRO. SORTEO</th>
															<th class="text-nowrap">DESCRIPCION</th>
															<th class="text-nowrap">NRO.CUPON</th>
															<th class="text-nowrap">SORTEO</th>
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" runat="server">
														<ItemTemplate>
															<tr class="gradeA">																
															<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("CODIGO_CLIENTE") %>'></asp:Label></td>
																<td><asp:Label ID="lblPias" runat="server" Text='<%# Eval("FECHA") %>'></asp:Label></td>
																<td><asp:Label ID="lblCiudad" runat="server" Text='<%# Eval("ARCHIVO") %>'></asp:Label></td>
																<td><asp:Label ID="lblNombreSucursal" runat="server" Text='<%# Eval("CUENTA") %>'></asp:Label></td>
															<td><asp:Label ID="lblLatitud" runat="server" Text='<%# Eval("CANT_CUPONES") %>'></asp:Label></td>
															<td><asp:Label ID="lblLongitud" runat="server" Text='<%# Eval("NRO_SORTEO") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label></td>
																<td><asp:Label ID="Label3" runat="server" Text='<%# Eval("NRO_CUPON") %>'></asp:Label></td>
																<td><asp:Label ID="Label4" runat="server" Text='<%# Eval("SORTEO") %>'></asp:Label></td>
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
						
        </asp:View>
    </asp:MultiView>
	
	
		</div>
			<%--</ContentTemplate>
    </asp:UpdatePanel>--%>
		<!-- end #content -->
	
</asp:Content>
