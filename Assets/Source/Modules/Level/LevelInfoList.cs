using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "level/Info list")]
public class LevelInfoList: ScriptableObject
{
    [SerializeField] private List<LevelInfo> _levels;

    public LevelInfo GetInfo(Level level)
    {
        var result = _levels.FirstOrDefault(l => l.Level == level);

        return result;
    }
}