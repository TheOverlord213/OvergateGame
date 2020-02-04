using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistantCheck : MonoBehaviour
{
    GameObject player;
    public float triggerDistance;
    public Material normal;
    public Material hightLight;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerDistance();
    }


    void CheckPlayerDistance()
    {
        if(Vector3.Distance(player.transform.position,transform.position)<triggerDistance)
        {
            if (GetComponent<Renderer>().material != hightLight)
            {
                GetComponent<Renderer>().material = hightLight;
            }
        }
        else
        {
            if (GetComponent<Renderer>().material!=normal)
            {
                GetComponent<Renderer>().material = normal;
            }
           
        }

    }
}
