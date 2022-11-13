using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEngine;

public static class AI
{
    public static string fix(String str)
    {
        return str.ToLower().Replace("\n", " ");
    }
    
#if UNITY_EDITOR

    private static StreamReader reader;
    private static StreamWriter writer;
    private static Process process;
    public static void Start()
	{
		try {
	        ProcessStartInfo start = new ProcessStartInfo();
	        start.FileName = "/Library/Frameworks/Python.framework/Versions/3.10/bin/python3";
	        start.Arguments = "/Users/luke/Documents/GitHub/HackUTD-2022/Assets/Scripts/AI/BERT.py";
	        start.UseShellExecute = false;
	        start.RedirectStandardInput = true;
	        start.RedirectStandardOutput = true;
	        start.CreateNoWindow = true;
	
	        Process process = Process.Start(start); 
	        
	        reader = process.StandardOutput;
			writer = process.StandardInput;
		}
		catch (Exception e) {
			
		}
    }
    
    public static float[] Run(string input, List<string> tests)
    {
        writer.Write($"{tests.Count}\n{fix(input)}\n");
        for (int i = 0; i < tests.Count; i++)
            writer.Write($"{fix(tests[i])}\n");
        
	    string line = reader.ReadLine().TrimEnd(':');
	    UnityEngine.Debug.LogWarning(line);
        var l = line.Split(":").Select(s => float.Parse(s));
        return l.ToArray();
    }
#endif
}
