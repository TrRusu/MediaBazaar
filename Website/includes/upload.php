<?php

//update.php

$connect = new PDO('<servername>', '<databasename>', '<password>', '<username>');

if(isset($_POST["id"]))
{
 $query = "
 UPDATE events 
 SET title=:title, start_event=:start_event, end_event=:end_event 
 WHERE id=:id
 ";
 $statement = $connect->prepare($query);
 $statement->execute(
  array(
   ':id'  => $_POST['id'],
   ':name' => $_POST['name'],
   ':department' => $_POST['department'],
   ':shift'   => $_POST['shift'],
   ':day'   => $_POST['day'],
   ':week'   => $_POST['week'],
   ':Type'   => $_POST['Type'],
  )
 );
}
