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
    private float tiltPortion;
    private float tiltTime = 0.05f;
    private float elapsedTime = 0f;




    // Update is called once per frame
    void Update()
    {
        //Collect new info on player transform and collision detection for wall running effect
        playerPosition = player.GetComponent<Transform>();
        collision = player.GetComponent<PlayerCollision>();

        //Update position based on player position and offset
        transform.position =  playerPosition.position + offset;

        
    }

    void FixedUpdate()
    {
        
        collision = player.GetComponent<PlayerCollision>();

        if (collision.collisionDirection != 0)
        {
            Debug.Log(elapsedTime);
            elapsedTime += Time.deltaTime;
            tiltPortion = elapsedTime / tiltTime;
            targetRotation = new Vector3(0f, 0f, collision.collisionDirection * wallTilt);
        }
        else
        {
            elapsedTime = 0;
            targetRotation = defaultRotation;
        }

        transform.localEulerAngles = Vector3.Lerp(defaultRotation, targetRotation, tiltPortion);
    }
}
