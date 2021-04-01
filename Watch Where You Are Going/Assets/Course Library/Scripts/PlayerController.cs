using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5.0f;
    private Rigidbody PlayerRB;
    public GameObject PowerUpIn;
    private GameObject focalPoint;
    public bool hasPowerUp;
    public float PowerUpForce = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("FocalPoint");
        PlayerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float ForwardInput = Input.GetAxis("Vertical");
        PlayerRB.AddForce(ForwardInput * Speed * focalPoint.transform.forward);
        PowerUpIn.transform.position = transform.position;
        if (transform.position.y < -10){
            Destroy(gameObject);
            SceneManager.LoadScene("EndLost");
        }
    }
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("PowerUp")){
            hasPowerUp = true;
            PowerUpIn.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(CountDown());
        }
    }
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp){
            Debug.Log("Collided With: " + collision.gameObject.name + "With Powerup Set To: " + hasPowerUp);
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRb.AddForce(awayPlayer * PowerUpForce, ForceMode.Impulse);
        }
    }
    IEnumerator CountDown(){
        yield return new WaitForSeconds(5);
        hasPowerUp = false;
        PowerUpIn.gameObject.SetActive(false);
    }
}
