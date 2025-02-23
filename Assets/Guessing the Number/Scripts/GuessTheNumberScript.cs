using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuessTheNumberScript : MonoBehaviour
{
    public int smallestNumber = 0;
    public int largestNumber = 99;
    public TextMeshProUGUI hintsText;
    public TextMeshProUGUI guessText;

    private int currentNumber;

    private int numberOfGuesses;
    private int score;

    void Start()
    {
        currentNumber = GenerateRandomNumber();
        GenerateHints(currentNumber);
        numberOfGuesses = 0;
        score = 0;
    }

    public void ShowGameEnd()
    {
        guessText.text = "Game Over";
        hintsText.text = "";
        hintsText.text += "\n" + "Total Guesses: " + numberOfGuesses.ToString() + "\n";
        hintsText.text += "\n" + "Number of Correct Guesses: " + score.ToString() + "\n";
    }

    public int GenerateRandomNumber()
    {
        return Random.Range(smallestNumber, largestNumber+1);
    }

    public void CheckGuess(string guess)
    {
        numberOfGuesses++;
        guessText.text = "You guessed " + guess + "\n";
        
        // LESSON 3-1: Add code below.
        int intGuess = int.Parse(guess);
        if(intGuess == currentNumber)
        {
            score ++;
            guessText.text = "You guessed the number correctly!";
            currentNumber = GenerateRandomNumber();
            GenerateHints(currentNumber);
        }
        else
        {
            if(intGuess > currentNumber)
            {
                guessText.text = "Your guess is too big.";
            }
            else
            {
                guessText.text = "Your guess is too small.";
            }
        }
    }

    public void GenerateHints(int chosenNumber)
    {
        string hints = "";

        // LESSON 3-1: Add code below.
        if(chosenNumber %2 == 0)
        {
            hints += "Your number is even.\n";
        }
        else
        {
            hints += "Your number is odd.\n";
        }
        if(chosenNumber > 50)
        {
            hints += "Your number is more than 50.\n";
        }
        else
        {
            hints += "Your number is less or equal to 50.\n";
        }

        hintsText.text = hints;
    }
}
