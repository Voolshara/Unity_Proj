using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	public float sensitivity = 3; // чувствительность мышки
	public float limit = 80; // ограничение вращения по Y
	public float zoom = 10.0f; // чувствительность при увеличении, колесиком мышки
	public float zoomMax = 10; // макс. увеличение
	public float zoomMin = 3; // мин. увеличение
	public float zoomStart = 70;
	private float X, Y;

	void Start () 
	{
		limit = Mathf.Abs(limit);
		if(limit > 90) limit = 90;
		offset = new Vector3(offset.x, offset.y, -zoomStart); //-Mathf.Abs(zoomMax)/2);
		transform.position = target.position + offset;
	}

	void Update ()
	{	
		
		if (!(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))){
			// Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			if(Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
			else if(Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
			offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

			X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
			Y += Input.GetAxis("Mouse Y") * sensitivity;
			Y = Mathf.Clamp (Y, -limit, limit);
			transform.localEulerAngles = new Vector3(-Y, X, 0);
			transform.position = transform.localRotation * offset + target.position;
		}
		else{
			  Cursor.visible = true;
			  Cursor.lockState = CursorLockMode.Confined;
		}
	}
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class camera : MonoBehaviour
// {   
//     public GameObject player;
//     public Transform target;

//     public float smooth_of_camera = 10.0f;
//     public float speed_of_camera_higher = 6.0f;
//     private float now_distance = 0.0f;
//     public Vector3 offset = new Vector3(0, 2, -5);

//     public enum RotationAxes { 
//         MouseXAndY = 0,
//         MouseX = 1,
//         MouseY = 2
//     }
//     public RotationAxes axes = RotationAxes.MouseXAndY;

//     public float sensitivityHor = 9.0f;
//     public float sensitivityVert = 9.0f; 

//     public float minimumVert = -45.0f;
//     public float maximumVert = 45.0f;

//     private float _rotationX = 0;

//     public float sensitivity = 3; 
// 	private float X, Y;
    
//     // Start is called before the first frame update
//     void Start()
//     {
//         offset = transform.position - player.transform.position;
//     }
    
//     void  Update(){
        
//         float mw = Input.GetAxis("Mouse ScrollWheel");
//         if(mw != 0){
//             now_distance -= mw * speed_of_camera_higher;
//             if(now_distance > 11) now_distance = 11;
//             if(now_distance < -7) now_distance = -7;
//         }
//         transform.position = Vector3.Lerp(transform.position, target.position + offset + new Vector3(0, now_distance / 5, now_distance * (-1)), Time.deltaTime * smooth_of_camera);

//         // if (axes == RotationAxes.MouseX) {
//         //     transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
//         // }
//         // else if (axes == RotationAxes.MouseY) {
//         //     _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert; 
//         //     _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
//         //     float rotationY = transform.localEulerAngles.y;
//         //     transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0); 
//         // }
//         // else {
//         // _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
//         // _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
//         // float delta = Input.GetAxis("Mouse X") * sensitivityHor;
//         // float rotationY = transform.localEulerAngles.y + delta;
//         // transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
//         // }
//         // X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
// 		// Y += Input.GetAxis("Mouse Y") * sensitivity;
// 		// Y = Mathf.Clamp (Y, -90, 90);
// 		// transform.localEulerAngles = new Vector3(-Y, X, 0);
//     } 


// }