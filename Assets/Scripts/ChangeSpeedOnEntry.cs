using UnityEngine;

public class ChangeSpeedOnEntry : MonoBehaviour
{
    [Header("(A Minus Number will Speed Down)")]
    [SerializeField] float ChangeSpeedByHowMuch;
    GameObject TunnelManager;  
    GameObject Player;
    GameObject GameManager;
    bool HaveIBeenUsedYet; //Stops the player from triggering the same object multiple times.
    //public bool DestroyOnContact;
    public bool invincibilitystar; 
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
            if(Player.GetComponent<MouseToMove>().iFrames == true && ChangeSpeedByHowMuch <= 0){return;}


            HaveIBeenUsedYet = true;
            
            if (ChangeSpeedByHowMuch > 0) //(DestroyOnContact == true)
            {
                //_renderer.enabled= false;
                Player.SendMessage("BOOST");
            }
            else
                Player.SendMessage("HIT");
            
            TunnelManager.GetComponent<TunnelManager>().ChangeSpeed(ChangeSpeedByHowMuch);
            
            if(GameManager.GetComponent<SharkProximity>().Pinch && ChangeSpeedByHowMuch > 0)
            {TunnelManager.GetComponent<TunnelManager>().ChangeSpeed(ChangeSpeedByHowMuch / 1.5f);}

            if (_hitSoundEffect != null)
                {float randomPitch = Random.Range(0.75f,1.25f);
                _hitSoundEffect.pitch = randomPitch;
                _hitSoundEffect.Play();}
            else
                Debug.LogError("Need to add audio source to object");


            if(invincibilitystar)
            {
                Player.SendMessage("invincibilitystar");
            }
        }
    }
}
