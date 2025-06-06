<?php
class Encryption {
    // Extract the public key into $public_key
    public $public_key;

    function __construct() {
        $configargs = array(
            "config" => "C:/xampp/php/extras/openssl/openssl.cnf",
            'private_key_bits'=> 512,
            'default_md' => "sha256",
          );
        
           // Create the private and public key
          $res=openssl_pkey_new($configargs);

        // Extract the private key from $res to $privKey
        openssl_pkey_export($res, $privKey);

        $this->public_key = openssl_pkey_get_details($res);

        // Extract the private key into $private_key
        openssl_pkey_export($res, $private_key);
    }





    public function getPublicKey(){
        return $this->public_key["key"];
    }
}
?>
