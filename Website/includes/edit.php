<?php

session_start();
// include_once 'includes/dbconnection.php';
$user_name = "insert";
$password = "insert";
$database = "insert";
$server = "insert";

$db=mysqli_connect($server, $user_name, $password, $database);

if (isset($_SESSION['loggedin_name'])) {
    
    $username = $_SESSION['loggedin_name'];

    // $first_name = $_SESSION['first_name'];
    // $last_name = $_SESSION['last_name'];
    // $birthdate = $_SESSION['birthdate'];
    // $birthplace = $_SESSION['birthplace'];
    // $bsn = $_SESSION['bsn'];
    // $address = $_SESSION['address'];
    // $zip_code = $_SESSION['zip_code'];
    // $email = $_SESSION['email'];
    // $user = $username;
    // $pass = $_SESSION['pass'];
    // $start_date = $_SESSION['start_date'];
    // $position = $_SESSION['position'];
    // $department = $_SESSION['department'];
    // $end_date = $_SESSION['end_date'];
    // $contract_type = $_SESSION['contract_type'];

    $result = mysqli_query($db, "SELECT * FROM user WHERE username = '$username' ") or die("Failed to query database" . mysqli_error($db));
    $row = mysqli_fetch_array($result);
    $first_name = $row['firstName'];
    $last_name = $row['lastName'];
    $birthdate = $row['birthDate'];
    $birthplace = $row['birthPlace'];
    $bsn = $row['bsn'];
    $address = $row['address'];
    $zip_code = $row['zipcode'];
    $email = $row['email'];
    $user = $username;
    $pass = $row['password'];
    $start_date = $row['startDate'];
    $position = $row['position'];
    $department = $row['department'];
    $end_date = $row['endDate'];
    $contract_type = $row['contractType'];
    
    $_SESSION['firstName']= $first_name;
    $_SESSION['lastName']= $last_name;
}


if(isset($_POST['save'])){

    $username = $_SESSION['loggedin_name'];

    $first_name = $_POST['first_name'];
    $last_name = $_POST['last_name'];
    $birthdate = $_POST['birthday'];
    $birthplace = $_POST['birthplace'];
    $bsn = $_POST['bsn'];
    $address = $_POST['address'];
    $zip_code = $_POST['zip_code'];
    $email = $_POST['email'];
    $user = $_POST['user'];
    $pass = $_POST['pass'];
    $start_date = $_POST['start_date'];
    $position = $_POST['position'];
    $department = $_POST['department'];
    $end_date = $_POST['end_date'];
    $contract_type = $_POST['contract_type'];

    $result = mysqli_query($db, "UPDATE user SET firstName = '$first_name', lastName = '$last_name', birthDate = '$birthdate', birthPlace = '$birthplace', bsn = '$bsn', address = '$address', zipcode = '$zip_code', email = '$email', username = '$user', password = '$pass', startDate = '$start_date', position = '$position', department = '$department', endDate = '$end_date', contractType = '$contract_type' WHERE username = '$username'") or die("Failed to query database" . mysqli_error($db));
    var_dump($result);

    header("location: ../account.php");
}



