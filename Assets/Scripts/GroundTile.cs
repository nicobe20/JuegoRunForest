using System;
using Unity.VisualScripting;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    
    GroundSpawner groundSpawner;
    [SerializeField] GameObject Carro;
    [SerializeField] GameObject Admiradora;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject Valla;

    //NO TOCAR 
    [SerializeField] float probTypical = 0.20f;
    [SerializeField] float probPeople = 0.1f;
    [SerializeField] float probCarro = 0.1f;


    void Start()
    {
        groundSpawner = FindAnyObjectByType<GroundSpawner>();
      
    }

    private void OnTriggerExit(){
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }
 

    public void SpawnObstacle()
{
    //NO TOCAR PORFAVOR!
    GameObject quienAparece = obstaclePrefab;
    float selectrandom = UnityEngine.Random.Range(0f, 1f);

    if(selectrandom<= probTypical+ probPeople+ probCarro){
        quienAparece = Valla;
    }
    if(selectrandom <= probTypical + probCarro){
        quienAparece = Carro;
    }
    else if(selectrandom <= probPeople ){
        quienAparece = Admiradora;
    }


    int obstacleSpawnIndex = UnityEngine.Random.Range(2, 5);
    Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
    Instantiate(quienAparece, spawnPoint.position, Quaternion.identity, transform);
}


    public void SpawnCoins(){
        int coinsToSpawn = 1;

        for (int i = 0; i < coinsToSpawn; i++)
        {
           GameObject temp = Instantiate(coinPrefab, transform);
           temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider){
        Vector3 point = new Vector3(
            UnityEngine.Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            UnityEngine.Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            UnityEngine.Random.Range(collider.bounds.min.z, collider.bounds.max.z)

        );
        //this should never be called, because we only take values from the collider.
        if (point != collider.ClosestPoint(point)){
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;

        return point;
    }
}
