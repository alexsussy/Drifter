using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrifterController : MonoBehaviour {

    [SerializeField]
    private bool canJump = true;

    public float speed;

    private Rigidbody _rigidbody;
    private CapsuleCollider _collider;

    Vector3 movement;

    private void Awake(){
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
    }

    void Start () {
		
	}
	
	void Update () {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        movement = (xInput * transform.right + yInput * transform.forward).normalized;
	}

    private void FixedUpdate(){
        _rigidbody.velocity = movement * speed * Time.deltaTime;
    }
}
