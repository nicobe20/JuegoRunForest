using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Coin : MonoBehaviour
{


    [SerializeField] float turnSpeed = 90f;

    private void OnTriggerEnter (Collider other){

        if (other.gameObject.GetComponent<Obstacle>() != null){
            Destroy(gameObject);
            return;
        }

        if(other.gameObject.name != "Player"){
            return;
        }

        GameManager.inst.IncrementHats();

        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
