<?php
session_start();

// connect to DB
$host = 'insert';
$db   = 'insert';
$user = 'insert';
$pass = 'insert';
$charset = 'utf8mb4';

$dsn = "mysql:host=$host;dbname=$db;charset=$charset";
$options = [
    PDO::ATTR_ERRMODE            => PDO::ERRMODE_EXCEPTION,
    PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
    PDO::ATTR_EMULATE_PREPARES   => false,
];
try {
     $pdo = new PDO($dsn, $user, $pass, $options);
} catch (\PDOException $e) {
     throw new \PDOException($e->getMessage(), (int)$e->getCode());
}

$data = array();
$data2 = array();
$data3 = array();

$data4 = array();
$data5 = array();

// QUerry data
$stmt = $pdo->query("SELECT * FROM schedule WHERE name='".$_SESSION['firstName'].' '.$_SESSION['lastName']."';");

// Loop through data, format it and add to the array.
while ($row = $stmt->fetch())
{
    $start = new DateTime();
    $end = new DateTime();
    $start->setISODate(2020,$row["Week"],$row["Day"]); //year , week num , day
    $end -> setISODate(2020,$row["Week"],$row["Day"]);

    if ($row["Shift"] === "Morning")
        {
          $start -> setTime(8,00);
          $end -> setTime(12,30);
        }
        else if($row["Shift"] === "Afternoon")
        {
          $start -> setTime(12,30);
          $end -> setTime(17,00);
        } 
        else if ($row["Shift"] === "Evening")
        {
          $start -> setTime(17,00);
          $end -> setTime(21,30);
        }

    // create array object and add it to array.
   array_push($data,array(

    'title'   => $row["Shift"].  "\n"  .$row["Department"],
    'start'   => $start->format('Y-m-d H:i:s'),
    'end'     => $end->format('Y-m-d H:i:s')
   ));
}

$stmt2 = $pdo->query("SELECT * FROM schedulepreferences WHERE fullName='".$_SESSION['firstName'].' '.$_SESSION['lastName']."';");

// Loop through data, format it and add to the array.
while ($row = $stmt2->fetch())
{
    

    // create array object and add it to array.
   array_push($data2,array(

    'id' => $row['id'],
    'title'   => $row["Shift"],
    'start'   => $row["start_event"],
    'end'   => $row["end_event"],
    'allDay'   => true
   ));
}

   // create json object and return it
   
$data4 = array_merge($data, $data2);


$stmt3 = $pdo->query("SELECT * FROM vacation WHERE fullName='".$_SESSION['firstName'].' '.$_SESSION['lastName']."';");

// Loop through data, format it and add to the array.
while ($row = $stmt3->fetch())
{
    

    // create array object and add it to array.
   array_push($data3,array(

    'id' => $row['id'],
    'title'   => "Vacation " .$row['status'],
    'start'   => $row["start_event"],
    'end'   => $row["end_event"],
    'allDay'   => true
   ));
}

   // create json object and return it
echo json_encode(array_merge($data4, $data3));

