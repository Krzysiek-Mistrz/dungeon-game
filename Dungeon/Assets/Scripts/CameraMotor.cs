using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

	public Transform lookAt;
	public float boundX = 0.15f;
	public float boundY = 0.05f;

	private void Start()
	{
		lookAt = GameObject.Find("Player").transform;
	}

	private void LateUpdate() {
		Vector3 delta = Vector3.zero;

		// checking whether we are in the OX bounds
		float deltaX = lookAt.position.x - transform.position.x;
		if(deltaX > boundX || deltaX < -boundX) {
			if(transform.position.x < transform.position.x) {
				delta.x = deltaX - boundX;
			}
			else
			{
				delta.x = deltaX + boundX;
			}
		}

        // checking whether we are in the OY bounds
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < transform.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

		transform.position += new Vector3(deltaX, deltaY, 0);
    }
}
