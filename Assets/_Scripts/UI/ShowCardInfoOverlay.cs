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
    public Sprite cardArtworkImage;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (overlayPanel != null)
        {
            overlayPanel.SetActive(false);
        }
    }

    public void ShowCardInfo(CardInfo cardInfo)
    {
        if(cardInfo == null)
        {
            Debug.LogWarning("CardInfoOverlay: No card info provided");
            return;
        }

        if (overlayPanel != null)
        {
            overlayPanel.SetActive(true);
        }

        if(cardNameText != null)
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

        if (cardArtworkImage != null && cardInfo.artwork !=null)
        {
            cardArtworkImage = cardInfo.artwork;
        }

    }

    public void HideCardInfo()
    {
        if (overlayPanel != null)
        {
            overlayPanel.SetActive(false);
        }
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
