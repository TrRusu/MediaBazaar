<?php

    session_start();
    
    include_once 'dbconnection.php';

    $username = "";
    $password = "";

    //session_start();
    if(isset($_POST['submit'])){
    
    //get values
    //$_SESSION['name']= $name; 
    $username = $_POST['username'];
    $password = $_POST['password'];
    $error = "";

    //to prevent sql injection

    $username = mysqli_real_escape_string($db, $_POST['username']);
    $password = mysqli_real_escape_string($db, $_POST['password']);

    $_SESSION['test'] = $username;

    $result = mysqli_query($db, "SELECT username, password FROM user WHERE username = '$username' and password = '$password'") or die("Failed to query database" .mysqli_error($db));
    $row = mysqli_fetch_array($result);
    if ($row['username'] == $username && $row['password'] == $password) {
        $error = "";
        $success = "Login succesfull. Welcome ".$row['username'];

        header("location: ../schedule.php");
    } else {
        $error = "Invalid email or password";
        $success = "";
        session_start();
        $_SESSION['error_signin'] = $error;
       header("location: ../index.php");
       exit;
       //echo $_POST['error_signin'];
    } 

    }