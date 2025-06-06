<?php
require_once 'core/init.php';

?>

<html lang=en>
<head>
    <link rel="shortcut icon" href="redCircle.ico">
    <title>Media Bazaar</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="A platform to share DIY creations">
    <meta name="keyword" content="crafts; arts; homemade; DIY; garden; lifestyle;">
    <link rel="stylesheet" type="text/css" href="css/login_styling.css">
</head>
<body>
    <div class="wrapper">
        <div class="container" id="container">
            <form  method="post">

                <img src="img/MB_logo.png" class="logo">

                <h1>Media Bazaar</h1><br>
                <div class="form-container sign-in-container">
                    <h2>Sign in</h2>

                    <div class="form-group">
                        <p>Username:</p>
                        <div><input type="name" id="name" name="username" placeholder="Username"></div>
                        <span id="names" class=""> </span>
                    </div>

                    <div class="form-group">
                        <p>Password:</p>
                        <div><input type="password" id="password" name="password" placeholder="Password"></div>
                        <span id="pass" class=""> </span>
                    </div>

                    <div class="form-group">
                        <div><button type="submit" name="submit">Sign In</button></div>
                        <br>
                    </div>
                    <?php
                    if (isset($_POST['submit'])){
                        $user = new Users();
                        if($user->authenticate($username=$_POST['username'], $password=$_POST['password'])){
                            header("Location: account.php");
                        }
                        else{
                            echo '<span style="color:#3f3f44;text-align:center;">Invalid username or password</span>';
                        }
                    }
                    ?>
            </form>
        </div>
    </div>
    <div class="footer" id="footer">
        <p class="text">Made by System Techies 2024 &#169; </p>
    </div>
</body>

</html>