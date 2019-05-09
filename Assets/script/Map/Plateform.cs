using UnityEngine;

public class Plateform : MonoBehaviour {

    public bool Arrivé;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (Arrivé)
            if (collision.gameObject.tag == "Player")
            {
                gameManager.StartTimer = false;
                gameManager.LockTimer = true; 
            }
    }
}
