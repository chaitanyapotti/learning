//Blackjack by Skyuppercut
//let card1 = "Ace of Spades", card2 = "Ten of Hearts";

//Card variables
let suits = ['Hearts', 'Clubs', 'Diamonds', 'Spades'];
let values = ['Ace', 'King', 'Queen', 'Jack', 'Ten', 'Nine', 'Eight', 'Seven', 'Six', 'Five', 'Four', 'Three', 'Two'];

//DOM variables
let textArea = document.getElementById('textArea');
let newGameButton = document.getElementById('new-game-button');
let hitButton = document.getElementById('hit-button');
let stayButton = document.getElementById('stay-button');

//Game variables
let gameStarted = false, gameOver = false, playerWon = false, dealerCards = [], playerCards = [], dealerScore = 0, playerScore = 0, deck = [];


hitButton.style.display = 'none';
stayButton.style.display = 'none';
showStatus();

newGameButton.addEventListener("click", function () {
    gameStarted = true;
    gameOver = false;
    playerWon = false;

    deck = createDeck();
    shuffleDeck(deck);
    dealerCards = [getNextCard(), getNextCard()];
    playerCards = [getNextCard(), getNextCard()];

    newGameButton.style.display = 'none';
    hitButton.style.display = 'inline';
    stayButton.style.display = 'inline';

    showStatus();
});

hitButton.addEventListener("click", function () {
    playerCards.push(getNextCard());
    checkForEndOfGame();
    showStatus();
});

stayButton.addEventListener("click", function () {
    gameOver = true;
    checkForEndOfGame();
    showStatus();
});


//loopAndPrint(deck);

function createDeck() {
    let deck = [];
    for (var i = 0; i < suits.length; i++) {
        for (var j = 0; j < values.length; j++) {
            let card = { suit: suits[i], value: values[j] };
            //deck.push(values[j] + " of " + suits[i]);
            deck.push(card);
        }
    }
    return deck;
}

function getNextCard() {
    return deck.shift();
}

function getCardString(card) {
    return card.value + ' of ' + card.suit;
}

function showStatus() {
    if (!gameStarted) {
        textArea.innerText = "Welcome to Blackjack!";
        return;
    }

    let dealerCardString = "";
    for (var i = 0; i < dealerCards.length; i++) {
        dealerCardString += getCardString(dealerCards[i]) + "\n";
    }

    let playerCardString = "";
    for (var i = 0; i < playerCards.length; i++) {
        playerCardString += getCardString(playerCards[i]) + "\n";
    }

    updateScores();

    textArea.innerText = "Dealer has : \n" + dealerCardString + "(score: " + dealerScore + ") \n\n" +
        "Player has : \n" + playerCardString + "(score: " + playerScore + ") \n\n";

    if (gameOver) {
        if (playerWon) {
            textArea.innerText += "YOU WIN!";
        }
        else {
            textArea.innerText += "DEALER WINS!";
        }

        newGameButton.style.display = "inline";
        hitButton.style.display = "none";
        stayButton.style.display = "none";
    }
}

function updateScores() {
    dealerScore = getScore(dealerCards);
    playerScore = getScore(playerCards);
}

function getScore(cardArray) {
    let score = 0;
    let hasAceCard = false;
    for (let i = 0; i < cardArray.length; i++) {
        let card = cardArray[i];
        score += getNumericValue(card);
        if (card.value === "Ace") {
            hasAceCard = true;
        }
    }
    if (hasAceCard && score + 10 <= 21)
        return score + 10;

    return score;
}

function getNumericValue(card) {
    switch (card.value) {
        case "Ace":
            return 1;
        case "Two":
            return 2;
        case "Three":
            return 3;
        case "Four":
            return 4;
        case "Five":
            return 5;
        case "Six":
            return 6;
        case "Seven":
            return 7;
        case "Eight":
            return 8;
        case "Nine":
            return 9;
        default:
            return 10;
    }
}

function shuffleDeck(deck) {
    for (let i = 0; i < deck.length; i++) {
        let swapIdx = Math.trunc(Math.random(deck.length));
        let tmp = deck[swapIdx];
        deck[swapIdx] = deck[i];
        deck[i] = tmp;
    }
}

function checkForEndOfGame() {
    updateScores();

    if (gameOver) {
        while (dealerScore <= playerScore && dealerScore <= 21 && playerScore <= 21) {
            dealerCards.push(getNextCard());
            updateScores();
        }
    }

    if (playerScore > 21) {
        playerWon = false;
        gameOver = true;
    }
    else if (dealerScore > 21) {
        playerWon = true;
        gameOver = true;
    }
    else if (gameOver) {
        if (playerScore > dealerScore) {
            playerWon = true;
        }
        else
            playerWon = false;

        newGameButton.style.display = "inline";
        hitButton.style.display = "none";
        stayButton.style.display = "none";
    }
}

//function changeCard(card) {
//    card.suit = "Clubs";
//}

//let deck = createDeck();

//let playerCards = [getNextCard(), getNextCard()];


//console.log(deck.length);

//console.log("Welcome to Blackjack!");
//console.log("You are dealt: ");
//console.log(" " + getCardString(playerCards[0]));
//console.log(" " + getCardString(playerCards[1]));

//function loopAndPrint(deck) {
//    for (var i = 0; i < deck.length; i++) {
//        console.log(deck[i]);
//    }
//}


//function myFunc(messageValue) {
//    return messageValue * 2;
//}

//let resolve = myFunc(6);
//console.log(resolve);


//let val = true;
//console.log(val, typeof (val));

//let arr = [1, 2, 3, 4];
//arr.splice(1, 3);
//console.log(arr);

//let score = 100;
//if (score === 100) {
//    score += 100;
//}
//console.log(score);

//let state = 'TX';

//switch (state) {
//    case 'NY':
//        console.log('New York');
//        break;
//    case 'TX':
//        console.log('Texas');
//        break;
//    default:
//}

//let card = {
//    suit: "Heart",
//    value: 2
//};
//console.log(card.suit, card.value);

//var date = new Date();
//console.log(date);