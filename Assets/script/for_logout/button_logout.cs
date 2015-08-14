using UnityEngine;
using System.Collections;
public class button_logout : MonoBehaviour {
	string pid = button_info.pid;
	string uid = button_info.uid;
	
	public void send(){
		StartCoroutine (logout());
	}

	private IEnumerator logout() {
		string url = "http://192.168.3.83:3000/users/logout.json";
		WWWForm form = new WWWForm();
		form.AddField("play_id", pid);
		form.AddField("user_id", uid);
		WWW www = new WWW(url, form);
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
		}
		Application.LoadLevel("login");
	}
}