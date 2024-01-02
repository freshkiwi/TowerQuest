using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static GameManager;

public class Knight : MonoBehaviour, IPlayer
{
    public PlayerInputs controls;
    private InputAction SelectControl;

    [SerializeField]
    private Button[] CommandButtons;

    public int Health { get; set; }

    private bool SelectEnemy;
    private int CommandValue;

    void Awake()
    {
        controls = new PlayerInputs();
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < CommandButtons.Length; i++)
        {
            int bntNum = i;
            CommandButtons[i].onClick.AddListener(() => SetButtons(bntNum));
        }

        CommandButtons[0].Select();

        SelectEnemy = false;

        Health = 100;
    }

    private void OnEnable()
    {
        SelectControl = controls.Player1.Select;
        SelectControl.Enable();
    }

    private void OnDisable()
    {
        SelectControl.Disable();
    }

    void Update()
    {
        Debug.Log("Knight health: " + Health);

        if (PlayerTurn && SelectEnemy)
        {

            switch(CommandValue)
            {
                case 1:
                    attack();
                    break;
            }
        }
        
    }

    private void SetButtons(int num)
    {
        switch (num)
        {
            case 0:
                this.Attack();
                break;
            case 1:
                this.Support();
                break;
            case 2:
                this.Risk();
                break;
        }

    }

    /*
     Attack - Player attacks the enemy and deals 10 HP of damage
    Support - Player "defends" and reduces the enemies attack by 5 HP of damage
    Risk - Player attacks the enemy for 15 HP of damage, however, this attack has only a 5/10 chance of hitting
     */

    public void Attack()
    {
        ChangeTurn(true, 1);
        foreach (var v in EnemyList)
        {
            v.EnableInteraction();
        }
        DisableInteraction();

    }
    public void Support()
    {
        Debug.Log("Support button pressed");
    }
    public void Risk()
    {
        Debug.Log("Risk button pressed");
    }

    private void attack()
    {
        //Some help from chat.gpt
        if (SelectControl.IsPressed() )
        {
            Enemy selectedEnemy = EnemyList.FirstOrDefault(e => e.IsSelected);

            if (selectedEnemy != null)
            {

                selectedEnemy.Health -= 10;

                ChangeTurn(false, 0);

                foreach (var v in EnemyList)
                {
                    v.DisableInteraction();
                    v.RemoveSelection();
                }
                DisableInteraction();

                CommandButtons[0].Select();

                PlayerTurn = false;
            }
            else
            {
               //Nothing
            }
        }
    }

    private void ChangeTurn(bool enemySelected, int commandNum)
    {
        SelectEnemy = enemySelected;
        CommandValue = commandNum;
    }

    public void EnableInteraction()
    {
        foreach(var v in CommandButtons)
        {
            v.interactable = true;
        }
       
    }

    public void DisableInteraction()
    {
        foreach (var v in CommandButtons)
        {
            v.interactable = false;
            
        }
    }

    
}
