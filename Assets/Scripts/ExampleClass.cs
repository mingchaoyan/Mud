//using UnityEngine;
//using System.Collections;
//
//public class ExampleClass : MonoBehaviour
//{
//	//	public Vector2 scrollPosition;
//	//	public string longString = "This is a long-ish string";
//	//	void OnGUI ()
//	//	{
//	//		scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (100), GUILayout.Height (100));
//	//		GUILayout.Label (longString);
//	//		if (GUILayout.Button ("Clear"))
//	//			longString = "";
//	//
//	//		GUILayout.EndScrollView ();
//	//		if (GUILayout.Button ("Add More Text")) {
//	//			longString += "\nHere is another line";
//	//			scrollPosition.y += 999;
//	//		}
//	//	}
//
//	public float timer = 1.0f;
//	
//	// Update is called once per frame
//	void Update ()
//	{
//		timer -= Time.deltaTime;
//		if (timer <= 0) {
//			Debug.Log (string.Format ("Timer1 is up !!! time=${0}", Time.time));
//			timer = 1.0f;
//		}
//	}
//
//	void OnGUI ()
//	{
//		GUILayout.BeginHorizontal ();
//		GUILayout.Label ("谢谢");
//		GUILayout.HorizontalSlider (1.0f, 0f, 1.0f);
//		GUILayout.EndHorizontal ();
//	}
//}
//
using UnityEngine;

using System.Collections;



public class ExampleClass : MonoBehaviour
{



	//将准备好的MP3格式的背景声音文件拖入此处

	public AudioClip backgroundMusic;



	//将准备好的MP3格式的音效文件拖入此处

	public AudioClip palyOnceSound;



	//用于控制声音的AudioSource组件

	private AudioSource _audioSource;



	void Awake ()
	{

		//在添加此脚本的对象中添加AudioSource组件，此处为摄像机

		_audioSource = this.gameObject.AddComponent<AudioSource> ();

		//设置循环播放

		_audioSource.loop = true;

		//设置音量为最大，区间在0-1之间

		_audioSource.volume = 1.0f;

		//设置audioClip

		_audioSource.clip = backgroundMusic;

	}



	void OnGUI ()
	{

		//绘制播放按钮并设置其点击后的处理

		if (GUI.Button (new Rect (10, 10, 80, 30), "Play")) {

			//播放声音

			_audioSource.Play ();

		}



		//绘制暂停按钮并设置其点击后的处理

		if (GUI.Button (new Rect (10, 50, 80, 30), "Pause")) {

			//暂停声音，暂停后再播放，则声音为继续播放

			_audioSource.Pause ();

		}



		//绘制停止按钮并设置其点击后的处理

		if (GUI.Button (new Rect (10, 90, 80, 30), "Stop")) {

			//停止播放，停止后再播放，则声音为从头播放

			_audioSource.Stop ();

		}



		//绘制添加音效按钮,PlayOnShot方式添加音效

		if (GUI.Button (new Rect (100, 10, 120, 30), "AddSoound_Method_1")) {

			_audioSource.PlayOneShot (palyOnceSound);

		}



		//绘制添加音效按钮，PlayClipAtPoint方式添加音效

		if (GUI.Button (new Rect (100, 50, 120, 30), "AddSoun_Method_2")) {

			AudioSource.PlayClipAtPoint (palyOnceSound, _audioSource.transform.localPosition);

		}

	}

}