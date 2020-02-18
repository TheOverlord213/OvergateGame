using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PickUpObj : MonoBehaviour
{
    public float sphereRadius;
    public float distance;


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


        if(Physics.Raycast(p1,transform.forward*distance,out hit))
        {
            Debug.DrawRay(p1, transform.TransformDirection(Vector3.forward)*distance, Color.yellow);

            if (hit.transform.gameObject.tag == "Collectable")
            {
                Destroy(hit.transform.gameObject);
            }
            else if (hit.transform.gameObject.tag == "UI")
            {
                hit.transform.gameObject.GetComponent<StartButton>().StartGame();
            }
            else if (hit.transform.gameObject.tag == "ResetUI")
            {
                hit.transform.gameObject.GetComponent<ResetUi>().ResetUI();
            }

        }

    }




    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Vector3 added = transform.forward * distance;
        Gizmos.DrawWireSphere(transform.position+added, sphereRadius);
    }
}
