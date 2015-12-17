using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
//	public Vector2 scrollPosition;
//	public string longString = "This is a long-ish string";
//	void OnGUI ()
//	{
//		scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (100), GUILayout.Height (100));
//		GUILayout.Label (longString);
//		if (GUILayout.Button ("Clear"))
//			longString = "";
//		
//		GUILayout.EndScrollView ();
//		if (GUILayout.Button ("Add More Text")) {
//			longString += "\nHere is another line";
//			scrollPosition.y += 999;
//		}
//	}

	public float timer = 1.0f;
	
	// Update is called once per frame
	void Update ()
	{
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Debug.Log (string.Format ("Timer1 is up !!! time=${0}", Time.time));
			timer = 1.0f;
		}
	}
}