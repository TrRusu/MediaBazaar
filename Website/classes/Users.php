<?php

class Users extends Database
{

       public function authenticate($username, $pass)
       {
              $user = null;
              $sql = "SELECT firstName, lastName, username FROM user WHERE username=? AND password=?";
              $prepared = $this->connect()->prepare($sql);
              $prepared->execute([$username, $pass]);
              $user = $prepared->fetchAll();

              if (!empty($user)) {
                     foreach ($user as $entry) {
                            $_SESSION['firstName'] = "{$entry['firstName']}";
                            $_SESSION['lastName'] = "{$entry['lastName']}";
                            $_SESSION['username'] = "{$entry['username']}";
                            
                     }
                     return true;
              } else {
                     return false;
              }
       }

       public function updatePersonalDetails($firstname, $lastName, $address, $zipcode, $email, $username)
       {
              $sql = "UPDATE user SET firstName=?, lastName=?, address=?, zipcode=?, email=? WHERE username=?";
              $prepared = $this->connect()->prepare($sql);
              $prepared->execute([$firstname, $lastName, $address, $zipcode, $email, $username]);
       }


       public function getPersonalDetails($username)
       {

              $user = null;
              $sql = "SELECT firstName, lastName, birthDate, birthPlace, bsn, address, zipcode, email FROM user WHERE username=?";
              $prepared = $this->connect()->prepare($sql);
              $prepared->execute([$username]);
              $user = $prepared->fetchAll();
              

              foreach($user as $detail){
                     echo "<h4 class='pi'>Personal Information</h4>
                    <p>First Name:</p>
                    <input type='text' id='first_name' name='first_name' value='$detail[firstName]'>
                    <p>Last Name:</p>
                    <input type='text' id='last_name' name='last_name' value='$detail[lastName]'>
                    <p>Birthdate:</p>
                    <input type='text' id='birthday' name='birthday' value='$detail[birthDate]' disabled>
                    <p>Birthplace</p>
                    <input type='text' id='birthplace' name='birthplace' value='$detail[birthPlace]' disabled>
                    <p>BSN:</p>
                    <input type='text' id='bsn' name='bsn' value='$detail[bsn]' disabled>
                    <p>Address:</p>
                    <input type='text' id='address' name='address' value='$detail[address]'>
                    <p>Zip Code:</p>
                    <input type='text' id='zip_code' name='zip_code' value='$detail[zipcode]'>
                    <p>Email:</p>
                    <input type='email' id='email' name='email' value='$detail[email]'>
                    <div><button type='submit' name='save-personal' class='save'>Save</button></div>";
              }
       }

       public function getAccountDetails($username)
       {

              $user = null;
              $sql = "SELECT username, password FROM user WHERE username=?";
              $prepared = $this->connect()->prepare($sql);
              $prepared->execute([$username]);
              $user = $prepared->fetchAll();
              

              foreach($user as $detail){
                     echo "<h5 class='pi'>Account Information</h5>
                    <p>Username:</p>
                    <input type='text' id='username' name='user' value='$detail[username]' disabled>
                    <p>Password:</p>
                    <input type='password' id='password' name='pass' value='$detail[password]'>
                    <div><button type='submit' name='save-account' class='save'>Save</button></div>";
              }
       }

       public function updateAccountDetails($password, $username)
       {
              $sql = "UPDATE user SET password=? WHERE username=?";
              $prepared = $this->connect()->prepare($sql);
              $prepared->execute([$password, $username]);
       }

       public function getJobDetails($username)
       {

              $user = null;
              $sql = "SELECT startDate, position, department, endDate, contractType FROM user WHERE username=?";
              $prepared = $this->connect()->prepare($sql);
              $prepared->execute([$username]);
              $user = $prepared->fetchAll();
              

              foreach($user as $detail){
                     echo "<h6 class='pi'>Contract Information</h6>
                    <p>Start Date:</p>
                    <input type='text' id='start_date' name='start_date' value='$detail[startDate]' disabled>
                    <p>Position:</p>
                    <input type='text' id='position' name='position' value='$detail[position]' disabled>
                    <p>Department:</p>
                    <input type='text' id='department' name='department' value='$detail[department]' disabled>
                    <p>End Date:</p>
                    <input type='text' id='end_date' name='end_date' value='$detail[endDate]' disabled>
                    <p>Contract type:</p>
                    <input type='text' id='contract_type' name='contract_type' value='$detail[contractType]' disabled>";                  
              }
       }
}
