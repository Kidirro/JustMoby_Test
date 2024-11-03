using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class ResourceBinder : MonoBehaviour
{
    [SerializeField]
    private SaleWindowComponent defaultSaleWindowComponent;

    [SerializeField]
    private ItemComponent defaultItemComponent;


    private static Dictionary<Type, Object> _bindedObjects = new Dictionary<Type, object>();

    private void Awake()
    {
        BindSaleWindow();
        BindItemComponent();
    }

    private void BindSaleWindow()
    {
        _bindedObjects[typeof(SaleWindowComponent)] = defaultSaleWindowComponent;
    }

    private void BindItemComponent()
    {
        _bindedObjects[typeof(ItemComponent)] = defaultItemComponent;
    }

    public static Object GetBindedObject(Type type)
    {
        if (type == null) return null;
        return _bindedObjects.TryGetValue(type, out var value) ? value : null;
    }
    
}
