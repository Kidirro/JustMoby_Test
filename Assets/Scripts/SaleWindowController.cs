using UnityEngine;
using UnityEngine.Events;

public class SaleWindowController
{
    private const int ITEM_ROW_COUNT = 3;

    public void ShowWindow(SaleWindowData data)
    {
        SaleWindowComponent windowComp =GameObject.Instantiate((SaleWindowComponent)ResourceBinder.GetBindedObject(typeof(SaleWindowComponent))).GetComponent<SaleWindowComponent>();
        ItemComponent itemComp = (ItemComponent)ResourceBinder.GetBindedObject(typeof(ItemComponent));

        windowComp.SetHeaderText(data.HeaderText);
        windowComp.SetDescriptionText(data.DescriptionText);

        windowComp.SetBigImageSprite(IconController.GetIcon(data.BigIconName));
        
        windowComp.SetOnButtonClick(()=> Object.Destroy(windowComp.gameObject));

        bool isEnableDiscount = data.Discount > 0;
        windowComp.SetPriceText(data.Price.ToString("F2"));
        windowComp.ShowDiscountLabels(isEnableDiscount);

        Transform lastRow = windowComp.GetRowTransform();
        for (int i = 0; i < data.Items.Length; i++)
        {
            if (i % ITEM_ROW_COUNT == 0)
            {
                lastRow = GameObject.Instantiate(windowComp.GetRowTransform(), windowComp.GetItemComponentParent());
                lastRow.gameObject.SetActive(true);
            }
            
            ItemComponent component = GameObject.Instantiate(itemComp, lastRow).GetComponent<ItemComponent>();
            component.SetImageSprite(IconController.GetIcon(data.Items[i].Name));
            component.SetCountText(data.Items[i].Count.ToString());
        }

        if (!isEnableDiscount) return;
        windowComp.SetDiscountText("-" + data.Discount + "%");
        windowComp.SetOriginalPriceText((data.Price / 100 * (100 + data.Discount)).ToString("F2"));
    }
}

public struct SaleWindowData
{
    public string HeaderText;
    public string DescriptionText;
    public ItemData[] Items;
    public float Price;
    public float Discount;
    public string BigIconName;

    public struct ItemData
    {
        public string Name;
        public int Count;
    }
}