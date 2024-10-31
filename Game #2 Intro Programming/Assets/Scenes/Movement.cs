using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed;
    private SpriteRenderer sr;

    //sprite variables
    public Sprite upSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite frontSprite;
    public bool hasKey;
    public Vector3 initialPos;
    //public rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;

        //change the variable information according to player input
         if (Input.GetKey(KeyCode.D))
        {
            newPos.x += speed*Time.deltaTime;
            //change the sprite to right sprite
            sr.sprite = rightSprite;
        }

        if (Input.GetKey(KeyCode.A))
        {
            newPos.x -= speed*Time.deltaTime;
            //change the sprite to left sprite
            sr.sprite = leftSprite;
        }

        if (Input.GetKey(KeyCode.W))
        {
            newPos.y += speed*Time.deltaTime;
            //change the sprite to up sprite
            sr.sprite = upSprite;
        }

        if (Input.GetKey(KeyCode.S))
        {
            newPos.y -= speed*Time.deltaTime;
            //change the sprite to front sprite
            sr.sprite = frontSprite;
        }

        transform.position = newPos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Key")
        {
            Destroy(collision.gameObject); //Destroys Key
            hasKey=true;
        }
        
        if(collision.tag =="Ghost")
        {
            StartCoroutine(ResetPosition());
        }
    }

    IEnumerator ResetPosition(){
   
        yield return new WaitForSecondsRealtime(.5f);
        transform.position = initialPos;
    }
}