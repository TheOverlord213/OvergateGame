using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetUi : MonoBehaviour
{
    public GameObject buttonToReset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetUI()
    {
        buttonToReset.GetComponent<StartButton>().ResetTimer();
    }
}
