<?php
require_once 'classes/ContentControl.php';
Class UserControl extends ContentControl
{
    
    public function PopulateGallery($table){ 
        $result=$this->FetchContent($table);
        $user = new User();
    foreach ($result as $img){
        if(isset($_SESSION['email'])){
        if($_SESSION['type'] == 1){
            echo "<div class='img_div'>
        <img src='images/{$img['name']}'width='240px' height ='220px'>
        <p>{$img['name']}</p>
        </div>";
        }
        else{
            echo "<div class='img_div'>
        <img src='images/{$img['name']}'width='240px' height ='220px'>
        </div>";
        }
    }
    else{
        echo "<div class='img_div'>
        <img src='images/{$img['name']}'width='240px' height ='220px'>
        </div>";
    }
    }
}
}