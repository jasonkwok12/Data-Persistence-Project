using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public Text InputName;
    public Text ShowBest;

    public void NewNameSelected(string inputName)
    {
        // add code here to handle when a color is selected
        Manager.Instance.InputName = inputName;
    }



    private void Start()
    {
        ShowBest.text = "Best Score : " + Manager.Instance.BestName +" : "+ Manager.Instance.BestScore;
    }

    public void StartNew()
    {
        NewNameSelected(InputName.text);

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

   


}
