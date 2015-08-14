using UnityEngine;
using System.Collections;
using MiniJSON;
using System.Collections.Generic;
public class com_GET : MonoBehaviour {
	// Use this for initialization
	IEnumerator Start () {
		string url = "http://192.168.3.83:3000/play.json";
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null) {
			var json = Json.Deserialize (www.text) as Dictionary<string, object>;
			//a=((long)json["watcher_count"]);
			Debug.Log ((long)json["turn_count"]);
			Debug.Log ((long)json["watcher_count"]);
			Debug.Log ((long)json["turn_player"]);
			Debug.Log ((string)json["state"]);
			//Debug.Log (a);
		}
	}
}
