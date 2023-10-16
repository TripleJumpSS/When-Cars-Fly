using UnityEngine;

public class ChangeSpeedOnEntry : MonoBehaviour
{
    [Header("(A Minus Number will Speed Down)")]
    [SerializeField] float ChangeSpeedByHowMuch;
    GameObject TunnelManager;  
    GameObject Player;
    GameObject GameManager;
    bool HaveIBeenUsedYet; //Stops the player from triggering the same object multiple times.
    public bool DestroyOnContact;
    AudioSource _hitSoundEffect;
    Renderer _renderer;
    
    void Awake()
    {   
        HaveIBeenUsedYet = false;
        TunnelManager = GameObject.Find("TunnelManager"); 
        GameManager = GameObject.Find("Game Manager"); 
        Player = GameObject.Find("Player");
        _hitSoundEffect = GetComponent<AudioSource>();
        _renderer = GetComponent<Renderer>();

        bool ChasingInProgress = GameManager.GetComponent<SharkProximity>().Chased;
        if (ChasingInProgress == true)
                Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && HaveIBeenUsedYet == false)
        {
            HaveIBeenUsedYet = true;
            TunnelManager.GetComponent<TunnelManager>().ChangeSpeed(ChangeSpeedByHowMuch);

            if (_hitSoundEffect != null)
                _hitSoundEffect.Play();
            else
                Debug.LogError("Need to add audio source to object");

            if (DestroyOnContact == true)
            {
                _renderer.enabled= false;
                Player.SendMessage("BOOST");
            }
            else
                Player.SendMessage("HIT");
        }
    }
}
