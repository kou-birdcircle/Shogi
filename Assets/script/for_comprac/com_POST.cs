using UnityEngine;
using System.Collections;

public class com_POST : MonoBehaviour {


	IEnumerator Start () {
		string url = "http://192.168.3.83:3000/users/logout.json";
		WWWForm form = new WWWForm();
		form.AddField("name", "to");
		form.AddField("room_no", "1");
		WWW www = new WWW(url, form);
		yield return www;
		if (www.error == null) {
			Debug.Log(www.text);
		}
	}
}
