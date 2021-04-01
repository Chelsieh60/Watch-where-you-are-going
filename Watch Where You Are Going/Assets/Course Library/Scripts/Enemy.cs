using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public GameObject Player;
    private Rigidbody EnemyRb;
    public float Y = -50;
    
    // Start is called before the first frame update
    void Start()
    {
        EnemyRb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 lookDirection = ((Player.transform.position - transform.position).normalized);
        EnemyRb.AddForce(lookDirection * Speed);
        if (transform.position.y < Y){
            Destroy(gameObject);
        }
        
    }
}
