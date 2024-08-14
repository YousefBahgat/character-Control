using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characterscript : MonoBehaviour {
	private CharacterController controller;
	private Vector3 movement;
	public  float  speed = 5; 
	public  float  jump = 5; 
	public  float  gravity =20; 
	public  float rotation;
	public  float rotationSpeed = 100;
	private Animator animator;

	// Use this for initialization
	void Start () {
		controller = this.GetComponent<CharacterController> ();
		animator = this.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical  = Input.GetAxis ("Vertical");
		   if (controller.isGrounded) 
		    {
		        movement = new Vector3 (0,0,moveVertical);
			    movement = this.transform.TransformDirection (movement);
			  if(Input.GetKey(KeyCode.LeftShift))
			   { 
			     speed = 10;
				 animator.SetBool ("isrunning", true);
			  }
			  else
			  {
				 speed = 5;
				 animator.SetBool("isrunning", false);
			  }


			if(Input.GetButton("Jump"))
			     {
				movement.y = jump;
				animator.SetBool("isjumping", true);
			     }
			   else
			   	{
				animator.SetBool("isjumping", false);
			    }  

		    }
		if (moveVertical != 0) {
			
			if (moveVertical < 0) {
				animator.SetBool ("iswalking_back", true);
			} else if (moveVertical > 0) {
				animator.SetBool ("iswalking",true);
			}
				
		} 
		else 
		{
			animator.SetBool ("iswalking",false);
			animator.SetBool ("iswalking_back", false);
		}

		rotation += rotationSpeed * moveHorizontal * Time.deltaTime;
		this.transform.eulerAngles = new Vector3 (0, rotation, 0);
		movement.y -= gravity * Time.deltaTime;
	    controller.Move (movement * speed * Time.deltaTime);
	}
}
