using UnityEngine;
using System.Collections;
using MiniJSON;
using System.Collections.Generic;

public class board_update : MonoBehaviour {
	string pid = button_info.pid;
	int[,] board_array = new int[9, 9];
	public IEnumerator b_u(){
		Debug.Log ("盤面の更新を開始します");
		float x = 0, y = 0;
		long array_x, array_y;
		string b;
		
		string url_update = "http://192.168.3.83:3000/plays/" + pid + "/pieces.json";
		WWW www_update = new WWW (url_update);
		yield return www_update;
		if (www_update.error == null) {
			var json = Json.Deserialize (www_update.text) as Dictionary<string, object>;
			for (int a=1; a<=40; a++) {
				b = a.ToString ();
				var json2 = (Dictionary<string,object>)json [b];
				var info = GameObject.Find ("unit" + a);
				if (info != null) {
					array_x = ((long)json2 ["posx"]);
					array_y = ((long)json2 ["posy"]);
					if (array_x != 0 && array_y != 0) {
						board_array [array_x - 1, array_y - 1] = a;
					}
					x = (float)(-0.75) * ((float)(long)json2 ["posx"]);
					y = (float)(-0.8) * ((float)(long)json2 ["posy"]);
					info.transform.position = new Vector3 (x, y, -3);

				}
			}
			Debug.Log ("盤面の更新完了しました！");
		}
	}
}