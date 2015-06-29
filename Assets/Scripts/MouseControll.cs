using UnityEngine;
using System.Collections;
[RequireComponent(typeof(BoxCollider2D))]
public class MouseControll : MonoBehaviour {

	// Use this for initialization

	private Vector3 target;
	private float speed =100;
	private Vector3 screenPoint;
	private Vector3 offset;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
		
		 if(Input.GetMouseButton(0)){
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        
			transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

			transform.position = target;
			}

	 }   

 
		void OnMouseDown() {
		
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
			
		}

		void OnMouseDrag()
		{
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint)+offset;
			transform.position = curPosition;
		}


	}
