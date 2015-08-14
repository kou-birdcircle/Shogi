using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class get_unit_play : MonoBehaviour {

	public static int play_no=-1;
	void OnMouseDown(){
		string kind_check = this.GetComponent<unit_pos>().kind;
		var a = GameObject.Find ("Gamecontroller").GetComponent<get_unit_list>();

		if (kind_check == "fu") {
			play_no = a.fu_list [a.fu_list.Count - 1];
			a.fu_list.RemoveAt (a.fu_list.Count - 1);
		}
		if (kind_check == "kyosha") {
			play_no = a.kyosha_list [a.kyosha_list.Count - 1];
			a.kyosha_list.RemoveAt (a.kyosha_list.Count - 1);
		}
		if (kind_check == "keima") {
			play_no = a.keima_list [a.keima_list.Count - 1];
			a.keima_list.RemoveAt (a.keima_list.Count - 1);
		}
		if (kind_check == "gin") {
			play_no = a.gin_list [a.gin_list.Count - 1];
			a.gin_list.RemoveAt (a.gin_list.Count - 1);
		}
		if (kind_check == "kin") {
			play_no = a.kin_list [a.kin_list.Count - 1];
			a.kin_list.RemoveAt (a.kin_list.Count - 1);
		}
		if (kind_check == "hisha") {
			play_no = a.hisha_list [a.hisha_list.Count - 1];
			a.hisha_list.RemoveAt (a.hisha_list.Count - 1);
		}
		if (kind_check == "kaku") {
			play_no = a.kaku_list [a.kaku_list.Count - 1];
			a.kaku_list.RemoveAt (a.kaku_list.Count - 1);
		}
		Debug.Log (play_no);
		var p_n = GameObject.Find ("unit"+play_no);
		p_n.tag = ("Choosing2");

	}
}