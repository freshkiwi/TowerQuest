using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Knight : MonoBehaviour, IPlayer
{

    //temp for ui

    [SerializeField]
    private Button[] CommandButtons;

    public int Health { get; set; }
   
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < CommandButtons.Length; i++)
        {
            int bntNum = i;
            CommandButtons[i].onClick.AddListener(() => SetButtons(bntNum));
        }

        CommandButtons[0].Select();
    }

    void Update()
    {
        
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

    public void Attack()
    {
        Debug.Log("Attact button pressed");
    }
    public void Support()
    {
        Debug.Log("Support button pressed");
    }
    public void Risk()
    {
        Debug.Log("Risk button pressed");
    }

}
