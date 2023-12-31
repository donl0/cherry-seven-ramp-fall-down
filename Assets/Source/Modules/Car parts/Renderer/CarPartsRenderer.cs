using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPartsRenderer : BaseRenderView<CarType>
{
    [SerializeField] private CarPartView _partViewTemplate;
    [SerializeField] private InventoryCarPartsHandler _partsHandler;

    [SerializeField] private GameObject _container;
    
    private const int _partsCount = 3;
    
    private List<CarPartView> _partsView;
    private CarPartWithCarType _carPartWithCarType;

    public void Init(Transform container, InventoryCarPartsHandler partsHandler)
    {
        _partsHandler = partsHandler;
        Init(container);
    }

    public void Init(Transform container)
    {
        BaseInit(container);
    }

    public void BaseInit(Transform container)
    {
        _carPartWithCarType = new CarPartWithCarType();
        _partsView = new List<CarPartView>();
        CreateParts(container);
    }

    public void Show()
    {
        _container.SetActive(true);
    }

    public void Hide()
    {
        _container.SetActive(false);
    }

    public override void Render(CarType car)
    {
        int renderedCount = 0;
        
        List<CarPart> parts = _carPartWithCarType.GetParts(car);

        for (int renderIndex = 0; renderIndex < parts.Count; renderIndex++)
        {
            _partsView[renderIndex].Render(parts[renderIndex]);
            _partsView[renderIndex].gameObject.SetActive(true);
            renderedCount = renderIndex;
            renderedCount += 1;
        }

        TryDisableNotRendered(renderedCount);
    }
    
    private bool TryDisableNotRendered(int renderedCount)
    {
        if (renderedCount < _partsCount)
        {
            for (int count = renderedCount; count < _partsCount; count++)
            {
                _partsView[count].gameObject.SetActive(false);
            }

            return true;
        }

        return false;
    }

    private void CreateParts(Transform container)
    {
        for (int spawned = 0; spawned < _partsCount; spawned++)
        {
            var partView = Instantiate(_partViewTemplate, container);
            partView.Init(_partsHandler);
            _partsView.Add(partView);
        }
    }
}
