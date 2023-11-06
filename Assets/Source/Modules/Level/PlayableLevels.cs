using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(menuName = "level/Playable list")]
public class PlayableLevels: ScriptableObject
{
    [SerializeField] private List<Level> _levels = new List<Level>();
    
    public ReadOnlyCollection<Level> Levels => new ReadOnlyCollection<Level>(_levels);
}