using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement movement;
    public float collisionDirection = 0f;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();

        }
        if (collisionInfo.collider.tag == "Wall")
        {
            if (collisionInfo.transform.position.x < transform.position.x)
            {
                collisionDirection = -1f;
            } else
            {
                collisionDirection = 1f;
            }
        } else
        {
            collisionDirection = 0f;
        }
    }
    void OnCollisionExit()
    {
        collisionDirection = 0f;
    }
}
