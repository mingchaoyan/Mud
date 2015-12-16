using UnityEngine;
using System.Collections;

public class Message
{
	public int sender = 0; // 0 系统  1 主角   2 配角a 3 配角b  
	public string content = "";

	public Message (int sender, string content)
	{
		this.sender = sender;
		this.content = content;
	}
}
