using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CameraMovement : NetworkBehaviour {



    private Vector3 offset;

	// Use this for initialization
	void Start () {
       

        offset = Camera.main.transform.position - this.transform.position;
	}

	
	// Update is called once per frame
	void LateUpdate () {
  
        Camera.main.transform.position = this.transform.position + offset;
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -10);
	}
}
