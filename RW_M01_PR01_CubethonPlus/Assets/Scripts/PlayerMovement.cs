using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 500f;
    public float sidewaysForce = 100f;
    public float jumpForce = 1000f;

    private bool left = false;
    private bool right = false;
    private bool jump = false;
    private bool canJump = true;

    void OnCollisionEnter(Collision collsionInfo)
    {
        if (collsionInfo.collider.tag == "Ground" || collsionInfo.collider.tag == "Wall")
        {
            canJump = true;
        }
    }

    void Update()
    {
        //Collect input for left right and jump
        if (Input.GetKey("d"))
        {
            left = true;

        } else
        {
            left = false;
        }

        if (Input.GetKey("a"))
        {
            right = true;

        } else
        {
            right = false;
        }

        if (Input.GetKeyDown("space") && canJump == true) {
            jump = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //constant movement forward
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);


        //Check for movement flags and add force accordingly
        if (left == true)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        }

        if (right == true)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        }

        if (jump == true)
        {
            rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.Impulse);
            jump = false;
            canJump = false;
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
