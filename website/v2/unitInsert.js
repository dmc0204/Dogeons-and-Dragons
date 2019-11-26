var mysql = require('mysql');

function unitInsert() {

    //Getting all the users inputs. -DC
    var uName = document.getElementById("NAME").value;
    var uHP = document.getElementById("HP").value;
    var uAtt = document.getElementById("ATTACK").value;
    var uDef = document.getElementById("DEFENSE").value;
    var uSpd = document.getElementById("SPEED").value;
    var uTyp = document.getElementById("TYPE").value;
    var uSty = document.getElementById("UNIT_STORY").value;
    var uImg = document.getElementById("UNIT_IMAGE").value;

    // Testing my concatenation. -DC
    //    alert("INSERT INTO UNITS (UNIT_ID, TYPE, NAME, HP, ATTACK, DEFENSE, UNIT_STORY, UNIT_IMAGE, SPEED) VALUES (DEFAULT,'" + uTyp + "','" + uName + "','" + uHP + "','" + uAtt + "','" + uDef + "','" + uSty + "','" + uImg + "','" + uSpd + "')");
    // Test passed.
    // Test results:
    // INSERT INTO UNITS (UNIT_ID, TYPE, NAME, HP, ATTACK, DEFENSE, UNIT_STORY, UNIT_IMAGE, SPEED) VALUES (DEFAULT,'6','Doge2','4','6','7','This is a test of insert functionality.','doge.png','6');

   

    // Calling config.js for DB Credentials. -DC
    // let config = require('./config.js');

    // Passing the DB Credentials from config.js. -DC
    var con = mysql.createConnection({
        host: '35.231.30.58',
        port: '3306',
        user: 'root',
        password: 'dogeons0204',
        database: 'dnd'
    });

    con.connect(function(err){
        if (err) throw err;
        //Select all customers and return the result object:

        var sql = "INSERT INTO UNITS (UNIT_ID, TYPE, NAME, HP, ATTACK, DEFENSE, UNIT_STORY, UNIT_IMAGE, SPEED) VALUES (DEFAULT,'" + uTyp + "','" + uName + "','" + uHP + "','" + uAtt + "','" + uDef + "','" + uSty + "','" + uImg + "','" + uSpd + "')";

        alert(rsU);

        con.query(sql, function(err, result){
            if (err) throw err;
            alert("1 Unit Added.");
        });
    });
};
