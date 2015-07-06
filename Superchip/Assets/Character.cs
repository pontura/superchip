using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public float speed = 200;
    public float speedJump = 1f;
    public float speedJumpAcceleration = 1.1f;
    public float inertia = 0.5f;
    private float jumpAcceleration;
    public actions action;
    public enum actions
    {
        RUNNING,
        JUMPING_UP,
        JUMPING_DOWN
    }

	void Start () {
	
	}
	
	void Update () {
        
        if (Input.GetKeyDown("space"))
            Jump();

        Vector3 pos = transform.localPosition;
        pos.x += speed * Time.deltaTime;

        if (action == actions.JUMPING_UP)
        {
            jumpAcceleration /= speedJumpAcceleration;
            pos.y += jumpAcceleration*Time.deltaTime;
            if (jumpAcceleration < inertia)
                JumpDown();
        }
        if (action == actions.JUMPING_DOWN)
        {
            jumpAcceleration *= speedJumpAcceleration;
            pos.y -= jumpAcceleration * Time.deltaTime;
            
        }
        transform.localPosition = pos;
	}
    public void OnGround()
    {
        action = actions.RUNNING;
    }
    void Jump()
    {
        jumpAcceleration = speedJump;
        action = actions.JUMPING_UP;
    }
    void JumpDown()
    {
        jumpAcceleration = inertia;
        action = actions.JUMPING_DOWN;
    }
    public void OnAir()
    {
        if (action == actions.RUNNING)
        {
            JumpDown();
        }
    }
}
