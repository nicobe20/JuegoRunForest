using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    int hats;
    private float km;
    public static GameManager inst;
    public GameOver GameOver;
    public GameObject gameOverScreen;


//Cada vez que necesitemos un serialized field de texto USAR TextMeshProUGUI, es necesario importar TMPro...
    [SerializeField] private TextMeshProUGUI HatsText; //New Change, change legacy text for TMP.
    [SerializeField] private TextMeshProUGUI KmText; 
    [SerializeField] private PlayerMovement playerMovement;
    

    public void IncrementHats(){
        hats++;
        HatsText.text = "Hats: "+hats;

        playerMovement.speed += playerMovement.speedIncreasePerPoint;


    }

   public void UpdateDistance(float distance)
    {
        km += distance; 
        KmText.text = $"Meters: {km:0.00}"; //Encontre como hacer un counter bien cool, con floats!
    }

    private void Awake(){
        inst = this;
    }

    void Start()
    {
        
    }

   public void GameOverSequence()
    {
    // Activate the game over screen UI.
    GameOver.gameObject.SetActive(true);
    HatsText.enabled = false;
    KmText.enabled = false;
    GameOver.Setup(hats, km);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

