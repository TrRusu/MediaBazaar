<?php

class User extends Database {
    public function createUser($name, $email, $password){
        $sql = "INSERT INTO users (name, email, password) VALUES (?, ?, ?)";
        $prepare = $this->connect()->prepare($sql);
        $prepare->execute([$name, $email, $password]);
    }

    public function loginUser($email, $password){
      $user = null;
      $sql = "SELECT name, email, type FROM users WHERE email = ? and password = ?";
      $prepare = $this->connect()->prepare($sql);
      $prepare->execute([$email, $password]);
      $user = $prepare->fetchAll();
      if(!empty($user)){
        foreach($user as $name){
          $_SESSION['name'] = "{$name['name']}";
          $_SESSION['email'] = "{$name['email']}";
          $_SESSION['type'] = "{$name['type']}";
          echo "bla bla";
        }
        return true;
        
      }
      else{
        return false;
      }
    }

    public function updateUserDetails($email, $password){
      $sql = "UPDATE users SET password=? WHERE email=?";
      $prepared = $this->connect()->prepare($sql);
      $prepared->execute([$password, $email]);
    }

    public function GetUserDetails($email){
      $user = null;
      $sql = "SELECT name, password FROM users WHERE email=?";
      $prepared = $this->connect()->prepare($sql);
      $prepared->execute([$email]);
      $user = $prepared->fetchAll();
      foreach($user as $detail){
        echo "
        <form method='post'>
       <p>Password:</p>
       <input type='password' id='oldPassword' name='oldPass' value='$detail[password]'>
       <input type='password' id='newPassword' name='newPass' value='$detail[password]'>
       <div><button type='submit' name='save-account' class='save'>Save</button></div>
       </form>";
 }
    }
    
    public function logoutUser(){
      session_destroy();
      header("location: index.php");
      exit();
    }

    public function checkDuplicate($email){
      $user = null;
      $sql = "SELECT email FROM users WHERE email = ?";
      $prepare = $this->connect()->prepare($sql);
      $prepare->execute([$email]);
      $user = $prepare->fetchAll();
      if(!empty($user)){
        return true;
      }
      else {
        return false;
      }
    }
}