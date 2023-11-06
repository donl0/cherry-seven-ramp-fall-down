using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "level/Playable list")]
public class PlayableLevels: ScriptableObject
{
    List<Level> _levels = new List<Level>();
}