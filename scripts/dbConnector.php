<?php
// establishing PDO connection with database
try {
    $connection = new PDO('mysql:dbname=deepseaworld;host=127.0.0.1','root','root');
    $connection->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
    $connection->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
} catch (PDOException $e) {

}

?>
