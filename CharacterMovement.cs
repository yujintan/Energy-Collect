using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float speed = 6f;		// The speed that the player will move.
	public float turnSpeed = 60f;	// The speed that the player will turn.
	public float turnSmoothing = 15f;

	private Vector3 movement;
	private Vector3 turning;
	private Animator anim;
	private Rigidbody playerRigidbody;

	void Awake()
	{
		//get references
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();

	}

	void FixedUpdate()
	{
		//Store input axes
		float lh = Input.GetAxisRaw("Horizontal");
		float lv = Input.GetAxisRaw("Vertical");

		Move(lh, lv);
		Animating(lh, lv);
	}

	void Move(float lh, float lv)
	{
        //Move the player
        movement.Set(lh, 0f, lv);       //x y z, y plane is 0.

        movement = movement.normalized * speed * Time.deltaTime;    //speed that is consistent with time.

        playerRigidbody.MovePosition(transform.position + movement);

        if(lh != 0f || lv  != 0f)   //if it's anything other than touching the stick, it should rotate.
        {
            Rotating(lh, lv);
        }
	}

	void Rotating(float lh, float lv)
	{
        Vector3 targetDirection = new Vector3(lh, 0f, lv);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up); //rotate around the Y axis aka vector.up

        //add to the old rotation
        //lerp - interpolate. goes from one value to another value over time
        Quaternion newRotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation, targetRotation, turnSmoothing * Time.deltaTime);

        //change it's rotation
        GetComponent<Rigidbody>().MoveRotation(newRotation);
	}

	void Animating(float lh, float lv)
	{
        bool running = lh != 0f || lv != 0f;
        anim.SetBool("IsRunning", running);
	}
}
