using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EditorInitWindow : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField headerField;
    
    [SerializeField]
    private TMP_InputField descriptionField;
    
    [SerializeField]
    private TMP_InputField bigIconField;
    
    [Space,SerializeField]
    private TMP_InputField priceField;
    
    [SerializeField]
    private TMP_InputField discountField;

    [Space, SerializeField]
    private List<ItemInputFields> itemInputFieldsList;

    [Space,SerializeField]
    private Button createWindow;
    
    private void Start()
    {
        createWindow.onClick.AddListener(OnCreateWindowClick);
    }

    private void OnCreateWindowClick()
    {
        var rawItems = new List<SaleWindowData.ItemData>();
        foreach (var itemFields in itemInputFieldsList)
        {
            if (itemFields.Name.text == "") continue;

            rawItems.Add(new SaleWindowData.ItemData()
            {
                Name = itemFields.Name.text,
                Count = int.TryParse(itemFields.Count.text, out var countValue) ? countValue : 0
            });
        }

        new SaleWindowController().ShowWindow(new SaleWindowData()
        {
            HeaderText = headerField.text,
            DescriptionText = descriptionField.text,
            Price = float.TryParse(priceField.text, out var valuePrice) ? valuePrice : 0,
            Discount = float.TryParse(discountField.text, out var valueDiscount) ? valueDiscount : 0,
            BigIconName = bigIconField.text,
            Items = rawItems.ToArray()
        });
    }

    [Serializable]
    private class ItemInputFields
    {
        public TMP_InputField Name;
        public TMP_InputField Count;
    }
}
