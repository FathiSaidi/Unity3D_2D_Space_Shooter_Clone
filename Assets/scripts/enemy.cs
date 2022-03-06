using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	private float speed = 4f;

	[SerializeField]
	private GameObject bullet;




	// Use this for initialization
	void Start () {
		StartCoroutine (auto_shoot ());
	}

	// Update is called once per frame
	void Update () {
		movement ();
	}

	public void movement(){
		transform.Translate (Vector2.up * -speed * Time.deltaTime);
		if(transform.position.y < -7){
			Destroy (this.gameObject);
		}
	}

	IEnumerator auto_shoot(){
		float shoot_time = Random.Range (0.5f,2.5f);
		yield return new WaitForSeconds (shoot_time);
		Instantiate (bullet,new Vector2(transform.position.x,transform.position.y -0.7f),Quaternion.identity);
		StartCoroutine (auto_shoot ());
	}

}
