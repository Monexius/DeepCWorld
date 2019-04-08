<?php


require_once('dbConnector.php');


$prm1 = "FAQ_ID"; $FAQ_ID =10000; // FAQ_ID limit and string
$prm2 = "Event_ID"; $Events_ID = 10000; // $Events_ID limit and string
$prm3 = "Exhibition_ID"; $Exhibition_ID = 10000; // $Exhibition_ID Limit and string
$prm4 = "Map_ID"; $Map_ID = 10000; // Map_ID Limit and string
$prm5 = "News_ID"; $News_ID = 10000; // News_ID lim'(string)'it and string
$prm6 = "QRCodes_ID"; $QRCodes_ID = 10000; // QRCodes_ID limit and string

$all = "*";

$sql = "SELECT $all FROM faq WHERE $prm1 <= :FAQ_ID"; // sql query for faq table
$sql2 = "SELECT $all FROM events WHERE $prm2 <= :Event_ID"; // sql query for events table
$sql3 = "SELECT $all FROM exhibition WHERE $prm3 <= :Exhibition_ID"; // sql query for exhibitions table
$sql4 = "SELECT $all FROM map WHERE $prm4 <= :Map_ID"; // sql query for map table
$sql5 = "SELECT $all FROM news WHERE $prm5 <= :News_ID"; // sql query for news table
$sql6 = "SELECT $all FROM qrcodes WHERE $prm6 <= :QRCodes_ID"; // sql query for qrcodes table


// calling table content

getTableContent($sql, $FAQ_ID, $connection, $prm1);
getTableContent($sql2, $Events_ID, $connection, $prm2);
getTableContent($sql3, $Exhibition_ID, $connection, $prm3);
getTableContent($sql4, $Map_ID, $connection, $prm4);
getTableContent($sql5, $News_ID, $connection, $prm5);
getTableContent($sql6, $QRCodes_ID, $connection, $prm6);



// get data from table function encode as json

function getTableContent($query, $limit, $connection, $prm)
{
  if(!$stmt = $connection->prepare($query)) // getting data from faq table with use of prepared query
  {
    die("Error");
      }else{
        $stmt->execute(array($prm => $limit));
          $TableHead = array();
          // wile query have data
          while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) { // execution of query / fetching data from table to json /|PDO::FETCH_LAZY) - for just data
          array_push($TableHead,$row);
        }
        $json = json_encode($TableHead);
        echo $json;
      }}

$die;

?>
