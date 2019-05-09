using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectille : MonoBehaviour {

    public float speed;
    public float fireRate;

    public bool Explosif;

    public GameObject Explotion;
    private AudioSource audioSource;
    public AudioClip[] Shoot;
    public AudioClip[] OnCollider;
    private GameObject Explosion;
    int i;

    

    void Start () {
        i = Random.Range(0, OnCollider.Length);
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(Shoot[0]);
        
    }

	void Update () {
        
           
        if (speed != 0)
        {
            transform.position -= transform.right * (speed * Time.deltaTime);
        }
	}

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && speed != 0)
        {

            collision.gameObject.GetComponent<PlayerMovement>().respawn = true;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag != "Player")
        {          
            audioSource.PlayOneShot(OnCollider[i]);
        }
        speed = 0;

        if (Explosif)
        {
            Explosion = Instantiate(Explotion, transform.position, Quaternion.identity);
            Explosion.GetComponentInChildren<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(speed != 0)
            Destroy(gameObject);
    }
  
}
