<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="sorteos_premios.aspx.cs" Inherits="tombolaMercantil.sorteos_premios" %>
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
		};
        function recuperarFechas() {

            document.getElementById('<%=hfFechaSorteo.ClientID%>').value = document.getElementById('#fecha_soteo').value;
             document.getElementById('<%=hfFechaDesde.ClientID%>').value = document.getElementById('#fecha_desde').value;
            document.getElementById('<%=hfFechaHasta.ClientID%>').value = document.getElementById('#fecha_hasta').value;
        };
    </script>
    

	<asp:ObjectDataSource ID="odsTipoSorteo" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="tombolaMercantil.Clases.Dominios">
        <SelectParameters>
            <asp:Parameter DefaultValue="TIPO SORTEO" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsSorteos" runat="server" SelectMethod="PR_SOR_GET_SORTEOS" TypeName="tombolaMercantil.Clases.Sorteos">
	</asp:ObjectDataSource>    
	<!-- begin #content -->
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<Triggers>
			<asp:PostBackTrigger ControlID="Repeater1" />
		</Triggers>
		<ContentTemplate>--%>

		
		<div id="content" class="content">
			<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
			<asp:Label ID="lblCodSorteo" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblCodSorteoDetalle" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
             <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			
									
										<!-- begin page-header -->
											<h1 class="page-header">Sorteos <small></small></h1>
          <!-- begin form-group row -->
										<div class="form-group row m-b-10">											
											<div class="col-md-6">
                                                <asp:Button ID="btnNuevoSorteo" class="btn btn-success" OnClick="btnNuevoSorteo_Click" runat="server" Text="Nuevo Sorteo" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
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
															<th class="text-nowrap">CODIGO</th>
															<th class="text-nowrap">DESCRIPCION</th>
															<th class="text-nowrap">F.SORTEO</th>
															<th class="text-nowrap">F.DESDE</th>
															<th class="text-nowrap">F.HASTA</th>
															<th class="text-nowrap">TIPO</th>
															<th class="text-nowrap">ESTADO</th>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsSorteos"  runat="server">
														<ItemTemplate>
															<tr class="gradeA">																
															<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("COD_SORTEO") %>'></asp:Label></td>
																<td><asp:Label ID="lblPias" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label></td>
															<td><asp:Label ID="lblCiudad" runat="server" Text='<%# Eval("FECHA_SORTEO") %>'></asp:Label></td>
															<td><asp:Label ID="lblNombreSucursal" runat="server" Text='<%# Eval("FECHA_DESDE") %>'></asp:Label></td>
															<td><asp:Label ID="lblLatitud" runat="server" Text='<%# Eval("FECHA_HASTA") %>'></asp:Label></td>
															<td><asp:Label ID="lblLongitud" runat="server" Text='<%# Eval("DESC_TIPO_SORTEO") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>
															<td>
																<asp:Button ID="btnEditar" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("COD_SORTEO") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar" />
																<asp:Button ID="btnDetalle" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("COD_SORTEO") %>' OnClick="btnDetalle_Click" runat="server" Text="Editar" ToolTip="Detalles" />
																<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("COD_SORTEO") + "|" + Eval("DESC_ESTADO") %>' OnClick="btnEliminar_Click"  runat="server" Text="Activar/Desactivar" ToolTip="Dar de baja registro" />
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
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Sorteos y Premios</legend>
                    <!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Descripcion:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtDescripcion" class="form-control" style="text-transform:uppercase" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtDescripcion" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Fecha Sorteo:</label><asp:Label ID="lblFechaSorteo" runat="server" Text=""></asp:Label>
						<div class="col-md-6">
                            <input id="fecha_sorteo" class="form-control" onfocus="bloquear()" type="date" ><asp:HiddenField ID="hfFechaSorteo" runat="server" />
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Fecha desde:</label><asp:Label ID="lblFechaDesde" runat="server" Text=""></asp:Label>
						<div class="col-md-6">
                            <input id="fecha_desde" class="form-control" onfocus="bloquear()" type="date" ><asp:HiddenField ID="hfFechaDesde" runat="server" />
						</div>
					</div>
					<!-- end form-group row -->
                    <!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Fecha hasta:</label><asp:Label ID="lblFechaHasta" runat="server" Text=""></asp:Label>
						<div class="col-md-6">
						        <input id="fecha_hasta" class="form-control" onfocus="bloquear()" type="date" ><asp:HiddenField ID="hfFechaHasta" runat="server" />
                        </div>  
					</div>
					<!-- end form-group row -->  
                    <!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Tipo sorteo:</label>
						<div class="col-md-6">
						         <asp:DropDownList ID="ddlTipoSorteo" class="form-control" DataSourceID="odsTipoSorteo" OnDataBound="ddlTipoSorteo_DataBound" DataTextField="descripcion" DataValueField="codigo"  ForeColor="Black" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMesssage="*" ForeColor="Red" ControlToValidate="ddlTipoSorteo" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
                        </div>
					</div>
					<!-- end form-group row -->
					
				    
                    <!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Logo:</label>
						<div class="col-md-6">
							<asp:FileUpload ID="fuLogo" CssClass="form-control" runat="server" />
							<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="txtLatitud" Font-Bold="True"></asp:RequiredFieldValidator>--%>
						</div>
					</div>
					<!-- end form-group row -->
                    
	
				
					<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardar" CssClass="btn btn-success" OnClientClick="recuperarFechas()" CausesValidation="true" runat="server"  OnClick="btnGuardar_Click" Text="Guardar" />
							<asp:Button ID="btnVolver" CssClass="btn btn-success"  runat="server" CausesValidation="false" OnClick="btnVolver_Click" Text="Cancelar" />
						</div>
					</div>
				</div>				
			
				<!-- end col-8 -->
        </asp:View>
    </asp:MultiView>
</div>
	 <script>
         function formatISOLocal(d) {
             let z = n => ('0' + n).slice(-2);
             return d.getFullYear() + '-' + z(d.getMonth() + 1) + '-' + z(d.getDate());
         };

         function bloquear() {
             let inp = document.querySelector('#fecha_sorteo');
             let d = new Date();
             inp.min = formatISOLocal(d);
             inp.defaultValue = inp.min;
             d.setFullYear(d.getFullYear() + 1);
             inp.max = formatISOLocal(d);
             // Debug
             console.log(inp.outerHTML);
             let inp1 = document.querySelector('#fecha_desde');
             let d1 = new Date();
             inp1.min = formatISOLocal(d1);
             inp1.defaultValue = inp1.min;
             d1.setFullYear(d1.getFullYear() + 1);
             inp1.max = formatISOLocal(d1);
             // Debug
			 console.log(inp1.outerHTML);
             let inp2 = document.querySelector('#fecha_hasta');
             let d2 = new Date();
             inp2.min = formatISOLocal(d2);
             inp2.defaultValue = inp2.min;
             d2.setFullYear(d2.getFullYear() + 1);
             inp2.max = formatISOLocal(d2);
             // Debug
             console.log(inp2.outerHTML);
		 };

         
     </script>

	 

</asp:Content>
