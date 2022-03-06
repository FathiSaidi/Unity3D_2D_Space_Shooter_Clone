using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour {


	[SerializeField]
	private int score;
	[SerializeField]
	private Text score_ui;
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private GameObject title_ui;
	[SerializeField]
	private GameObject gameover_ui;
	[SerializeField]
	private GameObject button_ui;

	private spawnmanager sm;



	void Start () {
		sm = GameObject.Find("spawn_manager").GetComponent<spawnmanager> ();
		score = 0;
		score_ui.text = "00";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void update_score(){
		score += 10;
		score_ui.text = score.ToString();
	}

	public void game_over(){
		sm.can_spawn = false;
		gameover_ui.SetActive (true);
		button_ui.SetActive (true);
	}

	public void start_game(){
		title_ui.SetActive (false);
		gameover_ui.SetActive (false);
		button_ui.SetActive (false);
		sm.can_spawn = true;
		sm.start_spawn ();
		score = 0;
		score_ui.text = "00";
		Instantiate (player,new Vector2(0f,0f),Quaternion.identity);
	}

}
