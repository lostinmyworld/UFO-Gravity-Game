using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    
    public float speed;
    public float gravityScale = 1;

    public GameObject playerExplosion;

    private GameController gc;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gc = GameObject.FindObjectOfType(typeof(GameController)) as GameController;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(speed * movement);
    }

    void Update()
    {
        // Change gravity on SPACE
        //if (Input.touchCount > 0){
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb2d.gravityScale = -rb2d.gravityScale;
        }
    }

    // PICKUPs & LASERs are triggered with our UFO
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            gc.AddScore(1);
        } else if (other.gameObject.CompareTag("Laser")) {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            gameObject.SetActive(false);
            gc.GameOver();
        }
    }

    // ENEMY SHIPS collide with our UFO
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Enemy")) {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            gameObject.SetActive(false);
            gc.GameOver();
        }
    }
}
