using UnityEngine;
using UnityEngine.Events;

public class ResourceManagement : MonoBehaviour
{
    [Header("Stamina Settings")]
    public int maxStamina = 1000;
    public int currentStamina = 3;
    public int staminaGainPerRound = 1;

    [Header("Events")]
    public UnityEvent<int, int> onStaminaChanged;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        onStaminaChanged?.Invoke(currentStamina, maxStamina);
    }

    public bool CanPlayCard(int cardCost)
    {
        return currentStamina >= cardCost;
    }
    
    public bool SpendStamina(int cardCost)
    {
        if (!CanPlayCard(cardCost)) return false;

        currentStamina -= cardCost;
        onStaminaChanged?.Invoke(currentStamina, maxStamina); 
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
