<?php
  require_once("connect_ldb.php");

  if(!isset($_SESSION)){
    session_start();
  }

  if(isset($_SESSION["user"])!=""){
    header("Location: blank.html");
  }
?>
<html lang="en">

<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">
  <title>Main Page</title>
  <link rel="icon" href="resources/favicon.png">
  <!-- Bootstrap core CSS-->
  <link href="../EXTENSIONS/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <!-- Custom fonts for this template-->
  <link href="../EXTENSIONS/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
  <!-- Page level plugin CSS-->
  <link href="../EXTENSIONS/datatables/dataTables.bootstrap4.css" rel="stylesheet">
  <!-- Custom styles for this template-->
  <link href="../CSS/sb-admin.css" rel="stylesheet">
</head>

<body class="fixed-nav sticky-footer bg-white" id="page-top">
  <!-- Navigation-->
  <nav class="navbar navbar-expand-lg navbar-dark bg-primary fixed-top" id="mainNav">
    <a class="navbar-brand" href="index.php">Deep Sea World Admin Panel</a>
    <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarResponsive">
      <ul class="navbar-nav navbar-sidenav" id="exampleAccordion">
        <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Dashboard">
          <a class="nav-link" href="index.php">
            <span class="nav-link-text">Dashboard</span>
          </a>
        </li>
        <li class="nav-item" data-toggle="tooltip" data-placement="right" title="QR Codes">
          <a class="nav-link" href="qr_index.php">
            <span class="nav-link-text">QR Codes</span>
          </a>
        </li>
        <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Events">
          <a class="nav-link" href="events.php">
            <span class="nav-link-text">Events</span>
          </a>
        </li>
        <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Notifications">
          <a class="nav-link" href="notifications.php">
            <span class="nav-link-text">Notifications</span>
          </a>
        </li>
        <li class="nav-item" data-toggle="tooltip" data-placement="right" title="FAQ">
          <a class="nav-link" href="faq.php">
            <span class="nav-link-text">FAQ</span>
          </a>
        </li>
        <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Map Screen">
          <a class="nav-link" href="map.php">
            <span class="nav-link-text">Map Screen</span>
          </a>
        </li>
      </ul>
      <ul class="navbar-nav ml-auto">  <!-- NAV BAR -->
        <li class="nav-item">
          <a class="nav-link" data-toggle="modal" data-target="#exampleModal">
            <i class="fa fa-fw fa-sign-out"></i>Logout</a>
        </li>
      </ul>
    </div>
  </nav>
  <div class="content-wrapper">
    <div class="container-fluid">
      <!-- Breadcrumbs-->
      <ol class="breadcrumb">
        <li class="breadcrumb-item">
          <a href="index.php">Dashboard</a>
        </li>
      </ol>
	  <div class="col-md-8 blog-main">
		<div >
			<h3 class="lead">Featured article</h3>
		</div>
		<?php $q = "SELECT * FROM article" ;
			$r = mysqli_query( $con, $q ) ;
			if ( mysqli_num_rows( $r ) > 0 ) {
				# Chose an article at random.
				$artCount =0;
				while ($row = mysqli_fetch_array($r, MYSQLI_ASSOC)) {
					$artCount++;
				}
				$randArt = rand(3, $artCount);
				$q = "SELECT * FROM article WHERE artId = $randArt" ;
				$r = mysqli_query( $con, $q ) ;
				$row = mysqli_fetch_array($r, MYSQLI_ASSOC);
					echo
					'<a href="article.php?id=' . $row['artId'] . '"><div class="jumbotron p-3 p-md-5 text-light rounded bg-success">
						<div class="col-md-6 px-0">
							<h1 class="display-4 font-italic">' . $row['artTitle'] . '</h1>
							<p class="lead mb-0 text-white font-weight-bold">by ' . $row['artAuthor'] . '</p>
						</div>
						<hr class="pt-2 bg-light">
					</div></a>';

			}
		?>
	  </div>
    </div>
  </div>
      <!-- Example DataTables Card-->
    <!-- /.container-fluid-->
    <!-- /.content-wrapper-->
    <footer class="sticky-footer">
      <div class="container">
        <div class="text-center">
          <small>Copyright ©haxadecimal 2018</small>
        </div>
      </div>
    </footer>
    <!-- Scroll to Top Button-->
    <a class="scroll-to-top rounded" href="#page-top">
      <i class="fa fa-angle-up"></i>
    </a>
    <!-- Logout Modal-->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Ready to Leave?</h5>
            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">×</span>
            </button>
          </div>
          <div class="modal-body">Select "Logout" below if you are ready to end your current session.</div>
          <div class="modal-footer">
            <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
            <a class="btn btn-primary" href="login.php">Logout</a>
          </div>
        </div>
      </div>
    </div>
    <!-- Bootstrap core JavaScript-->
    <script src="../EXTENSIONS/jquery/jquery.min.js"></script>
    <script src="../EXTENSIONS/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- Core plugin JavaScript-->
    <script src="../EXTENSIONS/jquery-easing/jquery.easing.min.js"></script>
    <!-- Page level plugin JavaScript-->
    <script src="../EXTENSIONS/chart.js/Chart.min.js"></script>
    <script src="../EXTENSIONS/datatables/jquery.dataTables.js"></script>
    <script src="../EXTENSIONS/datatables/dataTables.bootstrap4.js"></script>
    <!-- Custom scripts for all pages-->
    <script src="JSCRIPT/sb-admin.min.js"></script>
    <!-- Custom scripts for this page-->
    <script src="JSCRIPT/sb-admin-datatables.min.js"></script>
    <script src="JSCRIPT/sb-admin-charts.min.js"></script>
  </div>
</body>

</html>
