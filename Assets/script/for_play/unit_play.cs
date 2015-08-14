using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class unit_play : MonoBehaviour {
	int[,] board_array = play_pre.board_array;

	public int o_x,o_y,ix,iy;
	public float fx,fy;
	public GameObject change_uni = null;
	public float x;
	public float y;
	public int u_n;
	public static int get_id =-1;
	
	public void u_p(){
		if(change_uni != null){
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
				Debug.Log ("get_id = " + get_id);
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
		}
	}
}