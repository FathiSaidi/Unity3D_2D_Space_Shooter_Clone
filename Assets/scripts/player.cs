using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {



	private float speed = 7f;

	private bool shield_activation;
	private bool powerbullet_activation;
	private bool speedboost_activation;

	[SerializeField]
	private GameObject bullet;
	[SerializeField]
	private GameObject shield;
	[SerializeField]
	private GameObject power_bullet;

	private gamemanager gm;



	// Use this for initialization
	void Start () {
		gm = GameObject.Find("game_manager").GetComponent<gamemanager> ();
		shield_activation = false;
		powerbullet_activation = false;
		speedboost_activation = false;
	}
	
	// Update is called once per frame
	void Update () {
		movement ();
		shoot ();
	}

	public void movement(){
		
		float hinput = Input.GetAxisRaw ("Horizontal");
		float vinput = Input.GetAxisRaw ("Vertical");

		if (speedboost_activation) {
			transform.Translate (Vector3.right * hinput * (speed + 3f) * Time.deltaTime);
			transform.Translate (Vector3.up * vinput * (speed + 3f) * Time.deltaTime);
		} else {
			transform.Translate (Vector3.right * hinput * speed * Time.deltaTime);
			transform.Translate (Vector3.up * vinput * speed * Time.deltaTime);
		}

		if(transform.position.y > 4f){
			transform.position = new Vector2 (transform.position.x, 4f);
		}else if(transform.position.y < -4f){
			transform.position = new Vector2 (transform.position.x, -4f);
		}

		if(transform.position.x > 8f){
			transform.position = new Vector2 (8f, transform.position.y);
		}else if(transform.position.x < -8f){
			transform.position = new Vector2 (-8f, transform.position.y);
		}

	}

	public void shoot(){
		if(Input.GetKeyDown(KeyCode.Space)){
			if (powerbullet_activation) {
				Instantiate (power_bullet, new Vector2 (transform.position.x, transform.position.y + 0.3f), Quaternion.identity);
			} else {
				Instantiate (bullet,new Vector2(transform.position.x,transform.position.y +0.3f),Quaternion.identity);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D target){
		if(target.tag == "enemy" || target.tag == "enemybullet"){
			if (shield_activation) {
				Destroy (target.gameObject);
				shield_activation = false;
				shield.SetActive (false);
				return;
			} else {
				gm.game_over ();
				Destroy (this.gameObject);
				Destroy (target.gameObject);
			}
		}

		switch(target.tag){
		case "shield":
			powerups_activation (1);
			Destroy (target.gameObject);
			break;
		case "speedboost":
			powerups_activation (2);
			Destroy (target.gameObject);
			break;
		case "powerbullet":
			powerups_activation (3);
			Destroy (target.gameObject);
			break;
		}
	}

	public void powerups_activation(int powerup_id){
		switch(powerup_id){
		case 1:
			shield_activation = true;
			shield.SetActive (true);
			break;
		case 2:
			speedboost_activation = true;
			StartCoroutine (speedboost_timer());
			break;
		case 3:
			powerbullet_activation = true;
			StartCoroutine (powershoot_timer());
			break;
		}
	}

	IEnumerator powershoot_timer(){
		yield return new WaitForSeconds (10f);
		powerbullet_activation = false;
	}

	IEnumerator speedboost_timer(){
		yield return new WaitForSeconds (10f);
		speedboost_activation = false;
	}

}
