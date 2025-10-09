using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardManger : MonoBehaviour
{
    public GameObject[] enemyPosition;
    private List<bool> freePosition = new List<bool>();
    
    [SerializeField] private int playerHealth;
    [SerializeField] private int enemyHealth;

    public bool playerTurn;
    public CardBase[] playerTable;
    public CardBase[] enemyTable;
    public EnemyMoves[] enemySegment;

    public ResourceManagement reManagment;

    // infomation so enemy know where it is in is turn order
    private int currentSegement = 0;
    private int currentMove =0;

    
    void Start()
    {
        for(int i = 0; enemyPosition.Length>i; i++)
        {
            freePosition.Add(true);
        }
        StartCoroutine(EnemyTurn());
    }

    private void Update()
    {
        UpdateSpace();
        if (enemySegment.Length<= currentSegement|| enemyHealth <= 0)
        {
            //load end scene
            Debug.Log("enemy lost game");
        }
        if(playerHealth <= 0)
        {
            //load death scene
            Debug.Log(" you lost the game");
        }

        if (playerTurn) 
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                playerTurn = false;
                for (int i = 0; i < playerTable.Length; i++)
                {

                    if (playerTable[i] != null)
                    {
                        CardBase target = FindTarget(i, enemyTable);
                        if (target != null)
                        {
                            playerTable[i].Attack(target);
                        }
                        else
                        {
                            enemyHealth = playerTable[i].Attack(enemyHealth);
                        }
                    }
                }
                StartCoroutine(EnemyTurn());
            }
        }
    }

    public IEnumerator EnemyTurn()
   {
        if (currentSegement < enemySegment.Length)
        {
            if (enemySegment[currentSegement].type == EnemyMoves.enemyMove.cardPlacing)
            {
                if (enemySegment[currentSegement].waitUnitilAllIsDead != true && currentMove != 0 || NoEnemyUnits() == true)
                {
                    while (AvaibleSpace())
                    {
                        if (enemySegment[currentSegement].cardsPlacement.Length > currentMove)
                        {
                            int[] spotLefts = AvaibleSpaceList();
                            GameObject newlyPlaceCard = Instantiate(enemySegment[currentSegement].cardsPlacement[currentMove]);

                            int randomNumber = Random.Range(0, spotLefts.Length);

                            newlyPlaceCard.transform.eulerAngles = new Vector3(0, 0, 180);

                            newlyPlaceCard.transform.position = enemyPosition[spotLefts[randomNumber]].transform.position;

                            enemyTable[spotLefts[randomNumber]] = newlyPlaceCard.GetComponent<CardBase>();
                            freePosition[spotLefts[randomNumber]] = false;

                            currentMove++;
                        }
                        else
                        {
                            currentSegement++;
                            break;
                        }


                        yield return new WaitForSeconds(1);
                    }
                }

                for (int i = 0; i < enemyTable.Length; i++)
                {

                    if (enemyTable[i] != null)
                    {
                        CardBase target = FindTarget(i, playerTable);
                        if (target != null)
                        {
                            enemyTable[i].Attack(target);
                        }
                        else
                        {
                            playerHealth = enemyTable[i].Attack(playerHealth);
                        }
                    }
                }
            }
            else
            {
                if (NoEnemyUnits())
                {

                }

            }

        }
        playerTurn = true;
    }

    private CardBase FindTarget(int index, CardBase[] defender)
    {
        if (index == 0 || index == 3)
        {
            if (defender[0] != null)
            {
                return defender[0];
            }
            else if (defender[3] != null)
            {
                return defender[3];
            }
        }
        else if (index == 1 || index == 4)
        {
            if (defender[1] != null)
            {
                return defender[1];
            }
            else if (defender[4] != null)
            {
                return defender[4];
            }
        }
        else if (index == 2 || index == 5)
        {
            if (defender[2] != null)
            {
                return defender[2];
            }
            else if (defender[5] != null)
            {
                return defender[5];
            }
        }
            return null;
    }
    private void UpdateSpace()
    {
        for(int i = 0;i < freePosition.Count; i++)
        {
            if (enemyTable[i] == null)
            {
                freePosition[i] = true;
            }
            else
            {
                freePosition[i] = false;
            }
        }
        
    }

    private bool AvaibleSpace() 
    {
        for (int i = 0; freePosition.Count > i; i++)
        {
            if (freePosition[i] == true)
            {
                return true;
            }
        }
            return false;
    }


    private bool NoEnemyUnits()
    {
        for (int i = 0; freePosition.Count > i; i++)
        {
            if (freePosition[i] == false)
            {
                return false;
            }
        }
        return true;
    }

    private int[] AvaibleSpaceList()
    {
        List<int> avaibleSpace = new List<int>();
        for (int i = 0; freePosition.Count > i; i++)
        {
            if (freePosition[i] == true)
            {
                avaibleSpace.Add(i);
            }
        }
        return avaibleSpace.ToArray();
    }
}
