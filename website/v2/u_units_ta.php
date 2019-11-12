<?php


// Connecting to Google Cloud Database Instance. -DC
$dbname = '';
$dbuser = '';
$dbpass = '';
$dbhost = '';

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
        <a class="navbar-brand" href="index.html"><image src="images/navlogo_text.png" class="img-fluid"></image></a>
            <ul class="navbar-nav">
                <li class="nav-item p-2">
                    <a class="nav-link" href="u_story.php"><h3 class="font-weight-bold">The Story</h3></a>
                </li>
                <li class="nav-item p-2">
                    <a class="nav-link" href="u_tutorials.php"><h3 class="font-weight-bold">Tutorials</h3></a>
                </li>
                <li class="nav-item active p-2">
                    <a class="nav-link" href="u_units.php"><h3 class="font-weight-bold">Units</h3></a>
                </li>
                <li class="nav-item p-2">
                    <a class="nav-link" href="u_chewables.php"><h3 class="font-weight-bold">Chewables</h3></a>
                </li>
                <li class="nav-item p-2">
                    <a class="nav-link" href="a_login.php"><h3 class="font-weight-bold">Admin Login</h3></a>
                </li>                
            </ul>
        </div>
    </nav>
    <!-- End of Navigation -DC -->

    <!--  Stretching a reflexive banner across head of pages - DC -->
    <div class="container-fluid no-padding" style="background-color:black;background-image:url(images/stone_tile.png);">
        <div class="row" style="background-color:black;">

            <!--  img-fluid = reflexive; w-100 = 75% Screen -DC -->
            
            <image src="images/website_banner.png" class="img-fluid w-100 mx-auto"></image>
        </div>
    </div>

    <div style="background:black;">

        <br>
        <br>
        <br>

        <!-- Start of The User View Units Body -DC -->      

EOF1;

// Populating HTML blocks with data from the database. -DC
if ($unit_results->num_rows > 0) {
        // output data of each row. -DC
        //echo "<div class=container container-fluid>";
            // echo "<div class=row>";
    
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
            //++$count;
            
            echo '<div class="container container-fluid w-100 rounded pl-5" style="background-image:url(images/stone_tile.png);background-size:contain;">';
            echo '<div class="row mx-auto">';
            echo '<div class="col-sm-4 pt-5"><image src="'.$logo.$unit_img.'" alt="Logo" class="img-fluid pl-5" style="width:300px;"></image>
            <div class="row pb-5 pt-5"><div class="col-sm-12 text-center rounded bg-warning"><h2 class="text-black font-weight-bold">'.$unit_name.'</h2></div></div>
            </div>';
            echo '<div class="col-sm-5">
            <h3 class="text-warning pt-5 pl-5 mx-auto font-weight-bold">'.$unit_name.' Story</h3>
            <p class="text-white pl-5 mx-auto">'.$unit_sty.'</p>
            <div class="row">
            <div class="col-sm-12">
            <p class="text-danger font-weight-bold pl-5 mx-auto">Attack: <span class="text-white">'.$unit_att.'</span></p>
            <p class="text-primary font-weight-bold pl-5 mx-auto">Defense: <span class="text-white">'.$unit_def.'</span></p>
            <p class="text-info font-weight-bold pl-5 mx-auto">Speed: <span class="text-white">'.$unit_spd.'</span></p>
            <p class="text-success font-weight-bold pl-5 mx-auto">Hit Points: <span class="text-white">'.$unit_att.'</span></p> 
            </div>
            </div>
            </div>';
            echo '<div class="col-sm-3"><image class="img-fluid p-5 mx-auto" src="images/logo_text.png"></image></div>';
            echo '</div>';
            echo '</div>';            
            echo '<br>';
                   
                       
            // My way of spacing. -DC
            // $countt = $count / 3;
            
            // if (is_int($countt)){
                
            //    echo '<div class="col-lg-12"><div class="card" style="background-color:black;"><hr size=20 style="border:transparent;visibility:hidden";></hr></div></div>';
            
            //    }           
                
            }
    
            }
            
        echo "</div>";
    echo "</div>";  
echo <<<EOF2

</body>
</html>
 
EOF2;
 
?>
