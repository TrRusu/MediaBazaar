<?php
//escape function; sanitizing data that goes in and out
function escape($string){
    return htmlentities($string, ENT_QUOTES, 'UTF-8');
}