using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SaleWindowComponent : MonoBehaviour
{
   [SerializeField]
   private TMP_Text headerLabel;
   
   [SerializeField]
   private TMP_Text descriptionLabel;

   [Space,SerializeField]
   private TMP_Text priceLabel;

   [SerializeField]
   private TMP_Text originalPriceLabel;

   [SerializeField]
   private TMP_Text discountLabel;

   [SerializeField]
   private GameObject discountMainObject;

   [Space,SerializeField]
   private Image bigIcon;
   
   [Space,SerializeField]
   private Transform itemMainLayoutParent;

   [SerializeField]
   private Transform rowTransform;

   [Space, SerializeField]
   private Button saleButton;

   public void SetHeaderText(string text)
   {
      headerLabel.text = text;
   }

   public void SetDescriptionText(string text)
   {
      descriptionLabel.text = text;
   }

   public void SetPriceText(string text)
   {
      priceLabel.text = text;
   }

   public void SetOriginalPriceText(string text)
   {
      originalPriceLabel.text = text;
   }

   public void SetDiscountText(string text)
   {
      discountLabel.text = text;
   }

   public void ShowDiscountLabels(bool visibility)
   {
      originalPriceLabel.gameObject.SetActive(visibility);
      discountMainObject.SetActive(visibility);
   }

   public void SetBigImageSprite(Sprite sprite)
   {
      bigIcon.sprite = sprite;
   }

   public Transform GetItemComponentParent()
   {
      return itemMainLayoutParent;
   }

   public Transform GetRowTransform()
   {
      return rowTransform;
   }

   public void SetOnButtonClick(UnityAction action)
   {
      saleButton.onClick.AddListener(action);
   }
}
