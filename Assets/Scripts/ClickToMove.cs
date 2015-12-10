using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {
	public float speed, rotateSpeed;

	CharacterController controller;
	Vector3 moveToPosition;

	void Start() {
		controller = GetComponent<CharacterController>();
		moveToPosition = transform.position;
	}

	void Update() {
        if (Input.GetMouseButton(0)) {
			locatePosition();
        }
        moveTo();
	}

    void locatePosition() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit, 1000)) {
			moveToPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
			Debug.Log(moveToPosition);
        }
    }

    void moveTo() {
        if (Vector3.Distance(transform.position, moveToPosition) > 0.8) {
            Quaternion newRotation = Quaternion.LookRotation(moveToPosition - transform.position);

            newRotation.x = 0f;
            newRotation.z = 0f;
			
			transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rotateSpeed);
            controller.SimpleMove(transform.forward * speed);
		}
	}
}
