const mysql = require('mysql');
const express = require('express');
var app = express();
const bodyparser = require('body-parser');

app.use(bodyparser.json());

// Calling config.js for DB Credentials. -DC
let config = require('./config.js');

var mysqlTest = mysql.createConnection(config);

mysqlTest.connect((err) => {
    if (!err)
        console.log('DB connection succeded.');
    else
        console.log('DB connection failed \n Error : ' + JSON.stringify(err, undefined, 2));
});

app.listen(3000, () => console.log('Express server is running at port no : 3000'));

app.get('/UNITS', (res, req) => {

    mysqlConnection.query('SELECT * FROM UNITS', (err, rows, fields) => {

        if (!err)
            console.log(rows);
        else
            console.log(err);

    })

});
