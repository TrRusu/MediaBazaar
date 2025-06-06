<?php
class ImageValidate extends Database{
    private $passed = false,
        $error = array();
    private $target_file = "";
     
    public function checkFormat($imageFileType){
        $target_dir = "images/";
        $this->target_file = $target_dir . basename($_FILES["fileToUpload"]["name"]);
        $imageFileType = strtolower(pathinfo($this->target_file,PATHINFO_EXTENSION));
        if($imageFileType != "jpg" && $imageFileType != "png" && $imageFileType != "jpeg" && $imageFileType != "gif" ) {
        $this->addError("Sorry, only JPG, JPEG, PNG & GIF files are allowed.");
    }
    }
    
    public function TargetFile(){
        return $this->target_file;
    }
    
    private function addError($error)
    {
        $this->error[] = $error;
    }
 
    public function errors()
    {
        return $this->error;
    }
 
    public function passed()
    {
        return $this->passed;
    }
}