using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrifterController : MonoBehaviour {

    public AnimationCurve jump;

    public float speed;

    private Rigidbody _rigidbody;

    Vector3 movement;

    private void Awake(){
        _rigidbody = GetComponent<Rigidbody>();
    }
	
	void Update () {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector3 target_velocity = (xInput * transform.right + yInput * transform.forward).normalized * speed;
        Vector3 current_velocity = _rigidbody.velocity;
	    movement = target_velocity - current_velocity;
        movement = new Vector3(movement.x, 0, movement.z);
    }	

    private void FixedUpdate(){
    	_rigidbody.AddForce(movement, ForceMode.VelocityChange);
    }
}
