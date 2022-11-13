using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data", fileName = "User")]
public class User : ScriptableObject
{
    public string name;
    public Names friends;
    
}