using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    public static List<Enemy> EnemyList;
    public static bool PlayerTurn;
    public static Knight Player;

    // Start is called before the first frame update
    void Start()
    {
        EnemyList= new List<Enemy>();
        FindTotalEnemy();

        PlayerTurn = true;

        Player = GameObject.Find("Player1").GetComponent<Knight>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTurn();
    }

    private void FindTotalEnemy()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(var v in obj)
        {
            EnemyList.Add(v.GetComponent<Enemy>());
        }
    }

    private void SetTurn()
    {
        


    }

}
