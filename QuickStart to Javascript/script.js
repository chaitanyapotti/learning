var beginningScenarios = ["You wake up in a hospital.  It is eerily quiet.  You tiptoe to the door and peek out.", "You are standing in an open field west of a white house with a boarded front door. There is a small mailbox here.", "Desperate times call for desperate measures.  You see a small convenience store up ahead and decide to loot it for goods."];

function randomNumber(range) {
    return Math.round(Math.random() * range);
}

alert(beginningScenarios[randomNumber(beginningScenarios.length - 1)]);

var weaponList = ["shovel", "crossbow", "baseball bat", "rubber chicken"];

var weapon = weaponList[randomNumber(weaponList.length - 1)];

alert("Being that it is the zombie apocalypse, you decide to search for a weapon first. After surveying your surroundings you notice and grab a " + weapon + ".");

alert("Suddenly a zombie bursts through the door!  You ready your " + weapon + " and advance towards the zombie.");

var survival = randomNumber(2);

if (survival === 0) {
    alert("The zombie bites you.  You lose!!!");
} else if (survival > 0) {
    alert("You kill the zombie with your" + " " + weapon + ". You win!");
}

