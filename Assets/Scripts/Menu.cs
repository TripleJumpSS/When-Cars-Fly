using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    Animator _animation;
    public float _transitionTime = 1.5f;
    public bool PlayTheEntryBite;
    public GameObject notcrossfade; public GameObject Cutscene; public GameObject MenuCanvas;

    private void Awake()
    {
        _animation = GetComponent<Animator>();
        if(PlayTheEntryBite)_animation.SetTrigger("AnimOnAwake");
        notcrossfade.SetActive(false);
    }
    public void PlayButton() 
    {
        notcrossfade.SetActive(true);
        //SceneManager.LoadScene("Tunnel Scene");
        StartCoroutine(LoadLevelWithTransition());
    }

    IEnumerator LoadLevelWithTransition() 
    {
        _animation.SetTrigger("Start");

        yield return new WaitForSeconds(_transitionTime);

        SceneManager.LoadScene("Tunnel Scene");
    }

    public void PlayCutscene() 
    {
        //Cutscene.SetActive(true);
        //SceneManager.LoadScene("Tunnel Scene");
        StartCoroutine(CutsceneTimer());
    }

    IEnumerator CutsceneTimer() 
    {
        
        Cutscene.SetActive(true);
        MenuCanvas.SetActive(false);
        yield return new WaitForSeconds(17);

        Cutscene.SetActive(false);
        MenuCanvas.SetActive(true);
    }
    public void CancelCutscene()
    {
        Cutscene.SetActive(false);
        MenuCanvas.SetActive(true);
        StopAllCoroutines();

    }

}
