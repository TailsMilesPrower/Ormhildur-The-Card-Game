using UnityEngine;

public abstract class CardBase : MonoBehaviour
{
    [Header("Visual Elements")]
    public string name;
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

    protected void Awake()
    {
        cardAwake();
    }

    protected virtual void cardAwake()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        spriterenderer.sprite = cardImage[0];
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
            if (cardImage.Length-curretToughness >= 0)
            {
                spriterenderer.sprite = cardImage[cardImage.Length-1-curretToughness];
            }
            else
            {
                spriterenderer.sprite = cardImage[0];
            }
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

    public virtual int Attack(int target)
    {
        target -= might;
        return target;
    }
 


}
