using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase5 : MonoBehaviour
{
    // This grabs the position (x, y, z coordinates) data of the player
    public Transform player;
    // This grabs the position (x, y, z coordinates) data of the zombie
    public Transform head;
    // This grabs the game object of the zombie
    public GameObject TheEnemy;
    // This attack trigger variable is used to monitor when we walk into the attack radius around the player
    public int AttackTrigger;
    // This is used to set when the zombie is attacking and not attacking
    public int isAttacking;
    // This grabs the game object of the damage tint in the canvas
    public GameObject DamageFlash;
    // An array of game objects that are the waypoints for the the zombies patrolling
    public GameObject[] waypoints;
    // This variable identifies what the current waypoint is set to and goes to it
    int currentWP = 0;
    // This is the rotation speed of the zombie when walking around waypoints
    float rotSpeed = 1f;
    // This variable sets the speed of the zombie on it's patrol
    float speed = 1.5f;
    // This identifies how close to the waypoint the zombie needs to get before it moves on to the next waypoint
    float accuracyWP = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This grabs the vector 3 direction by getting the position of the player and minusing it by the zombies position
        Vector3 direction = player.position - this.transform.position;

        // This if statement checks to see if the distance between the players position and zombies position is less then 10
        if (Vector3.Distance(player.position, this.transform.position) < 8)
        {
            // Sets the y direction so that if the player walks up to the zombie they won't start tilting back
            direction.y = 0;
            // This uses a slerp for the rotation of the zombie to make it feel more human like and natural
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            // If statement is to see if the magnitude is greater then 1
            if (direction.magnitude > 1)
            {
                // This plays the walk animation for the zombie when it is chasing the player
                TheEnemy.GetComponent<Animation>().Play("Z_Walk");
                // Sets the speed of the zombie when it starts to chase the player this is increased from the other levels as we are testing the zombies speed
                this.transform.Translate(0, 0, 0.125f);
            }
        }
        // We use an else if statement here so that the zombie can go from patrolling to chasing and then back to patrolling if the player gets out of the agro range
        else if (waypoints.Length > 0)
        {
            // This plays the walk animation for the zombie when it is patrolling
            TheEnemy.GetComponent<Animation>().Play("Z_Walk");
            // Checks the distance between the current waypoint position and how close we require to get before we can change waypoint for the patrol
            if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP)
            {
                // Increments to a new waypoint every time the zombie reaches its current waypoint
                currentWP++;
                // This if statement just makes sure that we don't go over the quantity of waypoints we have and sets it back to 0
                if (currentWP >= waypoints.Length)
                {
                    currentWP = 0;
                }
            }

            // This sets the rotation every time it walks round a waypoint
            direction = waypoints[currentWP].transform.position - transform.position;
            // We use a slerp for the zombies rotation around the waypoint to make it look more natural and we also set the speed that we want to rotate around the corner
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
            // This sets the speed of the zombie while it is patrolling
            this.transform.Translate(0, 0, Time.deltaTime * speed);
        }

        // Checks to see if the zombie walks into the players radius
        if (AttackTrigger == 1)
        {
            // Checks to see if the isAttacking variable is 0 or 1 if 0 then starts to attack the player
            if (isAttacking == 0)
            {
                // We start the coroutine and call the enemy damage enumerator
                StartCoroutine(EnemyDamage());
            }
            // Grabs the attacking animation and plays it
            TheEnemy.GetComponent<Animation>().Play("Z_Attack");
        }
    }
    // We use this function to apply gravity to the zombie
    public void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(Physics.gravity, ForceMode.Acceleration);
    }

    // Sets the attack trigger to 1 (which will in turn start the attkacing) every time the zombie walks into the players trigger radius 
    void OnTriggerEnter()
    {
        AttackTrigger = 1;
    }

    // Sets the attack trigger to 0 (which means the zombie will stop attacking) every time the zombies leaves the players trigger radius
    void OnTriggerExit()
    {
        AttackTrigger = 0;
    }

    // A function for when the zombie is destroyed it resets the damage flash to false to stop it from bugging out
    void OnDestroy()
    {
        if (DamageFlash != null)
        {
            DamageFlash.SetActive(false);
        }
    }

    // We create a Enumerator for the damage the enemy does to us
    IEnumerator EnemyDamage()
    {
        // Sets the isAttacking to 1 which will start the coroutine
        isAttacking = 1;
        // Waits a designated amount of time before triggering the damage tint from the canvas
        yield return new WaitForSeconds(0.02f);
        DamageFlash.SetActive(true);
        // This controls how much damage the zombie does to the player and this number is larger than on the other levels because we are testing the zombies damage against the player
        GlobalHealth5.PlayerHealth -= 34;
        // Waits a designated amount of time before setting the damage tint back to false
        yield return new WaitForSeconds(0.02f);
        DamageFlash.SetActive(false);
        // Waits 1 more second and sets the isAttacking variable back to 0
        yield return new WaitForSeconds(1);
        isAttacking = 0;
    }
}
