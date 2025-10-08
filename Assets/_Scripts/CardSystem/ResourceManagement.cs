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

    public bool CanPlayCard(int cost)
    {
        return currentStamina >= cost;
    }
    
    public bool SpendStamina(int cost)
    {
        if (!CanPlayCard(cost)) return false;

        currentStamina -= cost;
        onStaminaChanged?.Invoke(currentStamina, maxStamina); 
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
