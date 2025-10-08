using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer))]
public class CardHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Highlight Settings")]
    public Color highlightColor = Color.green;
    public Color unavailableColor = Color.red;
    public Color normalColor = Color.white;
    public int cardCost = 0;

    [Header("References")]
    public ResourceManagement resourceManagement;

    private SpriteRenderer spriteRenderer;
    private bool isHovering = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null ) spriteRenderer.color = normalColor;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (isHovering)
       {
            UpdateHighlight();
       }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        UpdateHighlight();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        spriteRenderer.color = normalColor;
    }


    private void UpdateHighlight()
    {
        if (resourceManagement == null)
        {
            return;
        }

        if (resourceManagement.CanPlayCard(cardCost))
        {
            spriteRenderer.color = highlightColor;
        }
        else
        {
            spriteRenderer.color= unavailableColor;
        }

    }


}
