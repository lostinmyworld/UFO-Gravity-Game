using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {
    private Rigidbody2D rb2d;
    public float GravityScale = 1.0f;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GravityScale = Mathf.Abs(GravityScale);
        bool gravity = Random.Range(-100, 100) > 0;
        if (gravity)
            rb2d.gravityScale = GravityScale;
        else
            rb2d.gravityScale = -GravityScale;
    }

    void Update()
    {
        if (transform.position.x < 18.8 && transform.position.x > -18) {
            rb2d.isKinematic = false;
        } else if (transform.position.x < -18.8) {
            rb2d.isKinematic = true;
        }
        if (transform.position.y < -11.3) {
            rb2d.gravityScale = -GravityScale;
        } else if (transform.position.y > 11.3) {
            rb2d.gravityScale = GravityScale;
        }
    }
}
