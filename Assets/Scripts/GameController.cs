using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float buttonTimers;
    public List<GameObject> panels;
    public GameObject[] pickupObjs;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        pickupObjs = GameObject.FindGameObjectsWithTag("Collectable");

        foreach (GameObject x in panels)
        {
            x.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            x.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        if (Input.GetKey("y"))
            EnablePickupObjects();
        else if (Input.GetKey("n"))
            DisablePickupObjects();
    }

    public void PickupChoice()
    {
        foreach (GameObject x in panels)
        {
            x.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            x.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            x.gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    public void FadeOutAllPanels()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        foreach (GameObject panel in panels)
        {
            panel.GetComponent<Animator>().SetTrigger("FadeOut");
        }
        yield return new WaitForSeconds(3f);
        foreach (GameObject panel in panels)
        {
            panel.transform.gameObject.SetActive(false);
        }
        player.GetComponent<PlayerRailController>().MovementBegun();
    }

    public void FadeInAllPanels()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        foreach (GameObject panel in panels)
        {
            panel.transform.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(3f);
        foreach (GameObject panel in panels)
        {
            panel.GetComponent<Animator>().SetTrigger("FadeIn");
        }
    }

    public void EnablePickupObjects()
    {
        // enable quest objects
        foreach (GameObject i in pickupObjs)
        {
            //pickupObjs[i].SetActive(true);
            i.SetActive(true);
        }
        FadeOutAllPanels();
    }

    public void DisablePickupObjects()
    {
        // disable quest objects
        //for (int i = 0; i < pickupObjs.Length; i++)
        foreach (GameObject i in pickupObjs)
        {
            //pickupObjs[i].SetActive(false);
            i.SetActive(false);
        }
        FadeOutAllPanels();
    }

}
