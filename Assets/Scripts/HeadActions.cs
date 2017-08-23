using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadActions : MonoBehaviour {

    [SerializeField]
    private ParticleSystem ps = null;

    RaycastHit hit;
    Ray MyRay;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.touchCount == 1)  
        {
            MyRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(MyRay, out hit, Mathf.Infinity))
            {
                if (hit.collider.name == "SphereHead")
                {
                    ParticleSystem newParticle = Instantiate(ps, hit.point, transform.rotation, hit.transform);            
                }
            }
        }
    }
}
