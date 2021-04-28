using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private Animator animator;
    private bool isGrounded = false;

    private float lifeTime = 5;
    private static float speedRotate = 10;
	
    private void Start()
    {
        isGrounded = false;
    }

    private void Update()
    {
        if (isGrounded)
        {
            transform.Rotate(Vector3.up * speedRotate);
            lifeTime -= Time.deltaTime;
            if(lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

	private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = true;
        }
    }
}
