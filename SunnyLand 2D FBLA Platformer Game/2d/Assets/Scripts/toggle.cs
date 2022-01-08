using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class toggle : MonoBehaviour
{
    public TextMeshProUGUI switchText;
    public void changeBool()
    {
        bool toggleSwitch = gameObject.GetComponent<Toggle>().isOn; //get value of toggle
        if (toggleSwitch) //change toggle display
        {
            switchText.color = new Color32(255, 0, 0, 255);
            switchText.text = "Off";
            PermanentUI.perm.hardBool = false;
        }
        else
        {
            switchText.color = new Color32(0, 255, 0, 255);
            switchText.text = "On";
            PermanentUI.perm.hardBool = true;
        }
    }
}
