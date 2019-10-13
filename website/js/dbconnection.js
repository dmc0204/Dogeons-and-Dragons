var mysql = require('mysql');

var con = mysql.createConnection({
  host: "35.231.30.58",
  user: "root",
  password: "dogeons0204"
});

con.connect(function(err) {
  if (err) throw err;
  console.log("Connected!");
});