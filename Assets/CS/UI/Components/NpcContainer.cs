﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Game;

public class NpcContainer : MonoBehaviour {
	public Text Name;
	public Image State;
	public Button ClickButton;
	Image icon;
	NpcData npcData;
	// Use this for initialization
	void Awake () {
		icon = GetComponent<Image>();
		Name.text = "";
		State.gameObject.SetActive(false);
		EventTriggerListener.Get(ClickButton.gameObject).onClick += onClick;
	}

	void onClick(GameObject e) {
		Debug.LogWarning(npcData.Name);
	}

	public void UpdateData(NpcData data) {
		npcData = data;
	}

	public void RefreshView() {
		Name.text = npcData.Name;
		icon.sprite = Statics.GetIconSprite(npcData.IconId);
	}

	public void SetNpcData(NpcData data) {
		UpdateData(data);
		RefreshView();
	}
}
