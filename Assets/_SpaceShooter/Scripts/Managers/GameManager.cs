using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool shouldQuitGame;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; // confine the cursor to the game screen 
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        shouldQuitGame = Input.GetKeyUp(KeyCode.Escape);
        if (shouldQuitGame)
        {
            QuitGame();
        }
    }

    private void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;    
#else
//TODO: handle webGl quit
Application.Quit(); 
#endif
        
    }
}
