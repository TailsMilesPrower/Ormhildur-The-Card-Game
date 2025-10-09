using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardPlacement : MonoBehaviour,IPointerDownHandler,IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{    
    [Header("Placement Settings")]
    
    public string validCardTag = "Card";
    public Vector2 placementOffset = new Vector2(0.2f, 0f);
    private int maxCards = 6;
    private int currentCardCount = 0;
    [HideInInspector]
    public bool isPlaced = false;
    SpriteRenderer cardShow;


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
    public ShowCardInfoOverlay overlay;

    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();

        if (overlay == null )
        {
            overlay = FindFirstObjectByType<ShowCardInfoOverlay>();
        }

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Debug.Log("Lift");
            cardShow.sprite = null;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (eventData.pointerDrag != null)
            {
                GameObject card = eventData.pointerDrag.GetComponent<GameObject>();
                if(card != null)
                {
                    Debug.Log(card.name);
                }
                Image cardBase = card.GetComponent<Image>();  
                if (cardBase != null) 
                { 
                    cardShow.sprite =  cardBase.sprite;
                    Debug.Log("onClick");
                }
            }
               
            
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {

        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (eventData.pointerDrag != null)
            {

                Image cardBase = eventData.pointerDrag.GetComponent<Image>();
                if (cardBase != null)
                {
                    cardShow.sprite = cardBase.sprite;
                    Debug.Log("onClick");
                }
            }


        }
        if (isPlaced == false)
        {
            canvasGroup.alpha = 0.7f;
            canvasGroup.blocksRaycasts = false;
        }
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (isPlaced == false)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isPlaced == false) 
        { 
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            //currentCardCount--;
        }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardShow = GameObject.FindGameObjectWithTag("easy").GetComponent<SpriteRenderer>();
        cardShow.sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
