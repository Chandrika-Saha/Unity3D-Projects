using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	private CharacterController controller;
	private Vector3 movevector;
	private float speed = 10.0f;
	private float verticalvelocity = 0.0f;
	private float gravity = 12.0f;
	private bool isDead = false;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isDead)
			return;
		movevector = Vector3.zero;


		//if (controller.isGrounded) {
			//verticalvelocity = -0.5f;

		//} else {
			//verticalvelocity -= gravity * Time.deltaTime;
		//}
		//x- in unity x is for left and right
		movevector.x = Input.GetAxisRaw ("Horizontal") * speed;
		if (Input.GetMouseButton (0)) {

			if (Input.mousePosition.x > Screen.width / 2)
				movevector.x = speed;
			else
				movevector.x = -speed;
		}

		//y - in unity y is for up and down
		movevector.y = verticalvelocity;


		//z - in unity z is for forward and backward
		movevector.z = speed;

		controller.Move (movevector * Time.deltaTime);// used for moving the charecter.

	}

	public void speedUp(float up)
	{
		speed = 10.0f + up;
			
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if ((hit.point.z > transform.position.z + 0.1f) && hit.gameObject.tag == "die")
			death ();

	}

	private void death()
	{
		isDead = true;
		GetComponent<scoreGen>().onDeath();
	}
}