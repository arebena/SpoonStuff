using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class	PlayerMove : MonoBehaviour
{
	public CharacterController2D	controller;
	public Animator					animator;
	public float					runSpeed = 40;
	float							horizontalMove = 0;
	bool							jump = false;
	bool							crouch = false;

	void	Start() {}

	void	Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}
		if (Input.GetButtonDown("Crouch"))
		{
			Debug.Log("crouch");
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{

			Debug.Log("not_crouch");
			crouch = false;
        }

	}

	public void	OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}
	public void	OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void	FixedUpdate ()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;
	}
}
