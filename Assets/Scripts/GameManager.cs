using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PauseScreen;
    [SerializeField] GameObject GameOverScreen;
    public TMP_Text Points; public TMP_Text DistanceUIText; 
    void Start()
    {
        PauseScreen.SetActive(false);
    }

    public void Pause()
    {Time.timeScale = 0f; PauseScreen.SetActive(true);}

    public void UnPause()
    {Time.timeScale = 1f; PauseScreen.SetActive(false);}
    public void Home()
    {Time.timeScale = 1f; SceneManager.LoadScene("Menu Scene");}
    public void GameOver()
    {Time.timeScale = 0f; GameOverScreen.SetActive(true); Points.text = DistanceUIText.text;}
    public void Retry()
    {Time.timeScale = 1f; SceneManager.LoadScene("Tunnel Scene");}
}
