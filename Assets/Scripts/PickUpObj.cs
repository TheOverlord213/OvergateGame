using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PickUpObj : MonoBehaviour
{
    public float yPos;
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

        Vector3 p1 = transform.position+new Vector3(0, yPos, 0);


        if(Physics.Raycast(p1,transform.forward*distance,out hit))
        {
            Debug.DrawRay(p1, transform.TransformDirection(Vector3.forward)*distance, Color.yellow);

            if (hit.transform.gameObject.tag == "Collectable")
            {
                //Destroy(hit.transform.gameObject);
                hit.transform.gameObject.SetActive(false);
            }
            else if (hit.transform.gameObject.tag == "UI")
            {
                if (hit.transform.gameObject.name == "StartButton")
                    hit.transform.gameObject.GetComponent<StartButton>().StartGame();
                else if (hit.transform.gameObject.name == "EnableQuestButton")
                    hit.transform.gameObject.GetComponent<PickupsEnabledButton>().PickupActivated();
                else if (hit.transform.gameObject.name == "DisableQuestButton")
                    hit.transform.gameObject.GetComponent<PickupsDisabledButton>().DisablePickupActivated();
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
