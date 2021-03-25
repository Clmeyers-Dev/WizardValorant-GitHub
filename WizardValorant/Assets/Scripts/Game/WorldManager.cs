using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentRound;
    public int teamOneWins;
    public int teamTwoWins;
    public bool teamOneAttacking;
    public WizardManager[] Team1;
    public WizardManager[] Team2;
    public Bomb bomb;
    public Transform attackSpawn;
    public Transform DefendSpawn;
    public bool PointsAwarded;
    void Start()
    {
        startGame();
        StartRound();
    }
    public void startGame()
    {
        int random = Random.Range(0, 1);
        if(random == 1)
        {
            teamOneAttacking = false;
        }
        PointsAwarded = false;
        for (int i = 0; i < Team1.Length; i++)
        {
            Team1[i].ArcanePower = 500;
        }
        for (int i = 0; i < Team2.Length; i++)
        {
            Team2[i].ArcanePower = 500;
        }
        Debug.Log("Game Start");
    }
    public void StartRound()
    {
        for (int i = 0; i < Team1.Length; i++)
        {
            Team1[i].currentHealth = Team1[i].maxHealth;
        }
        for (int i = 0; i < Team2.Length; i++)
        {
            Team2[i].currentHealth = Team2[i].maxHealth;
        }
        Debug.Log("Round Start");
        Destroy(bomb);
        bomb = null;
        PointsAwarded = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (bomb == null)
        {
            bomb = FindObjectOfType<Bomb>();
        }
        if(bomb !=null && bomb.diffused&&PointsAwarded==false)
        {
            if (teamOneAttacking== false)
            {
                teamOneWins++;
                
                PointsAwarded = true;
                StartRound();
            }
            else
            {
                teamTwoWins++;
               
                PointsAwarded = true;
                StartRound();

            }

        }
        if (bomb != null && bomb.exploded && PointsAwarded == false)
        {
            if (teamOneAttacking == true)
            {
                teamOneWins++;
               
                PointsAwarded = true;
                StartRound();
            }
            else
            {
                teamTwoWins++;
                StartRound();
                PointsAwarded = true;
                StartRound();
            }

        }
    
    }
}
