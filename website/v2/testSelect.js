var mysql = require('mysql');

// Calling config.js for DB Credentials. -DC
let config = require('./config.js');

// Passing the DB Credentials from config.js. -DC
var con = mysql.createConnection(config);

con.connect(function(err) {
  if (err) throw err;
  //Select all customers and return the result object:
  con.query("SELECT * FROM UNITS", function (err, result, fields) {
    if (err) throw err;
    result.forEach(function(element) {console.log(element)});
  });
});