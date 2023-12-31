using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class SharkManager : MonoBehaviour
{
    public float HowManySharks;
    public GameObject[] BackSharks;
    public GameObject[] SideSharks;
    public GameObject[] UISharkFaces;
    public float Attacked; public float MaxAttack;
    public GameObject GameManager;
    public GameObject StarterShark;
    public GameObject PreChaseText; public GameObject PostChaseText;
    public GameManager MusicManager;
    public GameObject target1; public GameObject target2; public GameObject target3;
    public GameObject dtarget1; public GameObject dtarget2; public GameObject dtarget3;
    void Start()
    {
        HowManySharks = 1;
        MaxAttack = 3;

        StartCoroutine(destroystartershark());
    }
    public IEnumerator destroystartershark()
    {yield return new WaitForSeconds(3f); Destroy(StarterShark);}

    // Update is called once per frame
    void Update()
    {
        if(Attacked >= MaxAttack) 
        {Attacked = 0; StartCoroutine(endchase());}
    }

    public IEnumerator beginchase()
    {

            PreChaseText.SetActive(true);

            yield return new WaitForSeconds(3.5f);

            PreChaseText.SetActive(false);

        BackSharks[0].SetActive(true); target1.SetActive(true);

        MaxAttack = 3;
        Attacked = 0;
        
        yield return new WaitForSeconds(1f);

        if(HowManySharks > 1)
        {BackSharks[1].SetActive(true); MaxAttack = 6; target2.SetActive(true);}
        //yield return new WaitForSeconds(0.1f);

        if(HowManySharks > 2)
        {SideSharks[0].SetActive(true); MaxAttack = 12; dtarget1.SetActive(true);}
        //yield return new WaitForSeconds(0.1f);

        if(HowManySharks > 3)
        {SideSharks[1].SetActive(true); MaxAttack = 18; dtarget2.SetActive(true);}
        //yield return new WaitForSeconds(0.1f);
        yield return new WaitForSeconds(0.5f);

        if(HowManySharks > 4)
        {BackSharks[2].SetActive(true); MaxAttack = 24; target3.SetActive(true);}
        //yield return new WaitForSeconds(0.1f);

        if(HowManySharks > 5)
        {SideSharks[2].SetActive(true); dtarget3.SetActive(true);}
        yield return new WaitForSeconds(0.1f);
    }
    public void didattack(){Attacked += 1;}

    public IEnumerator endchase()
    {
        GameManager.GetComponent<SharkProximity>().SurvivedTheChase(); 
        foreach (var shark in BackSharks)
        {shark.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("FightIsOver", false);}
        foreach (var shark in SideSharks)
        {shark.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("FightIsOver", false);}
        target1.SetActive(false);
        target2.SetActive(false);
        target3.SetActive(false);
        dtarget1.SetActive(false);
        dtarget2.SetActive(false);
        dtarget3.SetActive(false);
        

        yield return new WaitForSeconds(0.5f);
        foreach (var shark in BackSharks)
        {shark.SetActive(false);}
        foreach (var shark in SideSharks)
        {shark.SetActive(false);}

        HowManySharks += 1;

        if(HowManySharks == 2){UISharkFaces[0].SetActive(true);}
        if(HowManySharks == 3){UISharkFaces[1].SetActive(true);}
        if(HowManySharks == 4){UISharkFaces[2].SetActive(true);}
        if(HowManySharks == 5){UISharkFaces[3].SetActive(true);}
        if(HowManySharks == 6){UISharkFaces[4].SetActive(true);}

        yield return new WaitForSeconds(0.5f);

        if(HowManySharks < BackSharks.Length + SideSharks.Length)
        {
            PostChaseText.SetActive(true);

            yield return new WaitForSeconds(3.5f);

            PostChaseText.SetActive(false);
        }
        
    }
}
