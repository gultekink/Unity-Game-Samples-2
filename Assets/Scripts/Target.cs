using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Vector3 = UnityEngine.Vector3;


public class Target : MonoBehaviour
{
    
    public bool gameOver;
    public ParticleSystem particle;
    public int ScoreValue;
    private GameManager1 gameManager1;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -3;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
        gameManager1 = GameObject.Find("SpawnManager").GetComponent<GameManager1>();
        float random = Random.Range(-10, 10);
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(AddForce(), ForceMode.Impulse);
        rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        particle.IsAlive(false);
        gameOver = false;

    }
    
    // Update is called once per frame
    void Update()
    {
      
    }

    

    void OnMouseDown()
    {
        GameOver();
        Destroy(gameObject);
        gameManager1.ScoreCounter(ScoreValue);
        Instantiate(particle, transform.position, transform.rotation);
        
    }

    private void GameOver()
    {
        if (gameObject.CompareTag("Bad"))
        {
            gameManager1.gameOverText.gameObject.SetActive(true);
            Destroy(gameObject);
            gameOver = true;
            gameManager1.StopAllCoroutines();
            gameManager1.button.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    Vector3 AddForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0);
    }
    
}
