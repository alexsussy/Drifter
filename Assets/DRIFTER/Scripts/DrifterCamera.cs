using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrifterCamera : MonoBehaviour {

    public float FOVKick;

    public float smooth = 5;

    public float minX = -60f,
        maxX = 60f;

    public float minY = -360f,
        maxY = 360f;

    public float sensitivityX = 5f,
        sensitivityY = 5f;

    private GameObject CameraPivot;
    public float rotX, rotY = 0f;


    void Awake() {
        CameraPivot = transform.GetChild(0).gameObject;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update () {
        if (Input.GetButton("Fire1")){
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 30f, 0.08f);
            sensitivityX = 3;
            sensitivityY = 3;
        }
        else{
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60f, 0.08f);
            sensitivityX = 5f;
            sensitivityY = 5f;
        }

        rotY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotX += Input.GetAxis("Mouse X") * sensitivityX;

        rotY = Mathf.Clamp(rotY, minY, maxY);

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

	}

    private void FixedUpdate(){
        Quaternion targetX = Quaternion.Euler(0, rotX, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetX, Time.deltaTime * smooth);


        Quaternion targetY = Quaternion.Euler(new Vector3(-rotY, 0, 0));
        CameraPivot.transform.localRotation = Quaternion.Slerp(CameraPivot.transform.localRotation, targetY, Time.deltaTime * smooth);
    }
}
