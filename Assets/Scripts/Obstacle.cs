
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;
    void Start()
    {
        playerMovement = GameObject.FindAnyObjectByType<PlayerMovement>();
    }

    private void OnCollisionEnter( Collision collision){
        if (collision.gameObject.name == "Player"){
            playerMovement.Die();
        }
    }
    void Update()
    {
        
    }
}
