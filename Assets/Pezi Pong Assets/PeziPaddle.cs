using UnityEngine;

public class PeziPaddle : MonoBehaviour
{

    public bool isPlayer1;
    public float speed;
    public Rigidbody2D rb;

    public Behaviour haloEffect;

    public AudioSource soundeffect;

    private float movement;

    void Start()
    {
        haloEffect = (Behaviour)GetComponent("Halo");
    }

    void Update(){

        if(isPlayer1){
            movement = Input.GetAxisRaw("Vertical");
        }
        else{
            movement = Input.GetAxisRaw("Vertical2");
        }

        rb.velocity = new Vector2(rb.velocity.x, movement * speed);

    }

    void OnCollisionEnter2D(Collision2D giddy)
    {
        if(giddy.collider.tag == "Ball"){
            haloEffect.enabled = true;
            soundeffect.Play();
        }
        
        
    }

    void OnCollisionExit2D(Collision2D giddy)
    {
        if(giddy.collider.tag == "Ball"){
            haloEffect.enabled = false;
        }
        
    }


}
