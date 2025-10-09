using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlots : MonoBehaviour, IDropHandler
{
    [SerializeField] private CardManger manager;
    private ResourceManagement reManager;
    public int postion;
    public GameObject kickPoint;

    void Start()
    {
        reManager = manager.reManagment;
    }
    public void OnDrop(PointerEventData eventData)
    {
        
        if (eventData.pointerDrag != null  )
        {
            CardBase cardBase = eventData.pointerDrag.GetComponent<CardBase>();
            if (manager.playerTurn == true && reManager.CanPlayCard(cardBase.GiveCost()))
            {

                Debug.Log(gameObject.name);
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; 
                eventData.pointerDrag.GetComponent<CardPlacement>().enabled = false;
                cardBase.PlacingCard(manager);
                manager.playerTable[postion] = cardBase;
                reManager.SpendStamina(cardBase.GiveCost());
            }
            else
            {
                eventData.pointerDrag.GetComponent<RectTransform>().position = kickPoint.transform.position;
            }
        }
    }
}
