<?php

$dbname = '';
$dbuser = '';
$dbpass = '';
$dbhost = '';

$connect = mysqli_connect($dbhost, $dbuser, $dbpass) or die("Unable to Connect to '$dbhost'");

mysqli_select_db($connect, $dbname) or die("Could not open the db '$dbname'");

// $c_query = "SELECT * FROM UNITS";

// $c_results = mysqli_query($connect, $c_query);



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
                    <a class="nav-link" href="a_news.php"><h3 class="font-weight-bold">Edit News</h3></a>
                </li>
                <li class="nav-item p-2">
                    <a class="nav-link" href="a_story.php"><h3 class="font-weight-bold">Edit Story</h3></a>
                </li>
                <li class="nav-item p-2">
                    <a class="nav-link" href="a_tutorials.php.php"><h3 class="font-weight-bold">Edit Tutorials</h3></a>
                </li>
                <li class="nav-item active p-2">
                    <a class="nav-link" href="a_units.php"><h3 class="font-weight-bold">Edit Units</h3></a>
                </li>
                <li class="nav-item p-2">
                    <a class="nav-link" href="a_chewables.php"><h3 class="font-weight-bold">Edit Chewables</h3></a>
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
    <h1 class="text-center text-warning font-weight-bold bg-dark p-2">Add New Unit</h1>

EOF1;

 $str = <<<EOD
 
 <div class="row" style="background-image:url(images/stone_tile.png);">
 <div class="col-sm-3"></div>
 <div class="col-sm-6 text-info font-weight-bold">
 <form action="insertUnit.php" method="post">
 <fieldset>
                    <br>
                    <div class="form-group">
                        <label for="name" class="text-warning font-weight-bold">Unit Name:</label>
                        <input type="text" class="form-control" name="UNIT_NAME" id="UNIT_NAME" required>
                    </div>
                    
                    <div class="form-group w-25 mx-auto">
                        <label for="attack" class="text-warning font-weight-bold">Attack:</label>
                        <input type="number" class="form-control" name="UNIT_ATTACK" id="UNIT_ATTACK" required>
                    </div>
                    <div class="form-group w-25 mx-auto">
                        <label for="defense" class="text-warning font-weight-bold">Defense:</label>
                        <input type="number" class="form-control" name="UNIT_DEFENSE" id="UNIT_DEFENSE" required>
                    </div>
                    <div class="form-group w-25 mx-auto">
                        <label for="speed" class="text-warning font-weight-bold">Speed:</label>
                        <input type="number" class="form-control" name="UNIT_SPEED" id="UNIT_SPEED" required>
                    </div>
                    <div class="form-group w-25 mx-auto">
                        <label for="hitpoints" class="text-warning font-weight-bold">Hit Points:</label>
                        <input type="number" class="form-control" name="UNIT_HP" id="HP" required>
                    </div>
                    <div class="form-group w-25 mx-auto">
                        <label for="type" class="text-warning font-weight-bold">Unit Type:</label>
                        <input type="number" class="form-control" name="UNIT_TYPE" id="UNIT_TYPE" required>
                    </div>                    
                    <div class="form-group">
                        <label for="story" class="text-warning font-weight-bold">Unit Story:</label>
                        <input type="text" class="form-control" name="UNIT_STORY" id="UNIT_STORY" required>
                    </div>
                    <div class="form-group w-25 mx-auto">
                        <label for="image" class="text-warning font-weight-bold">Unit Image Name:</label>
                        <input type="text" class="form-control" name="UNIT_IMG" id="UNIT_IMAGE" required>
                    </div>
                    <div class="mx-auto text-right p-4">
                        <button type="submit" name="btnInsert" value="Insert" class="btn btn-lg btn-secondary font-weight-bold">Add Unit</button>
                    </div>
                    <br>
                    </fieldset>
                </form>    
    </div>
    <div class="col-sm-3 text-warning">
    
EOD;
    
    echo $str;  

echo <<<EOF2

</div>
</div>

<br>
<br>
<br>
</body>
</html>
 
EOF2;
 
?>