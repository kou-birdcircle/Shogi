using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class movement_point : MonoBehaviour {
	string pid = button_info.pid;
	string uid = button_info.uid;
	int[,] board_array = play_pre.board_array;

	public float x;
	public float y;
	public int get_id=-1,u_n;

	void OnMouseDown(){
		var change_uni = GameObject.FindWithTag ("Choosing");
		if (change_uni != null) {
			int o_x = unit_movement.old_x; 
			int o_y = unit_movement.old_y;
			int ix, iy;
			float fx, fy;
			u_n = unit_movement.unit_no;
			x = this.transform.position.x;
			y = this.transform.position.y;
			fx = x / (float)-0.75;
			fy = (y / (float)-0.8) + (float)0.3;
			ix = (int)fx;
			iy = (int)fy;
			if (o_x != 0 && o_y != 0)
				board_array [o_x - 1, o_y - 1] = 0;
			Debug.Log ("ナンバー" + u_n + "の駒が" + o_x + "," + o_y + "から");
			if (board_array [ix - 1, iy - 1] != 0) {
				List<int> fu_l = GameObject.Find ("Gamecontroller").GetComponent<get_unit_list> ().fu_list;
				List<int> ky_l = GameObject.Find ("Gamecontroller").GetComponent<get_unit_list> ().kyosha_list;
				List<int> ke_l = GameObject.Find ("Gamecontroller").GetComponent<get_unit_list> ().keima_list;
				List<int> gi_l = GameObject.Find ("Gamecontroller").GetComponent<get_unit_list> ().gin_list;
				List<int> ki_l = GameObject.Find ("Gamecontroller").GetComponent<get_unit_list> ().kin_list;
				List<int> hi_l = GameObject.Find ("Gamecontroller").GetComponent<get_unit_list> ().hisha_list;
				List<int> ka_l = GameObject.Find ("Gamecontroller").GetComponent<get_unit_list> ().kaku_list;
				get_id = board_array [ix - 1, iy - 1];
				var kill = GameObject.Find ("unit" + get_id);
				int kill_unit_no = kill.GetComponent <unit_pos> ().no;
				string kill_unit_kind = kill.GetComponent <unit_pos> ().kind;
				Debug.Log (kill_unit_kind);
				Debug.Log (kill_unit_no);

				if (kill_unit_kind == "fu")
					fu_l.Add (kill_unit_no);
				if (kill_unit_kind == "kyosha")
					ky_l.Add (kill_unit_no);
				if (kill_unit_kind == "keima")
					ke_l.Add (kill_unit_no);
				if (kill_unit_kind == "gin")
					gi_l.Add (kill_unit_no);
				if (kill_unit_kind == "kin")
					ki_l.Add (kill_unit_no);
				if (kill_unit_kind == "hisha")
					hi_l.Add (kill_unit_no);
				if (kill_unit_kind == "kaku")
					ka_l.Add (kill_unit_no);

				int cntfu = fu_l.Count;
				Debug.Log ("取った歩の数は" + cntfu);
				int cntky = ky_l.Count;
				Debug.Log ("取った香車の数は" + cntky);
				int cntke = ke_l.Count;
				Debug.Log ("取った桂馬の数は" + cntke);
				int cntgi = gi_l.Count;
				Debug.Log ("取った銀の数は" + cntgi);
				int cntki = ki_l.Count;
				Debug.Log ("取った金の数は" + cntki);
				int cnthi = hi_l.Count;
				Debug.Log ("取った飛車の数は" + cnthi);
				int cntka = ka_l.Count;
				Debug.Log ("取った角の数は" + cntka);

				image_list i_l = kill.GetComponent<image_list> ();
				var g_u = i_l.get_unit;
				kill.GetComponent<SpriteRenderer> ().sprite = g_u;
				kill.GetComponent <SpriteRenderer> ().enabled = false;
				kill.transform.position = new Vector3 (0, 0, -3);
				Debug.Log ("ナンバー" + get_id + "の駒をとって");
			}
			board_array [ix - 1, iy - 1] = u_n;
			Debug.Log ((ix) + "," + iy + "に移動しました。今このマスにいるのはナンバー" + u_n + "の駒です。");

			change_uni.transform.position = new Vector3 (x, y, -3);
			var new_posi = change_uni.GetComponent<unit_pos> ();
			new_posi.posx = ix;
			new_posi.posy = iy;
			change_uni.tag = ("Untagged");
			if (change_uni.GetComponent<SpriteRenderer> ().enabled == false)
				change_uni.GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("unit_place").transform.position = new Vector3 ((float)-3.75, -4, -2);
			StartCoroutine (board_info_send ());
		}
		var change_uni2 = GameObject.FindWithTag ("Choosing2");
		if(change_uni2 != null) {
			int o_x = 0;
			int o_y = 0;
			int ix, iy;
			float fx, fy;
			u_n = get_unit_play.play_no;
			x = this.transform.position.x;
			y = this.transform.position.y;
			fx = x / (float)-0.75;
			fy = (y / (float)-0.8) + (float)0.3;
			ix = (int)fx;
			iy = (int)fy;
			if (o_x != 0 && o_y != 0)
				board_array [o_x - 1, o_y - 1] = 0;
			Debug.Log ("ナンバー" + u_n + "の駒が" + o_x + "," + o_y + "から");
			if (board_array [ix - 1, iy - 1] != 0) {
				List<int> fu_l = GameObject.Find ("Gamecontroller").GetComponent<get_unit_list> ().fu_list;
				List<int> ky_l = GameObject.Find ("Gamecontroller").GetComponent<get_unit_list> ().kyosha_list;
				List<int> ke_l = GameObject.Find ("Gamecontroller").GetComponent<get_unit_list> ().keima_list;
				List<int> gi_l = GameObject.Find ("Gamecontroller").GetComponent<get_unit_list> ().gin_list;
				List<int> ki_l = GameObject.Find ("Gamecontroller").GetComponent<get_unit_list> ().kin_list;
				List<int> hi_l = GameObject.Find ("Gamecontroller").GetComponent<get_unit_list> ().hisha_list;
				List<int> ka_l = GameObject.Find ("Gamecontroller").GetComponent<get_unit_list> ().kaku_list;
				get_id = board_array [ix - 1, iy - 1];
				var kill = GameObject.Find ("unit" + get_id);
				int kill_unit_no = kill.GetComponent <unit_pos> ().no;
				string kill_unit_kind = kill.GetComponent <unit_pos> ().kind;
				Debug.Log (kill_unit_kind);
				Debug.Log (kill_unit_no);
				
				if (kill_unit_kind == "fu")
					fu_l.Add (kill_unit_no);
				if (kill_unit_kind == "kyosha")
					ky_l.Add (kill_unit_no);
				if (kill_unit_kind == "keima")
					ke_l.Add (kill_unit_no);
				if (kill_unit_kind == "gin")
					gi_l.Add (kill_unit_no);
				if (kill_unit_kind == "kin")
					ki_l.Add (kill_unit_no);
				if (kill_unit_kind == "hisha")
					hi_l.Add (kill_unit_no);
				if (kill_unit_kind == "kaku")
					ka_l.Add (kill_unit_no);
				
				int cntfu = fu_l.Count;
				Debug.Log ("取った歩の数は" + cntfu);
				int cntky = ky_l.Count;
				Debug.Log ("取った香車の数は" + cntky);
				int cntke = ke_l.Count;
				Debug.Log ("取った桂馬の数は" + cntke);
				int cntgi = gi_l.Count;
				Debug.Log ("取った銀の数は" + cntgi);
				int cntki = ki_l.Count;
				Debug.Log ("取った金の数は" + cntki);
				int cnthi = hi_l.Count;
				Debug.Log ("取った飛車の数は" + cnthi);
				int cntka = ka_l.Count;
				Debug.Log ("取った角の数は" + cntka);
				
				image_list i_l = kill.GetComponent<image_list> ();
				var g_u = i_l.get_unit;
				kill.GetComponent<SpriteRenderer> ().sprite = g_u;
				kill.GetComponent <SpriteRenderer> ().enabled = false;
				kill.transform.position = new Vector3 (0, 0, -3);
				Debug.Log ("ナンバー" + get_id + "の駒をとって");
			}
			board_array [ix - 1, iy - 1] = u_n;
			Debug.Log ((ix) + "," + iy + "に移動しました。今このマスにいるのはナンバー" + u_n + "の駒です。");

			change_uni.transform.position = new Vector3 (x, y, -3);
			var new_posi = change_uni.GetComponent<unit_pos> ();
			new_posi.posx = ix;
			new_posi.posy = iy;
			change_uni.tag = ("Untagged");
			if (change_uni.GetComponent<SpriteRenderer> ().enabled == false)
				change_uni.GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("unit_place").transform.position = new Vector3 ((float)-3.75, -4, -2);
			StartCoroutine (board_info_send ());
		}
	}

	private IEnumerator board_info_send(){
		string sendu_n = u_n.ToString ();
		u_n = unit_movement.unit_no;
		x = this.transform.position.x;
		y = this.transform.position.y;
		float posx = x / (float)-0.75;
		float posy = (y / (float)-0.8) + (float)0.3;
		string strx = posx.ToString ();
		string stry = posy.ToString ();
		string url = "http://192.168.3.83:3000/plays/update.json";
		WWWForm form = new WWWForm ();
		form.AddField ("play_id", pid);
		form.AddField ("user_id", uid);
		form.AddField ("move_id", sendu_n);
		form.AddField ("posx", strx);
		form.AddField ("posy", stry);
		form.AddField ("promote", "false");
		form.AddField ("get_id", get_id);
		Debug.Log ("get_id = " + get_id);

		WWW www = new WWW (url, form);
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
		}
	}
}