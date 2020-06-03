using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandGunDamage : MonoBehaviour
{
    // This variable determines how much damage the gun does
    public int DamageAmount = 5;
    // This variable determines how far the target distance will be
    public float TargetDistance;
    // This variable determines the range at which the gun can do damage
    public float AllowedRange = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This takes the input of fire1 when the button is pressed, fire1 is keybound to left click
        if (Input.GetButtonDown("Fire1"))
        {
            // This nested if statement uses physics and raycast to create a gun shot towards the target 
            RaycastHit Shot;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
            {
                // This gets the shot distance and sets the target distance to this float
                TargetDistance = Shot.distance;

                // This determines which shots are in range and which aren't
                if (TargetDistance < AllowedRange)
                {
                    // Calls the deductpoints from the enemy scripts
                    Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        // This function grabs the input of cancel so when the escape button is pressed it loads back to the main menu
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
