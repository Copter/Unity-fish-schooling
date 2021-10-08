using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlFishScript : MonoBehaviour
{
    public Rigidbody2D rb;
    //public float swimForce = 100;
	public float swimSpeed = 1f;
	Vector2 initialVector;
	public float steerStrength = 0.1f;

	public enum Orientation {MoveForward, SteerLeft, SteerRight};
	public Orientation currentOrientation;

    // Start is called before the first frame update
    void Start()
    {
		initialVector = RandomUnitVector();
		rb.velocity = swimSpeed * initialVector;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            currentOrientation = Orientation.SteerLeft;
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            currentOrientation = Orientation.SteerRight;
        }
        else
        {
            currentOrientation = Orientation.MoveForward;
        }

        if (Input.GetKey(KeyCode.W))
        {
            swimSpeed += 0.01f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (swimSpeed > 0.011f)
                swimSpeed -= 0.01f;
        }

		if(currentOrientation == Orientation.MoveForward)	
			move();
		else if(currentOrientation == Orientation.SteerLeft)
			moveSteerLeft();
		else if(currentOrientation == Orientation.SteerRight)
			moveSteerRight();

		transform.rotation = Quaternion.LookRotation(Vector3.forward, rb.velocity);
    }

	public Vector2 RandomUnitVector()
	{
		float randomAngle = Random.Range(0f, 360f);
		return new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
	}

	public void move()
	{
		rb.velocity = swimSpeed * rb.velocity.normalized;
	}

	public void moveSteerLeft()
	{
		Vector2 steerDirVector = new Vector2(-rb.velocity.y, rb.velocity.x);
		steerDirVector = steerDirVector.normalized * steerStrength;
		rb.velocity = steerDirVector + (swimSpeed * rb.velocity.normalized);
	}

	public void moveSteerRight()
	{
		Vector2 steerDirVector = new Vector2(rb.velocity.y, -rb.velocity.x);
		steerDirVector = steerDirVector.normalized * steerStrength;
		rb.velocity = steerDirVector + (swimSpeed * rb.velocity.normalized);
	}

	/*
	void FixedUpdate()
    {
        if (rb.velocity.x <= 0.25 && rb.velocity.y <= 0.25)
        {
            rb.velocity = Vector2.zero;
            var randAngle = Random.Range(0, 360);
            transform.rotation = Quaternion.Euler(Vector3.forward * randAngle);
            var moveVec = transform.right * swimForce;
            rb.AddForce(moveVec);
        }
    }
	*/
}
