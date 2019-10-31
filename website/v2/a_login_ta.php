<?php

// Filler code until proper admin access control. -DC
    session_start();
    $username = $_POST['username'];
    $password = $_POST['password'];

    session_start();
    echo "'$username'" . "<br>";
    echo "'$password'" . "<br>";
    if ($username == 'admin' && $password == 'password')
    {
        echo "In True Block";
        $_SESSION['login'] = $username;
        $goto = "Location: a_index.html";  //This is our landing page
    } else {
        echo "In False Block";
        $_SESSION['login'] = '';
	    $ref = getenv("HTTP_REFERER");     //This is the referrer page -- the login form
	    $goto = "Location: " . $ref;
    }	

    echo "Session Login Value = " . $_SESSION['login'] . "<br>";
    header($goto);
?>
