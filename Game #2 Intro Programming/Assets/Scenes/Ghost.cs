using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ghost : MonoBehaviour
{
    
    public string destination;
    //public AudioClip sfx;
    private AudioSource ghostAudio;
    // Start is called before the first frame update
    void Start()
    {
        ghostAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag =="Player")
        {
            GetComponentInChildren<SpriteRenderer>().enabled = true;
            //SceneManager.LoadScene(destination);
            //ghostAudio.PlayOneShot(sfx, .7f);
            ghostAudio.Play();
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        
        if(collision.tag =="Player"){
            
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        } 
    }
}
