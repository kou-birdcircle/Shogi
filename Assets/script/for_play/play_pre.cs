using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;
public class play_pre : MonoBehaviour {
	string pid = button_info.pid;

	public static int[,] board_array = new int[9, 9] { { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
											   		   { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
											   		   { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
											   		   { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
											   		   { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
										   	   		   { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
											   		   { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
											   		   { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
											   		   { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, };
	IEnumerator Start () {
		float x=0,y=0;
		long array_x,array_y;
		string b;

		string url = "http://192.168.3.83:3000/plays/"+pid+"/pieces.json";
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null) {
			var json = Json.Deserialize (www.text) as Dictionary<string, object>;
			for(int a=1;a<=40;a++){
				b = a.ToString();
				var json2 = (Dictionary<string,object>)json[b];
				var info = GameObject.Find ("unit"+a);
				if(info != null){
					array_x = ((long)json2["posx"]);
					array_y = ((long)json2["posy"]);
					if(array_x !=0 && array_y != 0){
						board_array[array_x-1, array_y-1] = a;
					}
					x=(float)(-0.75)*((float)(long)json2["posx"]);
					y=(float)(-0.8)*((float)(long)json2["posy"]);
					info.transform.position = new Vector3(x,y,-3);
					info.GetComponent<SpriteRenderer> ().enabled = true;

					unit_pos u_p = info.GetComponent<unit_pos>();
					u_p.no = a;
					u_p.posx = ((int)(long)json2["posx"]);
					u_p.posy = ((int)(long)json2["posy"]);
					if(1<=a && a<=18) u_p.kind = "fu";
					else if(19<=a && a<=22) u_p.kind ="kyosha";
					else if(23<=a && a<=26) u_p.kind = "keima";
					else if(27<=a && a<=30) u_p.kind = "gin";
					else if(31<=a && a<=34) u_p.kind = "kin";
					else if(35<=a && a<=36) u_p.kind = "hisha";
					else if(37<=a && a<=38) u_p.kind = "kaku";
					else if(39<=a && a<=40) u_p.kind = "oh";
				}
			}
		}
	}
}