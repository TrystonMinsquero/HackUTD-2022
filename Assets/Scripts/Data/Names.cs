
using UnityEngine;

[System.Serializable]
public struct Names
{
    [Tooltip("Paste names seperated by new lines")]
    [SerializeField] [TextArea(1, 5)] private string namesText;

    private string[] _names;

    public string[] GetNames()
    {
        if (_names == null)
        {
            _names = namesText.Split('\n');
        }

        return _names;
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