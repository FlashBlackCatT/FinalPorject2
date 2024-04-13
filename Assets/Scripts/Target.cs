using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 14;
    private float maxSpeed = 17;
    private float targetTorque = 10;
    private float Xpos = 4.1f;
    private float Ypos = -6;
    [SerializeField] private int pointsValue;
    [SerializeField] private ParticleSystem _explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomSpeed(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position =RandomSpawnPos();
    }

    Vector3 RandomSpeed()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-targetTorque, targetTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-Xpos, Xpos), Ypos);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive == true)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointsValue);
            Instantiate(_explosionParticle, transform.position, _explosionParticle.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
