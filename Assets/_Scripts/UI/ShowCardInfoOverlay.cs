using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowCardInfoOverlay : MonoBehaviour
{
    [Header("UI References")]
    public GameObject overlayPanel;
    public TMP_Text cardNameText;
    public TMP_Text cardDescriptionText;
    public TMP_Text cardCostText;
    public Image cardArtworkImage;

    [Header("Preview Settings")]
    public GameObject cardPreviewPanel;
    public Image cardPreviewImage;
    public float previewScale = 2f;

    private CardInfo currentCard;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (overlayPanel != null)
        {
            overlayPanel.SetActive(false);
        }

        if (cardPreviewPanel != null)
        {
            cardPreviewPanel.SetActive(false);
        }

    }

    public void ShowCardInfoFromPrefab(GameObject cardPrefab)
    {
        if (cardPrefab == null)
        {
            Debug.LogWarning("CardInfoOverlay: No card prefab provided");
            return;
        }

        
        CardInfo cardInfo = GetCardInfoFromPrefab(cardPrefab);
        if (cardInfo == null)
        {
            Debug.LogWarning("CardInfoOverlay: No cardInfo component found");
            return;
        }
        

        currentCard = cardInfo;
        ShowCardInfo(cardInfo);

    }


    public void ShowCardInfo(CardInfo cardInfo)
    {
        if (overlayPanel != null)
        {
            overlayPanel.SetActive(true);
        }

        if (cardNameText != null)
        {
            cardNameText.text = cardInfo.cardName;
        }

        if (cardDescriptionText != null)
        {
            cardDescriptionText.text = cardInfo.description;
        }

        if (cardCostText != null)
        {
            cardCostText.text = $"Cost: {cardInfo.cost}";
        }

        if (cardArtworkImage != null && cardInfo.artwork != null)
        {
            cardArtworkImage.sprite = cardInfo.artwork;
        }

    }

    public void HideCardInfo()
    {
        if (overlayPanel != null)
        {
            overlayPanel.SetActive(false);
        }
    }
    public void ShowCardPreviewFromPrefab(GameObject cardPrefab)
    {
        if (cardPrefab == null || cardPreviewPanel == null || cardPreviewImage == null) return;

        Debug.Log(" im on step 1");
        CardInfo cardInfo = GetCardInfoFromPrefab(cardPrefab);
        if (cardInfo == null)
        {
            Debug.LogWarning($"ShowCardInfoOverlay: No CardInfo found on {cardPrefab.name}.");
            return;
        }
        

        currentCard = cardInfo;


        cardPreviewPanel.SetActive(true);
        cardPreviewImage.sprite = cardInfo.artwork;

        cardPreviewImage.SetNativeSize();
        cardPreviewImage.rectTransform.localScale = Vector3.one * previewScale;

    }

    public void HideCardPreview()
    {
        if (cardPreviewPanel != null)
        {
            cardPreviewPanel.SetActive(false);
        }
    }

    
    private CardInfo GetCardInfoFromPrefab(GameObject cardPrefab)
    {
        CardBase cardBase = cardPrefab.GetComponent<CardBase>();
        CardInfo info = new CardInfo();

        Debug.Log("im on step 2");

        info.artwork = cardPrefab.GetComponent<Image>().sprite;
        info.description = cardBase.GiveDescription();
        info.cardName = cardBase.GiveName();
        info.cost = cardBase.GiveCost();

        if (info != null) return info;
        return null;
    }
    

   [System.Serializable]
    public class CardInfo
    {
        public string cardName;
        public string description;
        public int cost;
        public Sprite artwork;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
