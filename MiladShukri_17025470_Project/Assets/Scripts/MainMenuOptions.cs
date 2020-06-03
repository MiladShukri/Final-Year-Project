using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOptions : MonoBehaviour
{
    // Creates a string that we can put the survey url in
    public string Url;

    // This function is connected to a button and uses scenemanager to load the scene for level 1
    public void PlayLevel_1()
    {
        SceneManager.LoadScene(1);
    }

    // This function is connected to a button and uses scenemanager to load the scene for level 2
    public void PlayLevel_2()
    {
        SceneManager.LoadScene(2);
    }

    // This function is connected to a button and uses scenemanager to load the scene for level 3
    public void PlayLevel_3()
    {
        SceneManager.LoadScene(3);
    }

    // This function is connected to a button and uses scenemanager to load the scene for level 4
    public void PlayLevel_4()
    {
        SceneManager.LoadScene(4);
    }

    // This function is connected to a button and uses scenemanager to load the scene for level 5
    public void PlayLevel_5()
    {
        SceneManager.LoadScene(5);
    }

    // This function is connected to a button and uses application to open the url to an external link
    public void Open()
    {
        Application.OpenURL(Url);
    }

    // This function is connected to a button and uses application to quit the simulation.
    public void Quit()
    {
        Application.Quit();
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
