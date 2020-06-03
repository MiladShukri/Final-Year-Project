using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
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
            // Grabs the gun sound audio source component
            AudioSource gunsound = GetComponent<AudioSource>();
            // Plays the gun sound audio
            gunsound.Play();
            // Grabs the animation for the gun firing and recoiling.
            GetComponent<Animation>().Play("GunFire");
        }
    }
}
