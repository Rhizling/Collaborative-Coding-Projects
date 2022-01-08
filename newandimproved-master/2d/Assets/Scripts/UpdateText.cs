using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class UpdateText : MonoBehaviour
{
    public TextMeshProUGUI Description;
    public TextMeshProUGUI Requirement;
    public TextMeshProUGUI Coin;
    public TextMeshProUGUI Time;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI Total;
    private int levelBonus = 100; //default bonus is 100

    // Start is called before the first frame update
    void Start()
    {

        if (PermanentUI.perm.LastScene == 0)
        {
            if (PermanentUI.perm.hardBool) //sets time based on difficulty mode
            {
                PermanentUI.perm.time = 60;
            }
            else
            {
                PermanentUI.perm.time = 90;

            }
            PermanentUI.perm.menumusic.Stop();
            //set text
            Description.text = "Service: March of Dimes needs your help fundraising! Collect 75 coins in " + PermanentUI.perm.time + " seconds";
            //empty because nothing is obtained yet
            Requirement.text = "";
            Coin.text = "";
            Time.text = "";
            Level.text = "";
            Total.text = "";
            PermanentUI.perm.points += PermanentUI.perm.levelpoints;
            //reset current scores
            PermanentUI.perm.Reset();
        }
        else if (PermanentUI.perm.LastScene == 1)
        {
            PermanentUI.perm.music1.Stop();
            if (PermanentUI.perm.hardBool)
            {
                levelBonus = 1000;
                PermanentUI.perm.time = 60;
            }
            else
            {
                levelBonus = 100;
                PermanentUI.perm.time = 90;
            }
            Description.text = "Education: Answer 5 questions in " + PermanentUI.perm.time + " seconds to learn about FBLA's Business Achievement Awards!";
            Requirement.text = "You made it! You collected 75 coins for your local chapter and donated to the March of Dimes";
            Coin.text = "Coin Bonus: "+ PermanentUI.perm.coins*10;
            Time.text = "Time Bonus: " + PermanentUI.perm.timescore;

            Level.text = "Level Bonus: " + levelBonus;
            PermanentUI.perm.points += PermanentUI.perm.levelpoints;
            PermanentUI.perm.points += levelBonus;
            PermanentUI.perm.points += PermanentUI.perm.timescore;
            Total.text = "You have "+ PermanentUI.perm.points+ " points";
            PermanentUI.perm.Reset();

        }
        else if (PermanentUI.perm.LastScene == 2)
        {
            if (PermanentUI.perm.hardBool)
            {
                levelBonus = 1000;
                PermanentUI.perm.time = 150;
            }
            else
            {
                levelBonus = 100;
                PermanentUI.perm.time = 250;
            }
            PermanentUI.perm.music2.Stop();
            Description.text = "Progress: Your local chapter needs more members! Recruit 15 members in " + PermanentUI.perm.time + " seconds to get to the next level";
            Requirement.text = "Congratulations!   You got them all right!                                ";
            Coin.text = "Coin Bonus: " + PermanentUI.perm.coins * 10;
            Time.text = "Time Bonus: " + PermanentUI.perm.timescore;

            Level.text = "Level Bonus: " + levelBonus;
            PermanentUI.perm.points += PermanentUI.perm.levelpoints;
            PermanentUI.perm.points += levelBonus;
            PermanentUI.perm.points += PermanentUI.perm.timescore;
            Total.text = "You have " + PermanentUI.perm.points + " points";
            PermanentUI.perm.Reset();
        }
        else if (PermanentUI.perm.LastScene == 3)
        {
            PermanentUI.perm.music3.Stop();
            if (PermanentUI.perm.hardBool)
            {
                levelBonus = 1000;
                PermanentUI.perm.time = 200;
            }
            else
            {
                levelBonus = 100;
                PermanentUI.perm.time = 500;
            }
            Description.text = "Great Work! Get to the conference as fast as you can to claim your awards! You have 180 seconds!";
            Requirement.text = "";
            Coin.text = "Coin Bonus: " + PermanentUI.perm.coins * 10;
            Time.text = "Time Bonus: " + PermanentUI.perm.timescore;

            Level.text = "Level Bonus: " + levelBonus;
            PermanentUI.perm.points += PermanentUI.perm.levelpoints;
            PermanentUI.perm.points += levelBonus;
            PermanentUI.perm.points += PermanentUI.perm.timescore;
            Total.text = "You have " + PermanentUI.perm.points + " points";
            PermanentUI.perm.Reset();
            PermanentUI.perm.lives = 15;
        }
        else if (PermanentUI.perm.LastScene == 4)
        {
            PermanentUI.perm.music4.Stop();
            Description.text = "";
            Requirement.text = "";
            Coin.text = "Coin Bonus: " + PermanentUI.perm.coins * 10;
            Time.text = "Time Bonus: " + PermanentUI.perm.timescore;
            if (PermanentUI.perm.hardBool)
            {
                levelBonus = 2000;
            }
            else
            {
                levelBonus = 1000;
            }
            Level.text = "Completion Bonus: " + levelBonus;
            PermanentUI.perm.points += PermanentUI.perm.levelpoints;
            PermanentUI.perm.points += PermanentUI.perm.timescore;
            PermanentUI.perm.points += levelBonus;
            Total.text = "You have " + PermanentUI.perm.points + " points";
            PermanentUI.perm.Reset();
            PermanentUI.perm.diduwin = true;
        }
    }
    public void NextScene()
    {
        //different music played according to level
        if (PermanentUI.perm.LastScene == 0)
        {
            PermanentUI.perm.music1.Play();
        }
        else if (PermanentUI.perm.LastScene == 1)
        {
            PermanentUI.perm.music2.Play();
        }
        else if (PermanentUI.perm.LastScene == 2)
        {
            PermanentUI.perm.music3.Play();
        }
        else if (PermanentUI.perm.LastScene == 3)
        {
            PermanentUI.perm.music4.Play();
        }
        SceneManager.LoadScene(PermanentUI.perm.LastScene + 1);

    }
}
