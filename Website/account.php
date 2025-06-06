<?php require_once 'core/init.php';

if (isset($_POST['save-personal'])){

    $user = new Users();
    $user->updatePersonalDetails($_POST['first_name'], $_POST['last_name'], $_POST['address'], $_POST['zip_code'], $_POST['email'], $_SESSION['username']);  
}
else if (isset($_POST['save-account'])){
    $user = new Users();
    $user->updateAccountDetails($_POST['pass'], $_SESSION['username']);  
}
?>

<html lang=en>

<head>
    <link rel="shortcut icon" href="redCircle.ico">
    <title>Account</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="A platform to share DIY creations">
    <meta name="keyword" content="crafts; arts; homemade; DIY; garden; lifestyle;">
    <link rel="stylesheet" type="text/css" href="css/main_styling.css">
</head>

<body>
    <div class="wrapper">
        <div class="header">
            <ul>
                <li><a href="schedule.php">Schedule</a></li>
                <li><a href="account.php">Account</a></li>
                
                <li><a href="includes/logout.php"><button type="submit" name="submit">Sign Out</button></a></li>
            </ul>
        </div>

        <div class="content">
            <form method="post">
                <div class="split left">
                    <div class="inner_grid_left">
                        <?php                     
                       $user = new Users();           
                       $user->getPersonalDetails($_SESSION['username']);                 
                    ?>
                    </div>
                </div>

                <div class="split right">
                    <div class="inner_grid_right_top">
                        <?php
                        $user = new Users();           
                        $user->getAccountDetails($_SESSION['username']);
                    ?>
                    </div>

                    <div class="inner_grid_right_bottom">
                        <?php
                        $user = new Users();           
                        $user->getJobDetails($_SESSION['username']);
                    ?>
                    </div>
                </div>
            </form>
        </div>

        <div class="footer">
            <p class="text">Made by System Techies 2024 &#169;</p>
        </div>  
    </div>
</body>
</html>