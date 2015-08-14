using UnityEngine;
using System.Collections;
using MiniJSON;
using System.Collections.Generic;
public class Game_administration : MonoBehaviour {
	string pid = button_info.pid;
	string uid = button_info.uid;
	string turn_player,old_turn_count = "1", new_turn_count = "1",state_check,winner;
	long l_new_turn_count,l_turn_player,l_winner;
	private float t=0;
	IEnumerator Start(){

		string url = "http://192.168.3.83:3000/plays/"+ pid;
		WWW www = new WWW (url);
		yield return www;
		if (www.error == null) {
			Dictionary<string, object> json = Json.Deserialize (www.text) as Dictionary<string, object>;
			Debug.Log (www.text);
			if(json ["turn_player"] != null){
				l_turn_player = (long)json ["turn_player"];
				turn_player = l_turn_player.ToString ();
				if (turn_player != uid) {
					var a = GameObject.Find ("Main Camera");
					a.transform.Rotate (new Vector3 (0, 0, 180));
				}
			}
		}
	}

	void Update(){
		t += Time.deltaTime;
		if (t > 0.5f) {
			StartCoroutine (board_change ());
			t = 0;
		}
	}

	IEnumerator board_change () {
		string url = "http://192.168.3.83:3000/plays/"+pid;
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null) {
			Dictionary<string, object> json = Json.Deserialize (www.text) as Dictionary<string, object>;
			Debug.Log (www.text);
			l_new_turn_count = (long)json["turn_count"];
			state_check = (string)json["state"];
			new_turn_count = l_new_turn_count.ToString ();
			if(new_turn_count != old_turn_count){
				var board_update = this.GetComponent<board_update>();
				StartCoroutine(board_update.b_u());
				old_turn_count = new_turn_count;
			}
			if(state_check == "exit"){
				Debug.Log("勝ちです");
				GameObject.Find ("win").GetComponent<SpriteRenderer> ().enabled = true;
			}
			if(state_check == "finish"){
				string winner_url = "http://192.168.3.83:3000/plays/"+pid+"/winner";
				WWW winner_www = new WWW(winner_url);
				yield return winner_www;
				if (winner_www.error == null) {
					Dictionary<string, object> winner_json = Json.Deserialize (winner_www.text) as Dictionary<string, object>;
					l_winner = (long)winner_json["winner"];
					winner = l_winner.ToString ();
					if(winner == uid){
						Debug.Log("勝ちです");
						GameObject.Find ("win").GetComponent<SpriteRenderer> ().enabled = true;
					}
				}

			}
		}

	}
}