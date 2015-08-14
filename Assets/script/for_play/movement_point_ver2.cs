using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class movement_point_ver2 : MonoBehaviour {
	string pid = button_info.pid;
	string uid = button_info.uid;
	int o_x,o_y,ix,iy;
	float fx,fy;
	
	public float x;
	public float y;
	public int u_n;
	
	void OnMouseDown(){
		x = this.transform.position.x;
		y = this.transform.position.y;
		fx = x / (float)-0.75;
		fy = (y / (float)-0.8) + (float)0.3;
		ix = (int)fx;
		iy = (int)fy;
		x = this.transform.position.x;
		y = this.transform.position.y;
		
		var change_uni = GameObject.FindWithTag ("Choosing");
		if (change_uni != null) {
			o_x = unit_movement.old_x; 
			o_y = unit_movement.old_y;
			u_n = unit_movement.unit_no;
		} else {
			change_uni = GameObject.FindWithTag ("Choosing2");
			if (change_uni != null) {
				o_x = o_y = 0;
				u_n = get_unit_play.play_no;
			}
		}

		if (change_uni != null) {
			unit_play unit_play = this.GetComponent<unit_play> ();
			unit_play.o_x = o_x;
			unit_play.o_y = o_y;
			unit_play.fx = fx;
			unit_play.fy = fy;
			unit_play.ix = ix;
			unit_play.iy = iy;
			unit_play.x = x;
			unit_play.y = y;
			unit_play.change_uni = change_uni;
			unit_play.u_n = u_n;
			unit_play.u_p ();

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
		form.AddField ("get_id", unit_play.get_id);
		Debug.Log ("get_id = " + unit_play.get_id);
		
		WWW www = new WWW (url, form);
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
		}
	}
}