using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	[SerializeField] private float speedMove = 1;

	public Joystick Joystick;

	private Vector3 moveVector;

	private CharacterController controller;
	private Animator animator;

	public static CharacterMovement Instance;

	private void Awake()
    {
		Instance = this;
    }

	private void Start()
    {
		controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
    }
	
	private void Update()
    {
		CharacterMove();
    }

	private void CharacterMove()
    {
		moveVector = Vector3.zero;
		moveVector.x = Joystick.Horizontal() * speedMove;
		moveVector.z = Joystick.Vertical() * speedMove;

		if(moveVector.x != 0 || moveVector.z != 0)
        {
			animator.SetBool("Move", true);
        }
        else
        {
			animator.SetBool("Move", false);
        }

		if(Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
			Vector3 direction = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
			transform.rotation = Quaternion.LookRotation(direction);
        }

		controller.Move(moveVector * Time.deltaTime);
    }
}
