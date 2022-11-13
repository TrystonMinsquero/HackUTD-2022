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
    public static float[] Run(string input, List<string> tests)
    {
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = "/usr/bin/python3";
        start.Arguments = "BERT.py";
        start.UseShellExecute = false;
        start.RedirectStandardInput = true;
        start.RedirectStandardOutput = true;
        start.CreateNoWindow = true;

        using (Process process = Process.Start(start)) 
        using (StreamReader reader = process.StandardOutput)
        using (StreamWriter writer = process.StandardInput)
        {
            writer.Write($"{tests.Count}\n{fix(input)}\n");
            for (int i = 0; i < tests.Count; i++)
                writer.Write($"{fix(tests[i])}\n");
            
            string line = reader.ReadLine();
            Console.WriteLine(line);
            var l = line.Split(":").Select(s => float.Parse(s));
            return l.ToArray();
        }

        return null;
    }
#endif
}
