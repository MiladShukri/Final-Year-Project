using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryOption1 : MonoBehaviour
{
    // This function is connected to a button and uses scenemanager to load the scene for the main menu
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    // This function is connected to a button and uses scenemanager to load the scene for the level you were just on, restarting it
    public void RestartLevelButton()
    {
        SceneManager.LoadScene(1);
    }
    // This function is connected to a button and uses scenemanager to load the scene for the next level
    public void NextLevelButton()
    {
        SceneManager.LoadScene(2);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Unlocks and shows the cursor again this is because it gets locked and turned invisible in the levels
        Cursor.visible = true;
        Screen.lockCursor = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
