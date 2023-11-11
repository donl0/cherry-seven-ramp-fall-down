using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelPresenter : BaseMainMenuPresenter, IDataSharer<Level>
{
    [SerializeField] private PlayableLevels _playableLevels;
    [SerializeField] private LevelInfoList _info;
    
    [SerializeField] private LevelView _levelViewTemplate;

    [SerializeField] private GameObject _mainScreen;
    [SerializeField] private Transform _levelContainer;

    [SerializeField] private InventoryCarPartsHandler _partsHandler;
    
    [SerializeField] private Dictionary<LevelView, Level> _spawnedView = new Dictionary<LevelView, Level>();

    public UnityAction<Level> ShareData { get; set; }

    private void Awake()
    {
        Spawn();
    }

    protected override void Activate()
    {
        base.Activate();
        _mainScreen.SetActive(true);
        RenderList();
        Sub();
    }

    protected override void Deactivate()
    {
        base.Deactivate();
        _mainScreen.SetActive(false);
        UnSub();
    }

    private void Spawn()
    {
        ReadOnlyCollection<Level> levels = _playableLevels.Levels;

        foreach (var level in levels)
        {
            var spawned = Instantiate(_levelViewTemplate, _levelContainer);
            spawned.GetComponentInChildren<LevelView>().Init(_partsHandler);
            _spawnedView.Add(spawned, level);
        }
    }

    private void RenderList()
    {
        ReadOnlyCollection<Level> levels = _playableLevels.Levels;

        foreach (var view in _spawnedView)
        {
            Render(view.Key, view.Value);
        }
    }

    private void Render(LevelView view, Level level)
    {
        view.Render(level);
    }

    private void Sub()
    {
        foreach (var view in _spawnedView)
        {
            Level level = view.Value;
            view.Key.Enter.onClick.AddListener(()=> Share(level));
        }
    }

    private void UnSub()
    {
        foreach (var view in _spawnedView)
        {
            Level level = view.Value;
            view.Key.Enter.onClick.RemoveListener(()=> Share(level));
        }
    }

    private void Share(Level level)
    {
        ShareData?.Invoke(level);
    }
}
