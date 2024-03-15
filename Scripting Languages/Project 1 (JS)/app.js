iconst roundsInput=document.getElementById('roundsInput');
const startButton=document.getElementById('startButton');
const gameSetup=document.getElementById('gameSetup');
const gamePlay=document.getElementById('gamePlay');
const playerButtons=document.getElementById('playerButtons');
const computerChoice=document.getElementById('computerChoice');
const result=document.getElementById('result');
const roundsRemaining=document.getElementById('roundsRemaining');
const gameResult=document.getElementById('gameResult');
const finalResult=document.getElementById('finalResult');

let totalRounds;
let currentRound=0;
let playerScore=0;
let computerScore=0;

const choices=['rock',
'scissors',
'paper',
'lizard',
'spock'];

function getComputerChoice() {
    const randomIndex=Math.floor(Math.random() * choices.length);
    return choices[randomIndex];
}

function playRound(playerSelection, computerSelection) {
    let roundResult;

    if (playerSelection===computerSelection) {
        roundResult="It's a tie!";
    }

    else if ((playerSelection==='rock' && (computerSelection==='scissors' || computerSelection==='lizard')) || (playerSelection==='scissors' && (computerSelection==='paper' || computerSelection==='lizard')) || (playerSelection==='paper' && (computerSelection==='rock' || computerSelection==='spock')) || (playerSelection==='lizard' && (computerSelection==='paper' || computerSelection==='spock')) || (playerSelection==='spock' && (computerSelection==='rock' || computerSelection==='scissors'))) {
        roundResult=`You win ! $ {
            playerSelection
        }

        beats $ {
            computerSelection
        }

        .`;
        playerScore++;
    }

    else {
        roundResult=`Computer wins ! $ {
            computerSelection
        }

        beats $ {
            playerSelection
        }

        .`;
        computerScore++;
    }

    result.textContent=roundResult;
    currentRound++;
    roundsRemaining.textContent=totalRounds - currentRound;

    if (currentRound===totalRounds) {
        endGame();
    }
}

function endGame() {
    gamePlay.style.display='none';
    gameResult.style.display='block';

    if (playerScore > computerScore) {
        finalResult.textContent=`You win the game ! Final score: You $ {
            playerScore
        }

        - Computer $ {
            computerScore
        }

        `;
    }

    else if (playerScore < computerScore) {
        finalResult.textContent=`Computer wins the game ! Final score: You $ {
            playerScore
        }

        - Computer $ {
            computerScore
        }

        `;
    }

    else {
        finalResult.textContent=`It's a tie! Final score: You ${playerScore} - Computer ${computerScore}`;

    }
}

startButton.addEventListener('click', ()=> {
        totalRounds=parseInt(roundsInput.value);

        if (totalRounds < 1) {
            alert('Please enter a valid number of rounds.');
            return;
        }

        gameSetup.style.display='none';
        gamePlay.style.display='block';
        roundsRemaining.textContent=totalRounds;
        currentRound=0;
        playerScore=0;
        computerScore=0;
    });

playerButtons.addEventListener('click', (e)=> {
        if (e.target.classList.contains('gameButton')) {
            const playerSelection=e.target.dataset.choice;
            const computerSelection=getComputerChoice();
            computerChoice.textContent=computerSelection;
            playRound(playerSelection, computerSelection);
        }
    });
