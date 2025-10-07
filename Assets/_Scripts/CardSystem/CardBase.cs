using UnityEngine;

public abstract class CardBase : MonoBehaviour
{
    [Header("Base stats")]
    [SerializeField] private int toughness;
    [SerializeField] private int might;


    public void TakeDamage()
    {

    }


    protected virtual void Die()
    {
        Destroy(gameObject);
    }



    public virtual void Attack(CardBase target)
    {
        TakeDamage();
    }
 


}
