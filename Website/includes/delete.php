<?php

//delete.php

$dsn = 'mysql:dbname=<databasename>;host=<hostname>';
   $user = '<username>';
   $password = '<password>';
        

      $pdo = new PDO($dsn, $user, $password);
      $pdo->setAttribute(PDO::ATTR_DEFAULT_FETCH_MODE, PDO::FETCH_ASSOC);

$sqlvacation = 'DELETE FROM vacation '
. 'WHERE id = :id';

$sql = 'DELETE FROM schedulepreferences '
. 'WHERE id = :id';

if ( $_POST["title"] == "Vacation Pending") {
   $stmt = $pdo->prepare($sqlvacation);
   $stmt->bindValue(':id', $_POST['id']);
   
   $stmt->execute();
}else{
   $stmt = $pdo->prepare($sql);
   $stmt->bindValue(':id', $_POST['id']);
   
   $stmt->execute();
}