using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class levelEditor : EditorWindow {
	public int newID;
	[MenuItem("Window/Level Editor")]
	public static void ShowLevelEditor(){
		EditorWindow.GetWindow(typeof(levelEditor));

	}
	void OnGUI() {
		GUILayout.Label ("Create New Level", EditorStyles.boldLabel);
		

	}
}
