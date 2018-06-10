//Coffee Objects
let myCoffee = {
    flavor: "espresso",
    temperature: "piping hot",
    ounces: 100,
    milk: true,
    reheat: function () {
        if (this.temperature === "cold") {
            this.temperature = "piping hot";
            alert("Your coffee has been reheated");
        }
    }
}

myCoffee.temperature = "cold";
myCoffee.reheat();


class Friend {
    constructor Friend(name, tShirtColor) {

    }
}
