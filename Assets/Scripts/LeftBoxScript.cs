using UnityEngine;

public class LeftBoxScript : MonoBehaviour
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
            if(player.LeftRight.ReadValue<float>()<0&&player.GetComponent<Rigidbody2D>().linearVelocityY<=0){
                player.GetComponent<Rigidbody2D>().linearVelocityY/=2;
                player.isWalled=-1;
            }else{
                player.isWalled=0;
            }
            
        }
        // Debug.Log(player.isWalled);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground")){
            player.isWalled=0;
            //player.GetComponent<Rigidbody2D>().gravityScale=20;
        }
        // Debug.Log(player.isWalled);
    }
}
