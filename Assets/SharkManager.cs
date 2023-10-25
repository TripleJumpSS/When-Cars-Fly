using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class SharkManager : MonoBehaviour
{
    public float HowManySharks;
    public GameObject[] BackSharks;
    public GameObject[] SideSharks;
    public float Attacked;
    public GameObject GameManager;
    void Start()
    {
        HowManySharks = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Attacked > 2) 
        {endchase();}
    }

    public IEnumerator beginchase()
    {
        Attacked = 0;
        BackSharks[1].SetActive(true);
        yield return new WaitForSeconds(0.1f);

        if(HowManySharks > 1)
        {BackSharks[2].SetActive(true);}
        yield return new WaitForSeconds(0.1f);

        if(HowManySharks > 2)
        {SideSharks[1].SetActive(true);}
        yield return new WaitForSeconds(0.1f);

        if(HowManySharks > 3)
        {SideSharks[2].SetActive(true);}
        yield return new WaitForSeconds(0.1f);

        if(HowManySharks > 4)
        {SideSharks[3].SetActive(true);}
        yield return new WaitForSeconds(0.1f);

        if(HowManySharks > 5)
        {SideSharks[3].SetActive(true);}
        yield return new WaitForSeconds(0.1f);
    }
    public void didattack(){Attacked += 1;}

    public IEnumerator endchase()
    {
        GameManager.GetComponent<SharkProximity>().SurvivedTheChase(); 
        foreach (var shark in BackSharks)
        {shark.GetComponent<Animator>().SetBool("FightIsOver", false);}
        foreach (var shark in SideSharks)
        {shark.GetComponent<Animator>().SetBool("FightIsOver", false);}
        

        yield return new WaitForSeconds(0.2f);
        foreach (var shark in BackSharks)
        {shark.SetActive(false);}
        foreach (var shark in SideSharks)
        {shark.SetActive(false);}

        HowManySharks += 1;
        
    }
}
