using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsDisabledButton : MonoBehaviour
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

    public void DisablePickupActivated()
    {
        if (innerLookTimer <= 0)
        {
            //fade panels
            gameController.GetComponent<GameController>().DisablePickupObjects();
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
