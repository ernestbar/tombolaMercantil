﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="export_cuponeria_sorteo.aspx.cs" Inherits="tombolaMercantil.export_cuponeria_sorteo" %>
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
    <asp:ObjectDataSource ID="odsImportacion" runat="server" SelectMethod="lista" TypeName="tombolaMercantil.Clases.Importacion">
	</asp:ObjectDataSource>    
	<!-- begin #content -->
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<Triggers>
			<asp:PostBackTrigger ControlID="Repeater1" />
		</Triggers>
		<ContentTemplate>--%>

		<asp:ObjectDataSource ID="odsSorteosVigentes" runat="server" SelectMethod="PR_SOR_GET_SORTEOS_VIGENTES" TypeName="tombolaMercantil.Clases.Sorteos">
			</asp:ObjectDataSource>
		<div id="content" class="content">
			<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
			<asp:Label ID="lblCodImportacionDatos" runat="server" Text="0" Visible="false"></asp:Label>
			<asp:Label ID="lblCodImportacionDetalle" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
             <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			
									
										<!-- begin page-header -->
											<h1 class="page-header">Exportar Cuponeria-Sorteo <small></small></h1>
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">											
											<div class="col-md-6">
                                                <asp:Button ID="btnExportarCupones" class="btn btn-success" ValidationGroup="exportar" OnClick="btnExportarCupones_Click" runat="server" Text="Exportar Cuponeria" />
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											<label class="col-md-3 text-md-right col-form-label">Seleccionar sorteo:</label>
											<div class="col-md-6">
												<asp:DropDownList ID="ddlSorteo" OnDataBound="ddlSorteo_DataBound1" CssClass="form-control" ValidationGroup="exportar" DataSourceID="odsSorteosVigentes" DataTextField="DESCRIPCION" DataValueField="COD_SORTEO" runat="server"></asp:DropDownList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ValidationGroup="exportar" ForeColor="Red" ControlToValidate="ddlSorteo" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
											</div>
										</div>
										<!-- end form-group row -->
										 <!-- begin form-group row -->
											<div class="form-group row m-b-10">
												<label class="col-md-3 text-md-right col-form-label">Tipo Archivo:</label>
												<div class="col-md-6">
														<asp:DropDownList ID="ddlTipoArchivo" class="form-control" ValidationGroup="exportar" OnDataBound="ddlTipoArchivo_DataBound" DataSourceID="odsTipoArchivo" DataTextField="descripcion" DataValueField="codigo" ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ValidationGroup="exportar" ForeColor="Red" ControlToValidate="ddlTipoArchivo" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
												</div>  
											</div>
											<!-- end form-group row -->
											<!-- begin form-group row -->
											<div class="form-group row m-b-10">
												<label class="col-md-3 text-md-right col-form-label">Cantidad de registros:</label>
												<div class="col-md-6">
													<asp:TextBox ID="txtNroRegistros" CssClass="form-control" ValidationGroup="archivo" Text="100" runat="server"></asp:TextBox>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ValidationGroup="archivo" ForeColor="Red" ControlToValidate="txtNroRegistros" Font-Bold="True"></asp:RequiredFieldValidator>
												</div>  
											</div>
											<!-- end form-group row -->
											<!-- begin form-group row -->
											<div class="form-group row m-b-10">
												<label class="col-md-3 text-md-right col-form-label">Nro de Pagina:</label>
												<div class="col-md-6">
														<asp:TextBox ID="txtNroPagina" CssClass="form-control" ValidationGroup="archivo" Text="1" runat="server"></asp:TextBox>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ValidationGroup="archivo" ForeColor="Red" ControlToValidate="txtNroPagina" Font-Bold="True"></asp:RequiredFieldValidator>
												</div>  
											</div>
											<!-- end form-group row -->
											  <!-- begin form-group row -->
											<div class="form-group row m-b-10">
												<label class="col-md-3 text-md-right col-form-label"></label>
												<div class="col-md-6">
														 <asp:Button ID="btnBuscar" class="btn btn-success" ValidationGroup="filtros" OnClick="btnBuscar_Click" runat="server" Text="Mostrar cuponeria" />
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
															<th class="text-nowrap">INDENTIFICACION</th>
															<th class="text-nowrap">CLIENTE</th>
															<th class="text-nowrap">CUENTA</th>
															<th class="text-nowrap">CANT.CUPONES</th>
															<th class="text-nowrap">NRO. PREMIO</th>
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
																<td><asp:Label ID="lblPias" runat="server" Text='<%# Eval("IDENTIFICACION") %>'></asp:Label></td>
																<td><asp:Label ID="lblCiudad" runat="server" Text='<%# Eval("CLIENTE") %>'></asp:Label></td>
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
