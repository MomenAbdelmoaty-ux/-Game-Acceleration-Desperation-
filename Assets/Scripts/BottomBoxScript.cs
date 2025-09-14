using UnityEngine;

public class BottomBoxScript : MonoBehaviour
{
    public PlayerScript player; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground")){
            player.isGrounded=true;
            player.pmode=PlayerScript.PlayerMode.Grounded;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground")){
            player.isGrounded=false;
        }
    }
    
}
