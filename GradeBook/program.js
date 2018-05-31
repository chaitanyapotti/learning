var book = require("./lib/grades").book;
var express = require("express");
var app = express();

app.get("/", function (req, response) {
   response.send("Hello World!");
});

app.get("/grade", function (req, response) {
    book.reset();
    var grades = req.query.grades.split(",");
    grades.forEach(element => {
        book.addGrade(parseInt(element));
    });
    var average = book.getAverage();
    var letterGrade = book.getLetterGrade();
    response.send("Your average is "+ average +" grade "+ letterGrade);
});

app.listen(3000);
console.log("Server ready...");