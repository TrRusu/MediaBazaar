<?php

class Database
{    
     
  private $dsn = 'mysql:dbname=<databasename>;host=<hostname>';
  private $user = '<username>';
  private $password = '<password>';
        
  public function connect(){
      $pdo = new PDO($this->dsn, $this->user, $this->password);
      $pdo->setAttribute(PDO::ATTR_DEFAULT_FETCH_MODE, PDO::FETCH_ASSOC);
      return $pdo;
  }
}
