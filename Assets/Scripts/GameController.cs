using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float buttonTimers;
    public List<GameObject> panels;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
