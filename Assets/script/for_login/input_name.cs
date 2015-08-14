using UnityEngine;

public class input_name : MonoBehaviour 
{
	public string text = "";
	void OnGUI()
	{
		Rect rect1 = new Rect(50, 200, 200, 30);
		text = GUI.TextField(rect1, text, 16);
	
	}
}