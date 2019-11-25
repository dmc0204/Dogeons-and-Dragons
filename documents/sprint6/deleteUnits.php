<?php

$dbname = '';
$dbuser = '';
$dbpass = '';
$dbhost = '';

$connect = mysqli_connect($dbhost, $dbuser, $dbpass) or die("Unable to Connect to '$dbhost'");

mysqli_select_db($connect, $dbname) or die("Could not open the db '$dbname'");
$c_query = "SELECT * FROM UNITS";

$c_results = mysqli_query($connect, $c_query);
global $connect;


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