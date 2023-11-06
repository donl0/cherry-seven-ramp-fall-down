using System;
using UnityEngine;

[Serializable]
internal class LevelInfo
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Level _level;

    public string Name => _name;
    public Sprite Sprite => _sprite;
    public Level Level => _level;
}