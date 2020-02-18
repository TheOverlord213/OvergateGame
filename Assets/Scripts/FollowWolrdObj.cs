using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWolrdObj : MonoBehaviour
{
    public GameObject worldObj;
    public Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = mainCam.WorldToScreenPoint(worldObj.transform.position);
    }
}
