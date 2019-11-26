<?php


// Connecting to Google Cloud Database Instance. -DC
$dbname = '[Redacted for Public Submission]';
$dbuser = '[Redacted for Public Submission]';
$dbpass = '[Redacted for Public Submission]';
$dbhost = '[Redacted for Public Submission]';

$connect = mysqli_connect($dbhost, $dbuser, $dbpass) or die("Unable to Connect to '$dbhost'");

mysqli_select_db($connect, $dbname) or die("Could not open the db '$dbname'");

$unit_query = "SELECT * FROM UNITS";

$unit_results = mysqli_query($connect, $unit_query);


echo <<<EOF1
<!DOCTYPE html>
<html lang="en">

<head>
    <title>Dogeons And Dragons</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="icon" type="image/png" href="/images/sven_wip.png">
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

    <!--  Stretching a reflexive banner across head of pages - DC -->
    <div class="container-fluid no-padding" style="background-color:black;">
        <div class="row" style="background-color:black;">

            <!--  img-fluid = reflexive; w-100 = 75% Screen -DC -->
            <image src="images/website_banner_new.png" class="img-fluid w-75 mx-auto"></image>
        </div>
    </div>

    <!-- Start of Navigation -DC -->
    <nav class="navbar navbar-expand-sm navbar-dark" style="background:black;">
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="collapsibleNavbar">
            <ul class="navbar-nav mx-auto font-weight-bold">
                <li class="nav-item">
                    <a class="nav-link" href="index.html">Player Menu&nbsp;&nbsp;&nbsp;</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="adminHome.html">Admin Menu&nbsp;&nbsp;&nbsp;</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="viewTutorials.php">View Tutorials&nbsp;&nbsp;&nbsp;</a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="viewUnits.php">View Units&nbsp;&nbsp;&nbsp;</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="viewEquipment.php">View Equipment&nbsp;&nbsp;&nbsp;</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="viewChewables.php">View Chewables&nbsp;&nbsp;&nbsp;</a>
                </li>
            </ul>
        </div>
    </nav>
    <!-- End of Navigation -DC -->

    <div style="background:black;">

        <br>
        <br>
        <br>

        <!-- Start of The Manage Units Body -DC -->
        <h1 class="text-center text-warning">View Units Page</h1>
        <br>
        <div class="row">
            <a href="addUnit.php" class="btn btn-dark mx-auto" role="button">Add Unit</a>
        </div>
        
        <br>
        <br>
        <br>

EOF1;

// Populating HTML blocks with data from the database. -DC
if ($unit_results->num_rows > 0) {
        // output data of each row. -DC
        echo "<div class=container container-fluid>";
            echo "<div class=row>";
    
        // setting count variable to 0. It is used to increment breaks between rows. -DC
        $count = 0;
    
        // Grabbing values from the array using DB Field IDs. -DC
        while($rowc = $unit_results->fetch_assoc()) 
        {
           
            $unit_name = "{$rowc["NAME"]}";
            $unit_att = "{$rowc["ATTACK"]}";
            $unit_def = "{$rowc["DEFENSE"]}";
            $unit_spd = "{$rowc["SPEED"]}";
            $unit_sty = "{$rowc["UNIT_STORY"]}";
            $unit_hp = "{$rowc["HP"]}";
            $unit_img = "{$rowc["UNIT_IMAGE"]}";
            $logo = "./images/";
                       
            //incrementing the count variable by +1. -DC
            ++$count;
            
                echo '<div class="col-lg-4 container-fluid">';
                    echo '<div class="card">';
                    echo '<img class="card-img-top img-fluid w-50 mx-auto mt-4 mb-4" src="'.$logo.$unit_img.'" alt="Logo">';
                    echo "<div class=card-body>";
                    echo '<h1 class="bg-warning border border-dark card-title font-weight-bold" style="text-align:center">'.$unit_name.'</h5>';                        
                    echo "<ul class=list-group list-group-flush>";
                    echo '<li class="list-group-item bg-danger"><h5><b>Attack:</b> '.$unit_att.'&nbsp;&nbsp;&nbsp;<img class="img-fluid w-10 mx-auto" src="images/squirrel_lg.png" alt="attack icon"></h5></li>';
                    echo '<li class="list-group-item bg-primary"><h5><b>Defense:</b> '.$unit_def.'&nbsp;&nbsp;&nbsp;<img class="img-fluid w-10 mx-auto" src="images/squirrel_md.png" alt="attack icon"></h5></li>';
                    echo '<li class="list-group-item bg-info"><h5><b>Speed:</b> '.$unit_spd.'&nbsp;&nbsp;&nbsp;<img class="img-fluid w-10 mx-auto" src="images/squirrel_sm.png" alt="attack icon"></h5></li>';
                    echo '<li class="list-group-item bg-success"><h5><b>Hitpoints:</b> '.$unit_hp.'&nbsp;&nbsp;&nbsp;<img class="img-fluid w-10 mx-auto" src="images/pug_reaper.png" alt="attack icon"></h5></li>';
                    // echo '<li class="list-group-item bg-secondary"><h5><b>Unit Story:</b> '.$unit_sty.'</h5></li>';
                    echo "</ul>";
                    echo "</div>";
                echo "</div>";
            echo "</div>";
                       
            // My way of spacing. -DC
            $countt = $count / 3;
            
            if (is_int($countt)){
                
                echo '<div class="col-lg-12"><div class="card" style="background-color:black;"><hr size=20 style="border:transparent;visibility:hidden";></hr></div></div>';
            
                }           
                
            }
    
            }
            
        echo "</div>";
    echo "</div>";                  
                      
    echo "<br>";
    echo "<br>";
    echo "<br>";

echo <<<EOF2

<footer class="container-fluid text-center">
<div class="row bg-light" style="height:5px">
<div class="col-xsm-12">
<hr size="5px" style="visibility:hidden"></hr>
    </div>
  </div>
<div class="row bg-light">
<div class="col-lg-12">
  <p><h4>Powered By <b>Oakland Express</b> A Senior Capstone Project</h4></p>
  </div>
  </div>
</footer>

</body>
</html>
 
EOF2;
 
?>
