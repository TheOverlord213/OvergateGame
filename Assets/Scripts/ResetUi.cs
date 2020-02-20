using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetUi : MonoBehaviour
{
    public GameObject buttonToReset;
    // Start is called before the first frame update

    public void ResetUI()
    {
        buttonToReset.GetComponent<StartButton>().ResetTimer();
    }
}
