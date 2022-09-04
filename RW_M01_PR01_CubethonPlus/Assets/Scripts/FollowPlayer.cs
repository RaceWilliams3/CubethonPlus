using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset;
    public float wallTilt;
    private Transform playerPosition;
    private PlayerCollision collision;

    private Vector3 targetRotation;
    private Vector3 defaultRotation = new Vector3(0f, 0f, 0f);

    private Vector3 rotationFromWall;

    private float tiltPortion;
    private float tiltTime = 0.2f;
    private float elapsedTime = 0f;


    // Update is called once per frame
    void Update()
    {
        //Collect new info on player transform and collision detection for wall running effect
        playerPosition = player.GetComponent<Transform>();
        collision = player.GetComponent<PlayerCollision>();

        //Update position based on player position and offset
        transform.position = playerPosition.position + offset;


    }

    void FixedUpdate()
    {

        collision = player.GetComponent<PlayerCollision>();

        

        if (collision.collisionDirection != 0)
        {
            targetRotation = new Vector3(0f, 0f, collision.collisionDirection * wallTilt);
            if (elapsedTime > tiltTime)
            {
                elapsedTime = tiltTime;
            }
        }
        else
        {
            if (elapsedTime == tiltTime)
            {
                elapsedTime = 0;
            }
            targetRotation = new Vector3(0f, 0f, 0f);
        }
        if (elapsedTime > tiltTime)
        {
            elapsedTime = 0;
        }
        else
        {
            elapsedTime += Time.deltaTime;
        }

        tiltPortion = elapsedTime / tiltTime;
        transform.localEulerAngles = Vector3.Lerp(defaultRotation, targetRotation, tiltPortion);

    }
}
