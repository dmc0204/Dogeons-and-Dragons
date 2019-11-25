<?php

$dbname = '';
$dbuser = '';
$dbpass = '';
$dbhost = '';

$connect = mysqli_connect($dbhost, $dbuser, $dbpass) or die("Unable to Connect to '$dbhost'");

mysqli_select_db($connect, $dbname) or die("Could not open the db '$dbname'");

$c_query = "SELECT * FROM UNITS";

$c_results = mysqli_query($connect, $c_query);



echo <<<EOF1
<!DOCTYPE html>
<html lang="en">

<head>
    <title>Dogeons And Dragons</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="icon" type="image/png" href="images/sven_wip.png">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</head>

<!-- 

Original template code from W3Schools;
Modifications by Donovan Cummins - DC

-->

<body>

<!-- Start of Navigation -DC -->
    <nav class="navbar navbar-expand-sm navbar-dark" style="background:black;">
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="collapsibleNavbar">
            <a class="navbar-brand" href="a_index.html">
                <image src="images/navlogo_text.png" class="img-fluid"></image>
            </a>
            <ul class="navbar-nav">
                <li class="nav-item p-2 active">
                    <a class="nav-link" href="a_units.php">
                        <h3 class="font-weight-bold">Edit Dogs</h3>
                    </a>
                </li>
                <li class="nav-item p-2">
                    <a class="nav-link" href="index.html">
                        <h3 class="font-weight-bold">Logout</h3>
                    </a>
                </li>
            </ul>
        </div>
    </nav>
    <!-- End of Navigation -DC -->

    <!--  Stretching a reflexive banner across head of pages - DC -->
    <div class="container-fluid no-padding" style="background-color:black;background-image:url(images/stone_tile.png);">
        <div class="row" style="background-color:black;">

            <!--  img-fluid = reflexive; w-100 = 75% Screen -DC -->

            <image src="images/website_banner_v10.png" class="img-fluid w-100 mx-auto"></image>
        </div>
    </div>

    <div style="background:black;">
    <h1 class="text-center text-warning font-weight-bold bg-dark p-2">Edit Units</h1>

EOF1;

 $str = <<<EOD
 
 <div class="row p-2">
 <div class="col-sm-7"><h4 class="text-white text-right text-info p-2 font-weight-bold">Would you like to add a new unit?</h4></div>
 <div class="col-sm-5">
            <a href="a_addUnits.php" class="btn btn-lg btn-secondary mx-auto" role="button">Add Unit</a>
            </div>
        </div>
 <div class="row text-warning" style="background-image:url(images/stone_tile.png);"> 
    
EOD;
    
echo $str;            
            
  if ($c_results->num_rows > 0) {         
    
        echo "<div class='container p-4'>";       
        echo "<table class='table table-striped table-hover bg-white text-dark'>";
        echo "<thead class='font-weight-bold text-body'><tr><td>Unit ID</td> <td>Unit Name ID</td> ";
        echo "<td> Delete? </td></tr></thead>";   
        while($row = $c_results->fetch_assoc()) 
        {
            echo "<tbody><tr>";
            $UNIT_ID = $row["UNIT_ID"];
            echo  "<td>" . $UNIT_ID . "  </td> <td> " . $row["NAME"] .
                  "</td>  <td> "; 
               
            echo "<form action='deleteUnits.php' method='post' style='display:inline' >";
            echo "<input type='hidden' name='UNIT_ID' value='{$UNIT_ID}'>";
            echo "<input type='submit' name='btnDelete' value='Delete'></form>";
            echo "</td></tr></tbody>";
            
        }
      
                }

    echo <<<EOF2
</body>
</html>
 
EOF2;


 
?>