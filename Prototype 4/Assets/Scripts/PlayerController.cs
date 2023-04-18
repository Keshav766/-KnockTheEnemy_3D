using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody playerRb;
    GameObject focalPoint;
    public GameObject powerUpDisplay;

    public float playerSpeed = 5.0f;
    public bool haspowerUp = false;
    public float knockbackStrength = 10.0f;
    public int powerUpTime = 10;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }


    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        
        playerRb.AddForce(focalPoint.transform.forward * playerSpeed * verticalInput * Time.deltaTime);
        powerUpDisplay.transform.position = transform.position;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            haspowerUp = true;
            StartCoroutine(PowerUpCountDownRoutine());
            powerUpDisplay.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(powerUpTime);
        haspowerUp = false;
        powerUpDisplay.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && haspowerUp)
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 moveAwayDirection = other.transform.position - transform.position;
            enemyRb.AddForce(moveAwayDirection * knockbackStrength, ForceMode.Impulse);

            Debug.Log("player collided with " + other.gameObject.name + " while power up was " + haspowerUp);
        }
    }
}
