using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public InputAction LeftRight;
    public InputAction Jump;
    public Rigidbody2D rb;
    public float collisionVelocity;
    public float jumpForce;
    public float accelerationCoefficient;
    public bool isGrounded = false;
    public int isWalled = 0;

    public enum PlayerMode
    {
        Airborne,
        Grounded,
        Sliding,
        WallRunning
    }
    public PlayerMode pmode;
    public float wallRunningThreshold=70;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnEnable()
    {
        pmode = PlayerMode.Airborne;
        LeftRight.Enable();
        Jump.Enable();
    }
    void OnDisable()
    {
        LeftRight.Disable();
        Jump.Disable();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isWalled == 0 && isGrounded == false)
        {
            pmode = PlayerMode.Airborne;
        }


        if (isWalled != 0)
        {
            // if(collisionVelocity>0){
            //     rb.linearVelocityY=collisionVelocity;
            //     collisionVelocity=0;
            // }


            if (rb.linearVelocityY > wallRunningThreshold)
            {
                pmode = PlayerMode.WallRunning;
            }
            else
            {
                pmode = PlayerMode.Sliding;
            }

        }

        Debug.Log(pmode);


        if (isWalled == 0)
        {
            rb.AddForce(new Vector2(LeftRight.ReadValue<float>() * accelerationCoefficient, 0), ForceMode2D.Force);
            
        }
        else
        {
            if (pmode == PlayerMode.WallRunning)
            {
                // rb.AddForce(new Vector2(0, Mathf.Abs(LeftRight.ReadValue<float>() * accelerationCoefficient)), ForceMode2D.Force);
            }
        }

        if (isGrounded)
        {
            rb.AddForce(new Vector2(0, Jump.ReadValue<float>() * jumpForce), ForceMode2D.Impulse);
        }
        else if (isWalled != 0)
        {
            rb.AddForce(new Vector2(Jump.ReadValue<float>() * accelerationCoefficient * isWalled * -1, Jump.ReadValue<float>() * jumpForce), ForceMode2D.Impulse);
        }
        // prepreviousVelocity=previousVelocity;
        // previousVelocity=rb.linearVelocity.magnitude;


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            collisionVelocity = Mathf.Abs(collision.relativeVelocity.x);
        }
    }
    // void OnCollisionExit2D(Collision2D collision)
    // {
    //     if(collision.collider.CompareTag("Ground")){
    //         isGrounded=false;
    //     }
    // }


}
