using UnityEngine;
using System.Collections;
using MiniJSON;
using System.Collections.Generic;
public class button_info : MonoBehaviour {
	private int user_id;
	private int play_id;

	public static string uid;
	public static string pid;
	public static input_name sname;
	public static input_room_no sroom;

	void Start(){
		sname = GameObject.Find ("textbox").GetComponent<input_name> ();
		sroom = GameObject.Find ("textbox").GetComponent<input_room_no> ();
	}

	public void send(){
		StartCoroutine (login());
	}

	private IEnumerator login() {
		string url = "http://192.168.3.83:3000/users/login.json";
		WWWForm form = new WWWForm();
		form.AddField("name", sname.text);
		form.AddField("room_no", sroom.text);
		WWW www = new WWW(url, form);
		yield return www;
		if (www.error == null) {
			Debug.Log(www.text);
			var json = Json.Deserialize (www.text) as Dictionary<string,object>;
			user_id=((int)(long)json["user_id"]);
			play_id=((int)(long)json["play_id"]);
			uid=user_id.ToString();
			pid=play_id.ToString ();

		}
		Application.LoadLevel("play");
	}
}