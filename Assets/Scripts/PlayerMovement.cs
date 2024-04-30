using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    public float speed = 5;
    [SerializeField] Rigidbody rb;
    

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 1f; 
    public float km;
    public float speedIncreasePerPoint = 0.08f;
    [SerializeField] bool isGrounded;
    [SerializeField] float jumpHeight = 40f; //cambiar esto para cambiar el multiplicado de salto, entre mayor esto mayor saltara el personaje.
    [SerializeField] LayerMask terrainMask;
    private Vector3 lastPosition;


    void start(){
        lastPosition = transform.position;
    }


    private void FixedUpdate(){
        if(!alive) return;
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        IsOnGround(); //not working!

        //Calcular la distancia para añadir al contador de km!

        float distanceMoved = Vector3.Distance(transform.position, lastPosition);
        GameManager.inst.UpdateDistance(distanceMoved);

        lastPosition = transform.position;
        
        
    }

    private void Update()  //privada!
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)){
            jump();

        }

        if(transform.position.y < -5){
            Die();
        }
    }


//cambiado
    public void Die()
    {
        alive = false;
        GameManager.inst.GameOverSequence();
    }

    
//Change to GameManager  
/*
 void Restart(){
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
*/

    void jump(){
        float heigth = GetComponent<Collider>().bounds.size.y;
        bool isOnFloor = Physics.Raycast (transform.position, Vector3.down, (heigth / 2) + 0.1f, terrainMask);
        rb.AddForce(Vector3.up * jumpHeight);
    }

//no funciona arreglar

//revisar si el personaje esta en la tierra
    void IsOnGround(){
        Vector3 position = transform.position;
        position.y += 0.1f; 
        isGrounded = Physics.Raycast(position, Vector3.down, 0.2f, terrainMask);
    }

}

/*
NOTES:
    -hacer un colider con las esquinas de la carretera para que forest no se pueda caer 
    -Modelar personajes y añadir texturas a cosas.
    -Continuar con desarollo arreglar bugs y errores.
*/