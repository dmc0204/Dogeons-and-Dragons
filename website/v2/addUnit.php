<?php

$dbname = '[Redacted for Public Submission]';
$dbuser = '[Redacted for Public Submission]';
$dbpass = '[Redacted for Public Submission]';
$dbhost = '[Redacted for Public Submission]';

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
        <h1 class="text-center text-warning">Manage Units Page</h1>
        <br>

EOF1;

 $str = <<<EOD
 
 <div class="row">
 <div class="col-sm-3"></div>
 <div class="col-sm-2 text-info font-weight-bold">
    <form action='insertUnit.php' method='post'>
    <fieldset>
        <legend>New Unit Entry</legend>
        Unit Name:
        <input type="text" name="UNIT_NAME" size="25" required>
        <br> Attack:
        <input type="number" name="UNIT_ATTACK" size="25" required>
        <br> Defense:
        <input type="number" name="UNIT_DEFENSE" size="25" required>
        <br> Speed:
        <input type="number" name="UNIT_SPEED" size="25" required>
        <br> Hitpoints:
        <input type="number" name="UNIT_HP" size="25" required>
        <br> Type:
        <input type="number" name="UNIT_TYPE" size="25" required>
        <br> Story:
        <input type="text" name="UNIT_STORY" size="25" required>
        <br> Image:
        <input type="text" name="UNIT_IMG" size="25" required>
        <input type="submit" name="btnInsert" value="Insert"><br>
        
    </fieldset>
    </form>
    </div>
    <div class="col-sm-7 text-warning">
    
EOD;
    
    echo $str;

if ($c_results->num_rows > 0) {
           
    
    
       echo "<h4>Units</h4>";
        echo "<table>";
        echo "<thead><tr><td>Unit ID</td> <td>Unit Name ID</td> <td>Unit Type</td><td>Unit Image</td> ";
        echo "<td> Delete? </td></tr></thead>";   
        while($row = $c_results->fetch_assoc()) 
        {
            echo "<tbody><tr>";
            $UNIT_ID = $row["UNIT_ID"];
            echo  "<td>" . $UNIT_ID . "  </td> <td> " . $row["NAME"] . 
                  " </td> <td> " . $row["TYPE"] . 
    		      " </td> <td> " . $row["UNIT_IMAGE"] .
                  "</td>  <td> "; 
               
            echo "<form action='deleteUnits.php' method='post' style='display:inline' >";
            echo "<input type='hidden' name='UNIT_ID' value='{$UNIT_ID}'>";
            echo "<input type='submit' name='btnDelete' value='Delete'></form>";
            echo "</td></tr></tbody>";
        }
      
                }
            
            
  
    

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