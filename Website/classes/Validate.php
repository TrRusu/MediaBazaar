<?php
class Validate extends User
{
    private $passed = false,
        $error = array(),
        $user = null;
 
    
    public function checkEmail($email)
    {
        $this->user = new User();
 
        if (empty($email)) {
            $this->addError("Email is required.");
            return false;
        } else {
 
            if ($this->user->checkDuplicate($email)) {
                $this->addError("Email already exists.");
                return false;
            }
        }
        return true;
    }
 
    public function checkPasswords($password, $repeatPassword){
        if(empty($password)){
            $this->addError("Password is required.");
            return false;
        }
        else{
            if($password != $repeatPassword){
                $this->addError("Password and repeat password need to match.");
                return false;
            }
        }
        return true;
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


