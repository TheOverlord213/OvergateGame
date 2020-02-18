using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObj : MonoBehaviour
{
    public float sphereRadius;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastForward();
    }

    void RaycastForward()
    {
        RaycastHit hit;

        Vector3 p1 = transform.position;

        // Cast a sphere wrapping character controller 10 meters forward
        // to see if it is about to hit anything.
        if (Physics.SphereCast(p1, sphereRadius, transform.forward, out hit, 30))
        {
            if(hit.transform.gameObject.tag =="Collectable")
            {
                Destroy(hit.transform.gameObject);
            }
           
        }

    }


    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Vector3 added = transform.forward * 30;
        Gizmos.DrawWireSphere(transform.position+added, sphereRadius);
    }
}
