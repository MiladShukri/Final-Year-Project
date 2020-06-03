using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalHealth2 : MonoBehaviour
{
    // This variable sets the players health
    public static int PlayerHealth;
    // This variable is used for taking damage off zombies
    public int InternalHealth;
    // This access the game object that displays the health we have
    public GameObject HealthDisplay;

    // Start is called before the first frame update
    void Start()
    {
        // Resets the health every time the mission starts
        PlayerHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        // Sets internal health to the player health
        InternalHealth = PlayerHealth;
        // Grabs the health display and updates it when damage is taken
        HealthDisplay.GetComponent<Text> ().text = "Health: " + PlayerHealth;
        // If the players health goes to zero then we load the game over scene using scene manager
        if (PlayerHealth <= 0)
        {
            SceneManager.LoadScene (7);
        }
    }
}
