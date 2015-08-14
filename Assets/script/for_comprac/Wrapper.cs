using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;
class Wrapper : MonoBehaviour {
	public WWW GET(string url) {
		WWW www = new WWW (url);
		StartCoroutine (WaitForRequest (www));
		return www;
	}
	public WWW POST(string url, Dictionary<string,string> post) {
		WWWForm form = new WWWForm();
		foreach(KeyValuePair<string,string> post_arg in post) {
			form.AddField(post_arg.Key, post_arg.Value);
		}
		WWW www = new WWW(url, form);
		StartCoroutine(WaitForRequest(www));
		return www;
	}
	private IEnumerator WaitForRequest(WWW www) {
		yield return www;
		 //check for errors
		if (www.error == null) {
			var json = Json.Deserialize (www.text) as Dictionary<string, object>;
			Debug.Log ((long)json["turn_count"]);
			Debug.Log ((long)json["watcher_count"]);
			Debug.Log ((long)json["turn_player"]);
			Debug.Log ((string)json["state"]);
			Debug.Log("WWW Ok!: ");

		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
	}
}