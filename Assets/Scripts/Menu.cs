using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    Animator _animation;
    public float _transitionTime = 1.5f;
    public bool PlayTheEntryBite;

    private void Awake()
    {
        _animation = GetComponent<Animator>();
        if(PlayTheEntryBite)_animation.SetTrigger("AnimOnAwake");
    }
    public void PlayButton() 
    {
        StartCoroutine(LoadLevelWithTransition());
        SceneManager.LoadScene("Tunnel Scene");
    }

    IEnumerator LoadLevelWithTransition() 
    {
        _animation.SetTrigger("Start");

        yield return new WaitForSeconds(_transitionTime);

        SceneManager.LoadScene("Tunnel Scene");
    }
}
