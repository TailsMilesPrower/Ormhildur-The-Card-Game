using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlots : MonoBehaviour, IDropHandler
{
    [SerializeField] private CardManger manager;
    int postion;
    public void OnDrop(PointerEventData eventData)
    {
        
        if (eventData.pointerDrag != null)
        {
            Debug.Log(gameObject.name);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; 
            eventData.pointerDrag.GetComponent<CardPlacement>().enabled = false;
            eventData.pointerDrag.GetComponent<CardBase>().PlacingCard(manager);
            manager.playerTable[postion] = eventData.pointerDrag.GetComponent<CardBase>();
        }
    }
}
