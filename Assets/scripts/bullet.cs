using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	private float speed = 30f;

	private gamemanager gm;

	// Use this for initialization
	void Start () {
		gm = GameObject.Find("game_manager").GetComponent<gamemanager> ();
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

	void OnTriggerEnter2D(Collider2D target){
		if(target.tag == "enemy"){
			gm.update_score ();
			Destroy (this.gameObject);
			Destroy (target.gameObject);
		}

		if(target.tag == "enemybullet"){
			
			Destroy (this.gameObject);
			Destroy (target.gameObject);
		}
	}

}
