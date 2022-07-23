<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="tombolaMercantil.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ObjectDataSource ID="odsGanadoresSucursales" runat="server" SelectMethod="PR_GET_DASHBOARD" TypeName="tombolaMercantil.Clases.Dashboard">
        <SelectParameters>
            <asp:Parameter DefaultValue="CGS" Name="PV_TIPO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsGanadoresBanca" runat="server" SelectMethod="PR_GET_DASHBOARD" TypeName="tombolaMercantil.Clases.Dashboard">
        <SelectParameters>
            <asp:Parameter DefaultValue="CGB" Name="PV_TIPO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
	<!-- begin #content -->
		<div id="content" class="content">
     <!-- begin page-header -->
			<h1 class="page-header">Dashboard Sorteos<small></small></h1>
			<!-- end page-header -->
			  
			<!-- begin row -->
			<h5 class="page-header">Ganadores por sucursal</h5><br />
			<div class="row">
				<asp:Repeater ID="Repeater1" DataSourceID="odsGanadoresSucursales" runat="server">
					<ItemTemplate>
						<!-- begin col-3 -->
						<div class="col-md-2">
							<div class="widget widget-stats bg-gradient-teal">
								<div class="stats-icon stats-icon-lg"><i class="fa fa-money-bill fa-fw"></i></div>
								<div class="stats-content">
									<div class="stats-title">TOTAL <%# Eval("SUCURSAL") %></div>
									<div class="stats-number"><%# Eval("CANTIDAD_SUCURSAL") %></div></div>
								</div>
							</div>
						
						<!-- end col-3 -->
					</ItemTemplate>
				</asp:Repeater>
			</div>
			<!-- end row -->
			<!-- begin row -->
			<h5 class="page-header">Ganadores por Banca</h5><br />
			<div class="row">
				<asp:Repeater ID="Repeater2" DataSourceID="odsGanadoresBanca" runat="server">
					<ItemTemplate>
						<!-- begin col-3 -->
						<div class="col-md-2">
							<div class="widget widget-stats bg-gradient-blue">
								<div class="stats-icon stats-icon-lg"><i class="fa fa-money-bill fa-fw"></i></div>
								<div class="stats-content">
									<div class="stats-title">BANCA <%# Eval("BANCA") %></div>
									<div class="stats-number"><%# Eval("CANTIDAD_BANCA") %></div></div>
								</div>
							</div>
						
						<!-- end col-3 -->
					</ItemTemplate>
				</asp:Repeater>
			</div>
			<!-- end row -->
			<!-- begin row -->
			<h5 class="page-header">Ganadores por Banca</h5><br />
			<div class="row">
				<asp:Repeater ID="Repeater3" DataSourceID="odsGanadoresBanca" runat="server">
					<ItemTemplate>
						<!-- begin col-3 -->
						<div class="col-md-2">
							<div class="widget widget-stats bg-gradient-blue">
								<div class="stats-icon stats-icon-lg"><i class="fa fa-money-bill fa-fw"></i></div>
								<div class="stats-content">
									<div class="stats-title">BANCA <%# Eval("BANCA") %></div>
									<div class="stats-number"><%# Eval("CANTIDAD_BANCA") %></div></div>
								</div>
							</div>
						
						<!-- end col-3 -->
					</ItemTemplate>
				</asp:Repeater>
			</div>
			<!-- end row -->
			<!-- begin row -->
			<div class="row">
				<!-- begin col-8 -->
				<div class="col-lg-8">
					<div class="widget-chart with-sidebar inverse-mode">
						<div class="widget-chart-content bg-black">
							<h4 class="chart-title">
								Sorteos a nivel nacional
								<small>Tenemos mas ganadores en</small>
							</h4>
							<div id="visitors-line-chart" class="widget-chart-full-width nvd3-inverse-mode" style="height: 260px;"></div>
						</div>
						<div class="widget-chart-sidebar bg-black-darker">
							<div class="chart-number">
								7.000
								<small>Total sorteos</small>
							</div>
							<div id="visitors-donut-chart" class="nvd3-inverse-mode p-t-10" style="height: 180px"></div>
							<ul class="chart-legend f-s-11">
								<li><i class="fa fa-circle fa-fw text-primary f-s-9 m-r-5 t-minus-1"></i> 34.0% <span>La Paz</span></li>
								<li><i class="fa fa-circle fa-fw text-success f-s-9 m-r-5 t-minus-1"></i> 56.0% <span>Santa Cruz</span></li>
							</ul>
						</div>
					</div>
				</div>
				<!-- end col-8 -->
			</div>
			<!-- end row -->
			</div>
</asp:Content>
