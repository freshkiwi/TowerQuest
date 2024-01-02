using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static GameManager;

public class Enemy : MonoBehaviour, IEntity
{
    public int Health { get; set; }
    public bool IsSelected { get; set; }

    public static bool HasBeenSelected;

    //[SerializeField]
    public Button CommandButtons { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        CommandButtons = transform.Find("EnemyFrame").GetComponent<Button>();

        Health = 100;

        IsSelected = false;

        CommandButtons.onClick.AddListener(HasSelected);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.gameObject.name + " health: " + Health);

        if (Health == 0)
        {
            this.gameObject.SetActive(false);
            EnemyList.Remove(this);
        }
        else
        {
            if (!PlayerTurn)
            {
                Attack();
            }
        }
        
        
    
    }

    public void EnableInteraction()
    {
        CommandButtons.interactable = true;
        CommandButtons.Select();  
    }

    public void DisableInteraction()
    {
        CommandButtons.interactable = false;
    }

    private void HasSelected()
    {
        IsSelected = HasBeenSelected;
    }

    public void RemoveSelection()
    {
        IsSelected = false;
    }

    public void Attack()
    {
        Knight player = GameObject.FindAnyObjectByType<Knight>();

        StartCoroutine(WaitTime(player));

        
    }

    IEnumerator WaitTime(Knight player)
    {
        yield return new WaitForSeconds(2);
        player.Health -= 10;

        PlayerTurn = true;
        player.EnableInteraction();
        StopAllCoroutines();
    }
    
}
