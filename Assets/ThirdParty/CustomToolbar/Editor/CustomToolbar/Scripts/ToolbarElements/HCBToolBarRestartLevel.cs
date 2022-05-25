using System;
using UnityEngine;
using UnityEditor;
using UnityToolbarExtender;
using HCB.Core;

[Serializable]
internal class HCBToolBarRestartLevel : BaseToolbarElement
{
	private static GUIContent reloadSceneBtn;

	public override string NameInList => "[Button] HCB Reload scene";

	public override void Init()
	{
		reloadSceneBtn = new GUIContent((Texture2D)AssetDatabase.LoadAssetAtPath($"{GetPackageRootPath}/Editor/CustomToolbar/Icons/RestartButtonIcon.png", typeof(Texture2D)), "Reload scene");
	}

	protected override void OnDrawInList(Rect position)
	{

	}

	protected override void OnDrawInToolbar()
	{
		if (!Application.isPlaying)
			return;

		EditorGUIUtility.SetIconSize(new Vector2(17, 17));
		if (GUILayout.Button(reloadSceneBtn, ToolbarStyles.commandButtonStyle))
		{
			if (EditorApplication.isPlaying)
			{
				LevelManager.Instance.ReloadLevel();
			}
		}
	}
}
