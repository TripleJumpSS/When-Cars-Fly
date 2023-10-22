using UnityEngine;

public class GameOverOnHit : MonoBehaviour
{
    GameManager _gameManager;
    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _gameManager.GameOver();
        }
    }
}
