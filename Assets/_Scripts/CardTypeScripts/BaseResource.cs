using UnityEngine;

public class BaseResource : CardBase
{

    public override void Attack(CardBase target)
    { 
       if(manger.reManagment.currentStamina+ might <= manger.reManagment.maxStamina)
       {

            manger.reManagment.currentStamina += might;
       }
        else
        {
            int overStamina = manger.reManagment.currentStamina+might-manger.reManagment.maxStamina;
            manger.reManagment.currentStamina += (might - overStamina);
        }
    }
}
