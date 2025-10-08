using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Turn", menuName = "turnSegement",order =1)]
public class EnemyMoves : ScriptableObject
{
    public enum enemyMove
    {
        cardPlacing,
        dialogue
    }

    public enum persons
    {
        kolsky,
        ormhilder
    }
    public enemyMove type;
    public bool waitUnitilAllIsDead;
    public GameObject[] cardsPlacement;
    public persons[] speaker;
    public Sprite[] facailExprestion;
    public string[] diaglouge;
}
