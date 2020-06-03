using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeadScript4 : MonoBehaviour
{
    // Sets the health of the head of the zombie
    public int HeadHealth = 5;
    // Grabs the game object of the killcount so we can determine how many kills we are on
    public GameObject KillCount;
    // Grabs the game object of the body
    public GameObject body;

    // This function is for deducting the health points of the zombies head
    void DeductPoints(int DamageAmount)
    {
        HeadHealth -= DamageAmount;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // This if statement checks the head health and if it reaches 0 it kills the zombie
        if (HeadHealth <= 0)
        {
            // Destroys the head game object
            Destroy(gameObject);
            // Destroys the body of the zombie
            Destroy(body);
            // Grabs the count from the enemy script and increments to that when the zombie is killed
            EnemyScript4.count = EnemyScript4.count + 1;
        }

        // This grabs the kill count components and updates it when the count is updated
        KillCount.GetComponent<Text>().text = "Kill Count: " + EnemyScript4.count + "/10";
        // This determines that when the kill count reaches 10 which means you have completed the mission that it will run the scene manager that loads the victory scene
        if (EnemyScript4.count == 10)
        {
            SceneManager.LoadScene(14);
        }
    }
}
