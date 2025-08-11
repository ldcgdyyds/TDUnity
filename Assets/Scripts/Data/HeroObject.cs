using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="HeroObject")]
public class HeroObject : ScriptableObject
{
    public string heroName;
    public List<string> weaponNames;
}
