using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerbullet : MonoBehaviour {


	private float speed = 30f;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		movement ();
	}

	public void movement(){
		transform.Translate (Vector2.up * speed * Time.deltaTime);

		if(transform.position.y > 7){
			Destroy (this.gameObject);
		}
	}
}
