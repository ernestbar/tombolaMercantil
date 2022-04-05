<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="sorteos.aspx.cs" Inherits="tombolaMercantil.sorteos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content" class="content">
			<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
			<asp:Label ID="lblDominio" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblCodigo" runat="server" Text="3" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
			  <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
		<!-- begin page-header -->
		<h1 class="page-header">Administrador <small>Sorteos:</small></h1>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<!-- begin form-group row -->
			<div class="form-group row m-b-10">
				<label class="col-md-3 text-md-right col-form-label">Seleccionar sorteo:</label>
				<div class="col-md-6">
					<asp:DropDownList ID="ddlSorteo" runat="server">
						<asp:ListItem Text="SELECCIONAR"></asp:ListItem>
						<asp:ListItem Text="DIA DEL PADRE"></asp:ListItem>
						<asp:ListItem Text="DIA DE LA MADRE"></asp:ListItem>
						<asp:ListItem Text="DIA DEL NIÑO"></asp:ListItem>
					</asp:DropDownList>
				</div>
			</div>
		<span class='numscroller' data-min='1' data-max='1000' data-delay='5' data-increment='10'>1000</span>
			<div class="row">
				<div class="col">
					<asp:TextBox ID="txt1" Height="200" Width="150" runat="server"></asp:TextBox>
				</div>
				<div class="col">
					<asp:TextBox ID="txt2" Height="200" Width="150" runat="server"></asp:TextBox>
				</div>
				<div class="col">
					<asp:TextBox ID="txt3" Height="200" Width="150" runat="server"></asp:TextBox>
				</div>
				<div class="col">
					<asp:TextBox ID="txt4" Height="200" Width="150" runat="server"></asp:TextBox>
				</div>
				<div class="col">
					<asp:TextBox ID="txt5" Height="200" Width="150" runat="server"></asp:TextBox>
				</div>
			</div>
			<!-- end form-group row -->
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

		function rolldice()
		{
		var ranNum = Math.floor( 1 + Math.random() * 6 );
			document.getElementById('dice').innerHTML = ranNum;

		}
		function stopDice()
		{
			clearInterval(MyVar);
		}
    </script>
</asp:Content>
