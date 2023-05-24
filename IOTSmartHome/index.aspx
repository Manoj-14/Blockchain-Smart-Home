<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="IOTSmartHome.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
	<head>
		<title>Smart HOME system</title>
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<meta name="keywords" content="Play-Offs Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template, Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
		<script type="application/x-javascript"> addEventListener("load", function() {setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
		<!meta charset utf="8">
		<!--fonts-->
			<link href='http://fonts.googleapis.com/css?family=Monda:400,700' rel='stylesheet' type='text/css'>
			<link href='http://fonts.googleapis.com/css?family=Roboto+Slab:400,300,100,700' rel='stylesheet' type='text/css'>
		<!--fonts-->
		<!--owlcss-->
		<link href="css/owl.carousel.css" rel="stylesheet">
		<!--bootstrap-->
			<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css">
		<!--coustom css-->
			<link href="css/style.css" rel="stylesheet" type="text/css"/>
		<!--default-js-->
			<script src="js/jquery-2.1.4.min.js"></script>
		<!--bootstrap-js-->
			<script src="js/bootstrap.min.js"></script>
		<!--script-->
			<script type="text/javascript" src="js/move-top.js"></script>
			<script type="text/javascript" src="js/easing.js"></script>
		<!--script-->
	</head>
	<body>
		<div class="header" id="home">
			<%--<div class="header-top">
				<div class="container">
					<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>
				</div>
			</div>--%>
			<div class="header_nav" id="home">
				<nav class="navbar navbar-default chn-gd">
					<div class="container">
					<!-- Brand and toggle get grouped for better mobile display -->
					<div class="navbar-header">
					<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
					<span class="sr-only">Toggle navigation</span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					</button>
					<a class="navbar-brand logo-st" href="#">Smart HOME system</a>
					</div>
					<!-- Collect the nav links, forms, and other content for toggling -->
					<div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
					<ul class="nav navbar-nav navbar-right">
						<li>
						<a href="#home" class="scroll">
						<span class="glyphicon glyphicon-home icn_pos hm" aria-hidden="true"></span><br>
						Home
						</a>
						</li>
						<li>
						<a href="UserRegistration.aspx">
						<span class="glyphicon glyphicon-user icn_pos hm" aria-hidden="true"></span><br>
						User Registration
						</a>
						</li>
						
						<li>	
						<a href="Login.aspx">
						<span class="glyphicon glyphicon-log-in icn_pos hm12" aria-hidden="true"></span><br>
						Login
						</a>
						</li>
                        <!---->
                        
						<!--script-->
						<script type="text/javascript">
						    jQuery(document).ready(function ($) {
						        $(".scroll").click(function (event) {
						            event.preventDefault();
						            $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 900);
						        });
						    });
						</script>
						<!--script-->
					</ul>
					</div><!-- /.navbar-collapse -->
					<div class="clearfix"></div>
					</div><!-- /.container-fluid -->
				</nav>
			</div>
			<div class="header_banner">
				<div id="myCarousel" class="carousel slide" data-ride="carousel">
				<!-- Indicators -->
					<ol class="carousel-indicators">
					<li data-target="#myCarousel" data-slide-to="0" class="active"></li>
					<li data-target="#myCarousel" data-slide-to="1"></li>
					<li data-target="#myCarousel" data-slide-to="2"></li>
					<li data-target="#myCarousel" data-slide-to="3"></li>
					</ol>

				<!-- Wrapper for slides -->
				<div class="carousel-inner" role="listbox">
					<div class="item active  image-wid">
					<img src="./images/10a.jpg" alt="..." class="img-responsive">
					<div class="carousel-caption">
						<%--<h3>Medical Check Up Instruments</h3>
						<p>Lorem Ipsum is simply dummy text of the typesetting industry</p>
						<button type="button" class="btn btn-info sld">Read more</button>--%>
					</div>
					</div>
					<div class="item  image-wid">
					<img src="./images/10d.png" alt="..." class="img-responsive">
					<div class="carousel-caption">
						<%--<h3>Drugs  For Required Dose</h3>
						<p>Lorem Ipsum is simply dummy text of the typesetting industry</p>
						<button type="button" class="btn btn-info sld">Read more</button>--%>
					</div>
					</div>
					<div class="item  image-wid">
					<img src="./images/10g.jpg" alt="..." class="img-responsive">
					<div class="carousel-caption">
						<%--<h3>Doctors Supervision</h3>
						<p>Lorem Ipsum is simply dummy text of the typesetting industry</p>
						<button type="button" class="btn btn-info sld">Read more</button>--%>
					</div>
					</div>
					<div class="item  image-wid">
					<img src="./images/10l.png" alt="..." class="img-responsive">
					<div class="carousel-caption">
						<%--<h3>Viral Treatments</h3>
						<p>Lorem Ipsum is simply dummy text of the typesetting industry</p>
						<button type="button" class="btn btn-info sld">Read more</button>--%>
					</div>
					</div>
				</div>
				<!-- Controls -->
				<a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
				<span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
				<span class="sr-only">Previous</span>
				</a>
				<a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
				<span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
				<span class="sr-only">Next</span>
				</a>
				</div>
			</div>
		</div>
		
		
         <div>
        
      </div>
		<div class="footer">
			<div class="container">
				<div class="footer-text">
				<h3><a href="index.aspx">Smart HOME system</a></h3>
				<p>&#169;Smart IOT System </p>
				</div>
			</div>
		</div>
		<a href="#home" id="toTop" class="scroll" style="display: block;"> <span id="toTopHover" style="opacity: 1;"> </span></a>
	</body>
</html>
