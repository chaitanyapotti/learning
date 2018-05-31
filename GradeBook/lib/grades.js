var gradeBook = {
    _grades: [],
    addGrade: function (gradeNum) {
        this._grades.push(gradeNum);
    },
    getCountOfGrades: function () {
        return this._grades.length;
    },
    getLetterGrade: function () {
        var average = this.getAverage();
        if (average >= 90)
            return 'A';
        else if (average >= 80)
            return 'B';
        else if (average >= 70)
            return 'C';
        else if (average >= 60)
            return 'D';
        else
            return 'F';
    },
    getAverage: function () {
        let total = 0;
        this._grades.forEach(element => {
            total += element;
        });
        return total / this.getCountOfGrades();
    },
    reset: function () {
        this._grades = [];
    }
};

exports.book = gradeBook;