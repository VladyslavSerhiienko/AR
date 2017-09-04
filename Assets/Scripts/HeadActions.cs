using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that makes some blood effect from a character's head
public class HeadActions : MonoBehaviour {

    [SerializeField]
    private ParticleSystem ps = null; // Representation of Blood Effect

    private RaycastHit hit; 
    private Ray MyRay; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.touchCount == 1)  
        {
            MyRay = Camera.main.ScreenPointToRay(Input.mousePosition); // Launch ray from touch on the screen
            if (Physics.Raycast(MyRay, out hit, Mathf.Infinity)) // If a collision is detected
            {
                if (hit.collider.name == "SphereHead") // And this collision with collider that named "SphereHead"
                {
                    ParticleSystem newParticle = Instantiate(ps, hit.point, transform.rotation, hit.transform); // Start bleeding animation
                }
            }
        }
    }
}
