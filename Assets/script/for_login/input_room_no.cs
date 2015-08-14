using UnityEngine;

public class input_room_no : MonoBehaviour 
{
	public string text = "";
	void OnGUI()
	{
		Rect rect1 = new Rect(400, 200, 200, 30);
		text = GUI.TextField(rect1, text, 16);
		
	}
}