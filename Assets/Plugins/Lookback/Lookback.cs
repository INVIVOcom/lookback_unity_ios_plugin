// Lookback.cs
// lookback_unity_ios_plugin
// Author: Andrew Lee
// Copyright (C) 2015 INVIVO Communications Inc.
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public static class Lookback {

	[DllImport("__Internal")]
	public static extern void InitializeLookback(string sdkToken);

	[DllImport("__Internal")]
	public static extern void SetShakeToRecord(bool shakeToRecord);

	[DllImport("__Internal")]
	public static extern void SetFeedbackBubbleVisible(bool feedbackBubbleVisible);

	[DllImport("__Internal")]
	// Range between 0 and 255
	public static extern void SetFeedbackBubbleForegroundColour(float r, float g, float b, float a);

	[DllImport("__Internal")]
	// Range between 0 and 255
	public static extern void SetFeedbackBubbleBackgroundColour(float r, float g, float b, float a);

	[DllImport("__Internal")]
	public static extern void EnteredView(string viewIndentifier);

	[DllImport("__Internal")]
	public static extern void ExitedView(string viewIdentifier);

	[DllImport("__Internal")]
	public static extern bool ShakeToRecord();

	[DllImport("__Internal")]
	public static extern bool FeedbackBubbleVisible();
}
