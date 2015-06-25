// LookbackBuildPostProcess.cs
// lookback_unity_ios_plugin
// Author: Andrew Lee
// Copyright (C) 2015 INVIVO Communications Inc.
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
public class LookbackBuildPostProcess {

	private const string lookbackSDKSubpath = "/Lookback_ObjC/lookback";
	private const string copiedTargetFolderName = "/lookback";
	private const string postProcessScriptPath = "Assets/Editor/Lookback/lookback_post_process.py";
	private const string postProcessScriptFilename = "lookback_post_process.py";

	[PostProcessBuild]
	public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject) {
		if(target == BuildTarget.iOS) {
			// Copy lookback SDK folder to built project directory
			string lookbackSDKPath = Application.dataPath + lookbackSDKSubpath;
			DirectoryCopy(lookbackSDKPath, pathToBuiltProject + copiedTargetFolderName, true);

			// Execute script to configure Xcode project
			Process p = new Process();
			p.StartInfo.FileName = "python";
			p.StartInfo.Arguments = string.Format(postProcessScriptPath + " \"{0}\"", pathToBuiltProject);
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.RedirectStandardOutput = true;
			p.Start();
			UnityEngine.Debug.Log (p.StandardOutput.ReadToEnd());
			p.WaitForExit();
		}
	}

	// https://msdn.microsoft.com/en-us/library/bb762914%28v=vs.110%29.aspx
	private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
	{
		DirectoryInfo dir = new DirectoryInfo(sourceDirName);
		DirectoryInfo[] dirs = dir.GetDirectories();
		
		if (!dir.Exists)
		{
			throw new DirectoryNotFoundException(
				"Source directory does not exist or could not be found: "
				+ sourceDirName);
		}

		if (!Directory.Exists(destDirName))
		{
			Directory.CreateDirectory(destDirName);
		}

		var files = dir.GetFiles().Where (file => !file.FullName.EndsWith(".meta"));		// Do not copy the meta files

		foreach (FileInfo file in files)
		{
			string temppath = Path.Combine(destDirName, file.Name);
			file.CopyTo(temppath, false);
		}

		if (copySubDirs)
		{
			foreach (DirectoryInfo subdir in dirs)
			{
				string temppath = Path.Combine(destDirName, subdir.Name);
				DirectoryCopy(subdir.FullName, temppath, copySubDirs);
			}
		}
	}
}
