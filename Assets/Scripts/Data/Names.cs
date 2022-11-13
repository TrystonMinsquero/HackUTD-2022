
using System.Text;
using UnityEngine;


[System.Serializable]
public class Names
{
    [Tooltip("Paste names seperated by new lines")]
    [SerializeField] [TextArea(1, 5)] public string namesText;

    private string[] _names;

    public string[] GetNames()
    { 
        return namesText.Split('\n');
    }
    

    public bool Contains(string name)
    {
        foreach (var n in GetNames())
        {
            if (name == n) return true;
        }

        return false;
    }
}
