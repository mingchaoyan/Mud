using UnityEngine;
using System.Collections;

public class GameMain : MonoBehaviour
{
	bool isChatting = true;
	public Vector2 scrollPosition;

	public float scrollVelocity = 0f;
	public float timeTouchPhaseEnded = 0f;
	public float inertiaDuration = 0.5f;
	public Vector2 lastDeltaPos;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.timeScale > 0 && Input.GetKeyDown (KeyCode.Escape)) {
			Time.timeScale = 0;
		}
		UpdateHandleTouch ();
	}

	void UpdateHandleTouch ()
	{
		if (Input.touchCount > 0) {
			if (Input.GetTouch (0).phase == TouchPhase.Moved) {
				scrollPosition.y += Input.GetTouch (0).deltaPosition.y;
				lastDeltaPos = Input.GetTouch (0).deltaPosition;
			} else if (Input.GetTouch (0).phase == TouchPhase.Ended) {
				print ("End:" + lastDeltaPos.y + "|" + Input.GetTouch (0).deltaTime);
				if (Mathf.Abs (lastDeltaPos.y) > 20.0f) {
					scrollVelocity = (int)(lastDeltaPos.y * 0.5 / Input.GetTouch (0).deltaTime);
					print (scrollVelocity);
				}
				timeTouchPhaseEnded = Time.time;
			}
		} else {
			if (scrollVelocity != 0.0f) {
				// slow down
				float t = (Time.time - timeTouchPhaseEnded) / inertiaDuration;
				float frameVelocity = Mathf.Lerp (scrollVelocity, 0, t);
				scrollPosition.y += frameVelocity * Time.deltaTime;
				
				if (t >= inertiaDuration)
					scrollVelocity = 0;
			}
		}
	}

	void OnGUI ()
	{
		float ratioW = System.Convert.ToSingle (Screen.width) / 540f;
		float ratioH = System.Convert.ToSingle (Screen.height) / 960f;
		GUI.matrix = Matrix4x4.TRS (new Vector3 (0, 0, 0), 
		                            Quaternion.identity, new Vector3 (ratioW, ratioH, 1));
		if (!isChatting || Time.timeScale == 0) {
			MainMenu ();
		} else {
			Chat ();
		}
		GUI.matrix = Matrix4x4.identity;
	}

	void MainMenu ()
	{
		GUI.skin.label.fontSize = 40;
		GUI.skin.label.alignment = TextAnchor.LowerCenter;
		GUI.Label (new Rect (540f / 3f, 960f / 20f, 
		                     540f / 2f, 960f / 10f), "反贼，哪里跑");
		
		GUI.skin.button.fontSize = 40;
		if (GUI.Button (new Rect (540f / 3f, 960f * 8 / 10f, 
		                          540f / 3f, 960f / 15f), "开始游戏")) {
			Time.timeScale = 1;

			//Application.LoadLevel ("level1");
			isChatting = true;
		}
	}

	void Chat ()
	{
		GUILayout.BeginArea (new Rect (0, 0, 540, 960));
		scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (540), GUILayout.Height (960));
		GUI.color = Color.green;
		for (int i=0; i<300; ++i) {
			GUILayout.BeginHorizontal ();
			GUI.skin.label.fontSize = 25;
			GUI.skin.label.alignment = TextAnchor.UpperLeft;
			if (i % 2 != 0) {
				GUILayout.Space (100);	
			}
			GUILayout.Label ("反贼fffffffffffffffffffffffffbbbbbbaaaaaasdfffffffffffffffffffffffffffffff");
			if (i % 2 == 0) {
				GUILayout.Space (100);	
			}
			GUILayout.EndHorizontal ();
		}
		GUILayout.EndScrollView ();
		GUILayout.EndArea ();
	}

	void DestroyMainMenu ()
	{

	}
}
