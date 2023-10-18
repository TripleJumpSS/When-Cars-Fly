using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    Animator _animation;
    float _transitionTime = 1.5f;

    private void Awake()
    {
        _animation = GetComponent<Animator>();
    }
    public void PlayButton() 
    {
        StartCoroutine(LoadLevelWithTransition());
    }

    IEnumerator LoadLevelWithTransition() 
    {
        _animation.SetTrigger("Start");

        yield return new WaitForSeconds(_transitionTime);

        SceneManager.LoadScene("Tunnel Scene");
    }
}
