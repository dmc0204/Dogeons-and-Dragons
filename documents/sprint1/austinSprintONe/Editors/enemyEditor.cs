using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class enemyEditor : EditorWindow {
	public float newID, newAttack, newDefense, newSpeed, newHealth;
	public string newName, newSpriteName;
	public Item[] newDrops;
	public Image newSprite;
	[MenuItem("Window/Enemy Editor")]
	public static void ShowEnemyEditor(){
		EditorWindow.GetWindow(typeof(enemyEditor));

	}
	void OnGUI() {
		GUILayout.Label ("Create New Enemy", EditorStyles.boldLabel);
		newName = EditorGUILayout.TextField ("Enemy Name", newName);
		newAttack = EditorGUILayout.Slider ("Attack", newAttack, 0, 10);
		newDefense = EditorGUILayout.Slider("Defense", newDefense, 0, 10);
		newSpeed = EditorGUILayout.Slider("Speed", newSpeed, 0, 10);
		newHealth = EditorGUILayout.Slider("Heath", newHealth, 0, 100);
		newSpriteName = EditorGUILayout.TextField("Sprite Filename", newSpriteName);
		if(GUILayout.Button ("Submit")) {
			new Enemy(1, newName, newAttack, newDefense, newSpeed, newHealth, newDrops, newSprite);
		}
		
	}
}
