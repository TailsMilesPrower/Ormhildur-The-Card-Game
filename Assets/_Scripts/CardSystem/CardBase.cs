using UnityEngine;

public abstract class CardBase : MonoBehaviour
{
    [Header("Visual Elements")]
    [SerializeField] protected string name;
    [Tooltip("card image for each health state where index zero is max health each state other state is place in order after that")]
    [SerializeField] protected Sprite[] cardImage;

    [Space(10)]
    [Header("Base stats")]
    [SerializeField] protected int toughness;
    [SerializeField] protected int might;
    [SerializeField] protected int price;

    protected int curretToughness;
    
    protected CardManger manger;
    protected SpriteRenderer spriterenderer;

    private void Awake()
    {
        spriterenderer = GetComponent<SpriteRenderer>();

    }

    public virtual void PlacingCard(CardManger cardManger)
    {
        curretToughness = toughness;
        manger = cardManger;
    }


    public virtual void TakeDamage(int damage)
    {
        curretToughness -= damage;
        if (curretToughness <= 0)
        {
            spriterenderer.sprite = cardImage[cardImage.Length-1];
            Die();
        }
        else
        {
            spriterenderer.sprite = cardImage[cardImage.Length-1-toughness];
        }
    }


    protected virtual void Die()
    {
        Destroy(gameObject);
    }



    public virtual void Attack(CardBase target)
    {
        target.TakeDamage(might);
    }
 


}
