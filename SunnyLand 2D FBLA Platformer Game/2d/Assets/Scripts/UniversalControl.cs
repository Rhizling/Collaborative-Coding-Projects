using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalControl : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) //escape key
        {
            Debug.Log("QUIT");
            Application.Quit();
        }
    }
}
