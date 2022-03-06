using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour {

	[SerializeField]
	private GameObject enemy;
	[SerializeField]
	private GameObject[] powerups;

	public bool can_spawn;


	// Use this for initialization
	void Start () {
		can_spawn = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void start_spawn(){
		StartCoroutine (spawn_enemy ());
		StartCoroutine (spawn_powerups ());
	}

	IEnumerator spawn_enemy(){
		if(can_spawn){
			yield return new WaitForSeconds (1f);
			float rand_spawn = Random.Range (-7f,8f);
			Instantiate (enemy,new Vector2(rand_spawn,6.3f),Quaternion.identity);
		}
		StartCoroutine (spawn_enemy ());
	}

	IEnumerator spawn_powerups(){
		if(can_spawn){
			yield return new WaitForSeconds (7f);
			float rand_spawn = Random.Range (-7f,8f);
			int rand_powerup = Random.Range (0, 3);
			Instantiate (powerups[rand_powerup],new Vector2(rand_spawn,6.3f),Quaternion.identity);
		}
		StartCoroutine (spawn_powerups ());
	}
}
