using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointerClass : MonoBehaviour, ISelectHandler
{
    //Based from https://discussions.unity.com/t/checking-if-button-is-highlighted-with-a-controller-no-mouse/223282/2
    [SerializeField]
    private Button EnemyFrame;

    private void Awake()
    {
        if(EnemyFrame == null)
        {
            EnemyFrame = GameObject.Find("EnemyFrame").GetComponent<Button>();
           
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        if(eventData.selectedObject)
        {
            Enemy.HasBeenSelected = true;
        }
    }


    
}
