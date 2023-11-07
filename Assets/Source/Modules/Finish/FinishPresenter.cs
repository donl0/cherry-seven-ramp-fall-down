using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPresenter : MonoBehaviour
{
    [SerializeField] private CarTrigger _trigger;

    private void OnEnable()
    {
        _trigger.Enter += OnEntered;
    }

    private void OnDisable()
    {
        _trigger.Enter -= OnEntered;
    }

    private void OnEntered(Car arg0)
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
