using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    // in Prefab (not the instances in Hierarchy) ClearCounter
    [SerializeField] private ClearCounter clearCounter; // add ClearCounter to this field in the Inspector window
    [SerializeField] private GameObject visualGameObject; // add KitchenCounter (under Selected) to this field in the Inspector window

    private void Start()
    {
        // the single instance of player as the publisher
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    // in method SetSelectedCounter in publisher class Player, event OnSelectedCounterChanged is raised.
    // then method Player_OnSelectedCounterChanged is invoked to change the visual effect
    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == clearCounter) // ??
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        visualGameObject.SetActive(true);
    }
    private void Hide()
    {
        visualGameObject.SetActive(false);
    }
}
