using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsEnabledButton : MonoBehaviour
{
    private float lookTimer;
    public float innerLookTimer;
    private GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        lookTimer = gameController.GetComponent<GameController>().buttonTimers;
        innerLookTimer = lookTimer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickupActivated()
    {
        if (innerLookTimer <= 0)
        {
            //fade panels
            gameController.GetComponent<GameController>().EnablePickupObjects();
            innerLookTimer = lookTimer;
        }
        else
        {
            innerLookTimer -= Time.deltaTime;
        }
    }


    public void ResetTimer()
    {
        innerLookTimer = lookTimer;
    }

}
