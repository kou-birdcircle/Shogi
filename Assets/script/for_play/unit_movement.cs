using UnityEngine;
using System.Collections;

public class unit_movement : MonoBehaviour {
	public static int unit_no,old_x,old_y;
	public static string type;
	void OnMouseDown(){
		this.tag = ("Choosing");
		GameObject.Find ("unit_place").transform.position = new Vector3((float)-3.75,-4,-4);
		var unit_info = this.GetComponent<unit_pos>();
		old_x = unit_info.posx;
		old_y = unit_info.posy;
		unit_no = unit_info.no;
		type = unit_info.kind;
	}
}
