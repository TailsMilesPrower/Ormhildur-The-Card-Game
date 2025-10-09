using UnityEngine;
using UnityEngine.EventSystems;

public class CardPlacement : MonoBehaviour,IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Placement Settings")]
    
    public string validCardTag = "Card";
    public Vector2 placementOffset = new Vector2(0.2f, 0f);
    private int maxCards = 6;
    private int currentCardCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(validCardTag)) return;

        PlaceCard(other.gameObject);

    }
    
    void PlaceCard(GameObject card)
    {
        Vector3 newPostion = transform.position + (Vector3) (placementOffset * currentCardCount);
        card.transform.position = newPostion;

        currentCardCount++;
    }

    //CardManager cardManager

    [Header("Drag Card")]
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("onClick");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.7f;
        canvasGroup.blocksRaycasts = false;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        //currentCardCount--;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
