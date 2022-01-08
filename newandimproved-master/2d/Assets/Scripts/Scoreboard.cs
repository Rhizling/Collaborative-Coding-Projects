using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    //list of scores and names
    private List<int> highscore = new List<int>() { 0, 0, 0, 0, 0 };
    private List<string> names = new List<string>() { "", "", "", "", "" };
    public Text firstScore;
    public Text secondScore;
    public Text thirdScore;
    public Text fourthScore;
    public Text fifthScore;

    public Text firstName;
    public Text secondName;
    public Text thirdName;
    public Text fourthName;
    public Text fifthName;

    //current score and name
    private int scoreboardscore = PermanentUI.perm.points;
    private string accName = PermanentUI.perm.name;


    public static bool firstCall = true;

    public void ArrangeScore()
    {
        highscore = new List<int>() { PlayerPrefs.GetInt("firstScore"), PlayerPrefs.GetInt("secondScore") , PlayerPrefs.GetInt("thirdScore") , PlayerPrefs.GetInt("fourthScore") , PlayerPrefs.GetInt("fifthScore") };
        names = new List<string>() { PlayerPrefs.GetString("firstName"), PlayerPrefs.GetString("secondName"), PlayerPrefs.GetString("thirdName"), PlayerPrefs.GetString("fourthName"), PlayerPrefs.GetString("fifthName") };
        //links score element and name element
        highscore.Add(scoreboardscore);
        names.Add(accName);
        //simple bubble sort
        for (int i = 0; i < highscore.Count; i++)
        {
            for (int j = i + 1; j < highscore.Count; j++)
            {
                if (highscore[j] > highscore[i])
                {
                    //swap
                    int tempScore = highscore[i];
                    highscore[i] = highscore[j];
                    highscore[j] = tempScore;

                    string tempName = names[i];
                    names[i] = names[j];
                    names[j] = tempName;
                }
            }
        }
        //redisplay score
        firstScore.text = "" + highscore[0];
        secondScore.text = "" + highscore[1];
        thirdScore.text = "" + highscore[2];
        fourthScore.text = "" + highscore[3];
        fifthScore.text = "" + highscore[4];

        firstName.text = "" + names[0];
        secondName.text = "" + names[1];
        thirdName.text = "" + names[2];
        fourthName.text = "" + names[3];
        fifthName.text = "" + names[4];
        //saves score
        PlayerPrefs.SetInt("firstScore", highscore[0]);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("secondScore", highscore[1]);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("thirdScore", highscore[2]);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("fourthScore", highscore[3]);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("fifthScore", highscore[4]);
        PlayerPrefs.Save();

        PlayerPrefs.SetString("firstName", names[0]);
        PlayerPrefs.Save();
        PlayerPrefs.SetString("secondName", names[1]);
        PlayerPrefs.Save();
        PlayerPrefs.SetString("thirdName", names[2]);
        PlayerPrefs.Save();
        PlayerPrefs.SetString("fourthName", names[3]);
        PlayerPrefs.Save();
        PlayerPrefs.SetString("fifthName", names[4]);
        PlayerPrefs.Save();
    }

    // Start is called before the first frame update
    private void Start()
    {
        ArrangeScore();
    }

    private void Awake()
    {
        //only does this once - reset score
        if (firstCall)
        {
            PlayerPrefs.DeleteKey("firstScore");
            PlayerPrefs.DeleteKey("secondScore");
            PlayerPrefs.DeleteKey("thirdScore");
            PlayerPrefs.DeleteKey("fourthScore");
            PlayerPrefs.DeleteKey("fifthScore");
            PlayerPrefs.DeleteKey("firstName");
            PlayerPrefs.DeleteKey("secondName");
            PlayerPrefs.DeleteKey("thirdName");
            PlayerPrefs.DeleteKey("fourthName");
            PlayerPrefs.DeleteKey("fifthName");
            scoreboardscore = 0;
            name = "";
        } firstCall = false;
    }
}
