using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyScript2 : MonoBehaviour
{
    // Sets the health of the body of the zombie
    public int EnemyHealth = 10;
    // Creates a counter variable that increments every time the zombie dies
    public static int count;
    // Grabs the game object of the killcount so we can determine how many kills we are on
    public GameObject KillCount;

    // This function is for deducting the health points of the zombies head
    void DeductPoints(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Resets the count to 0
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // This if statement checks the body health and if it reaches 0 it kills the zombie
        if (EnemyHealth <= 0)
        {
            // Destroys the body game object
            Destroy(gameObject);
            // Increments the count by one every time a zombie dies
            count = count + 1;
        }

        // This grabs the kill count components and updates it when the count is updated
        KillCount.GetComponent<Text>().text = "Kill Count: " + count + "/10";
        // This determines that when the kill count reaches 10 which means you have completed the mission that it will run the scene manager that loads the victory scene
        if (count == 10)
        {
            SceneManager.LoadScene(12);
        }
    }
}
