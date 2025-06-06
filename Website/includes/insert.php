<?php
session_start();
//insert.php

 $dsn = 'mysql:dbname=insert;host=insert';
   $user = 'insert';
   $password = 'insert';
        

      $pdo = new PDO($dsn, $user, $password);
      $pdo->setAttribute(PDO::ATTR_DEFAULT_FETCH_MODE, PDO::FETCH_ASSOC);


 $query = "
 INSERT INTO schedulepreferences 
 (fullName, Shift, start_event, end_event, a_week, a_weekDay) 
 VALUES (:name, :Shift,:start_event, :end_event, :a_week, :a_weekDay)
 ";

$queryVacation = "
 INSERT INTO vacation 
 (fullName, start_event, end_event, a_week, a_weekDay, status) 
 VALUES (:name, :start_event, :end_event, :a_week, :a_weekDay, :status)
 ";

 $date = $_POST['start'];
 $ndate = new DateTime($date);
 $week = $ndate->format("W");
 $weekDay =$ndate->format("N");

//  var_dump($_POST['morning']);
//         var_dump($_POST['afternoon']);
//         var_dump($_POST['evening']);
//         var_dump($_POST['vacation']);



if(!empty($_POST['vacation'])){
  $statement = $pdo->prepare($queryVacation);
  $statement->execute(
    array(
      ':name' => $_SESSION['firstName'].' '.$_SESSION['lastName'],
      ':start_event'   => $_POST['start'],
      ':end_event'   => $_POST['end'],
      ':a_week' => $week,
      ':a_weekDay' => $weekDay,
      ':status' => "Pending"
    )
   );
}

if(!empty($_POST['morning'])){
   $statement = $pdo->prepare($query);
   $statement->execute(
  array(
    ':name' => $_SESSION['firstName'].' '.$_SESSION['lastName'],
    ':Shift'   => $_POST['morning'],
    ':start_event'   => $_POST['start'],
    ':end_event'   => $_POST['end'],
    ':a_week' => $week,
    ':a_weekDay' => $weekDay
  )
 );
}

if(!empty($_POST['afternoon'])){
  $statement = $pdo->prepare($query);
  $statement->execute(
    array(
      ':name' => $_SESSION['firstName'].' '.$_SESSION['lastName'],
      ':Shift'   => $_POST['afternoon'],
      ':start_event'   => $_POST['start'],
      ':end_event'   => $_POST['end'],
      ':a_week' => $week,
      ':a_weekDay' => $weekDay
    )
   );
}

if(!empty($_POST['evening'])){
  $statement = $pdo->prepare($query);
  $statement->execute(
    array(
      ':name' => $_SESSION['firstName'].' '.$_SESSION['lastName'],
      ':Shift'   => $_POST['evening'],
      ':start_event'   => $_POST['start'],
      ':end_event'   => $_POST['end'],
      ':a_week' => $week,
      ':a_weekDay' => $weekDay
    )
   );
}


header('Location: ../schedule.php');

