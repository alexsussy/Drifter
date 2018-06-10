using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrifterController : MonoBehaviour {

<<<<<<< HEAD
    public AnimationCurve jump;
=======
    [SerializeField]
    //private bool canJump = true;
>>>>>>> parent of d11e802... Mouse smooth

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
<<<<<<< HEAD
	    movement = target_velocity - current_velocity;
    }	

    private void FixedUpdate(){
        movement = new Vector3(movement.x, 0, movement.z);
=======
	movement = target_velocity - current_velocity;
		
    // movement = (xInput * transform.right + yInput * transform.forward).normalized;

	}	

    private void FixedUpdate(){
        // _rigidbody.velocity = movement * speed * Time.deltaTime;
    	// Switched to add force, should handle collisions better, but may 'feel' different?
    	// I also may have got the forcemode wrong
>>>>>>> parent of d11e802... Mouse smooth
    	_rigidbody.AddForce(movement, ForceMode.VelocityChange);
        //_rigidbody.AddForce(Vector3.up * -9.8f);
    }
}
