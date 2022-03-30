﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="tombolaMercantil.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<meta charset="utf-8" />
	<title>Ingreso</title>
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
	
	<!-- ================== BEGIN BASE JS ================== -->
	<script src="assets/plugins/pace/pace.min.js"></script>
	<!-- ================== END BASE JS ================== -->
</head>
<body class="pace-top bg-white">
	<form runat="server" defaultbutton="btnIngresar">
	<!-- begin #page-loader -->
	<div id="page-loader" class="fade show"><span class="spinner"></span></div>
	<!-- end #page-loader -->
	
	<!-- begin #page-container -->
	<div id="page-container" class="fade">
		<!-- begin login -->
		<div class="login login-with-news-feed">
			<!-- begin news-feed -->
			<div class="news-feed">
				<div class="news-image" style="background-image: url(Imagenes/fondo1bmsc.jpg)"></div>
				<div class="news-caption">
					<%--<h4 class="caption-title"><b>Sorteos</b>BMSC</h4>--%>
					<p>
						<%--Seguimos premiando.....--%>
					</p>
				</div>
			</div>
			<!-- end news-feed -->
			<!-- begin right-content -->
			<div class="right-content">
				<!-- begin login-header -->
				<div class="login-header">
					<img src="Imagenes/logo_bmsc.png" width="400" />
						<h1><span class="logo"></span> <b>Sorteos</b> BMSC</h1>
					
				</div>
				<!-- end login-header -->
				<!-- begin login-content -->
				<div class="login-content">
						<div class="form-group m-b-15">
                            <asp:TextBox ID="txtUsuario" class="form-control form-control-lg" placeholder="Nombre usuario" required runat="server"></asp:TextBox>
							<%--<input type="text" class="form-control form-control-lg" placeholder="Email Address" required />--%>
						</div>
						<div class="form-group m-b-15">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control form-control-lg" placeholder="Password" ></asp:TextBox>
							<%--<input type="password" class="form-control form-control-lg" placeholder="Password" required />--%>
						</div>
						
						<div class="login-buttons">
                            <asp:Button ID="btnIngresar" OnClick="btnIngresar_Click" class="btn btn-success btn-block btn-lg" runat="server" Text="Ingresar" />
							<%--<button type="submit" class="btn btn-success btn-block btn-lg">Sign me in</button>--%>
						</div>
						<div class="form-group m-b-15">
                            <asp:Label ID="lblAviso" runat="server" ForeColor="Red" Text=""></asp:Label>
						</div><br />
					<div class="login-buttons">
                            <asp:Button ID="btnReset" OnClick="btnReset_Click" class="btn btn-default btn-block btn-lg" runat="server" Text="Resetear password" />
							<%--<button type="submit" class="btn btn-success btn-block btn-lg">Sign me in</button>--%>
						</div>
						<%--<div class="m-t-20 m-b-40 p-b-40 text-inverse">
							Not a member yet? Click <a href="register_v3.html" class="text-success">here</a> to register.
						</div>--%>
						<hr />
						<p class="text-center text-grey-darker">
							&copy; BMSC All Right Reserved 2020
						</p>
					
				</div>
				<!-- end login-content -->
			</div>
			<!-- end right-container -->
		</div>
		<!-- end login -->

		
	</div>
	<!-- end page container -->
	
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

	<script>
		$(document).ready(function() {
			App.init();
		});
    </script>
		</form>
</body>
</html>