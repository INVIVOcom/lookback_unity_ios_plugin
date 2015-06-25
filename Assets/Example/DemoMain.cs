// DemoMain.cs
// lookback_unity_ios_plugin
// Author: Andrew Lee
// Copyright (C) 2015 INVIVO Communications Inc.
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DemoMain : MonoBehaviour {

	private const string LOOKBACK_SDK_TOKEN = "SDK_TOKEN";

	public MeshRenderer cube;

	// Use this for initialization
	void Start () {
		Lookback.InitializeLookback(LOOKBACK_SDK_TOKEN);
		Lookback.SetShakeToRecord(true);
		Lookback.SetFeedbackBubbleVisible(true);

		Lookback.SetFeedbackBubbleBackgroundColour(255, 0, 0, 255);
		Lookback.SetFeedbackBubbleBackgroundColour(0, 255, 0, 255);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnRed() {
		cube.material.color = Color.red;
	}

	public void OnGreen() {
		cube.material.color = Color.green;
	}

	public void OnBlue() {
		cube.material.color = Color.blue;

	}
}
