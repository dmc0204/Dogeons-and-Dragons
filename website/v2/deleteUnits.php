<?php

$dbname = '[Redacted for Public Submission]';
$dbuser = '[Redacted for Public Submission]';
$dbpass = '[Redacted for Public Submission]';
$dbhost = '[Redacted for Public Submission]';

$connect = mysqli_connect($dbhost, $dbuser, $dbpass) or die("Unable to Connect to '$dbhost'");

mysqli_select_db($connect, $dbname) or die("Could not open the db '$dbname'");
$c_query = "SELECT * FROM UNITS";

$c_results = mysqli_query($connect, $c_query);
global $connect;

/* echo <<<EOF1
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
    <div class="container-fluid no-padding">
        <div class="row">

            <!--  img-fluid = reflexive; w-100 = 100% Screen -DC -->
            <image src="images/website_banner_new.png" class="img-fluid w-100"></image>
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
        <h1 class="text-center text-warning">Deleted Unit</h1>
        <br>
        
        EOF1; */

    $UNIT_ID = $_POST['UNIT_ID'];
    if (!empty($UNIT_ID)){
        $sql = "DELETE FROM UNITS WHERE UNIT_ID = '$UNIT_ID'";
        if ($connect->query ($sql) == TRUE) {
            // Returning to the previous screen after insertion. -DC
        if (isset($_SERVER["HTTP_REFERER"])) {
        header("Location: " . $_SERVER["HTTP_REFERER"]);
        }
        }
        else
        {
            echo "Could not add record: " . $connect->connect_error . "<br>";
        }
    }
    else
    {
        echo "Must provide a ID to delete a record <br>";
    }
    ?>