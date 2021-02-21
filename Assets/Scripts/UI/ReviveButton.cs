using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReviveButton : MonoBehaviour
{
    [SerializeField] private ProtagonistStatusEventChannelSO _protagonistStatus = default;
    [SerializeField] private Button _button = default;

    private void OnEnable()
    {
        _protagonistStatus.OnProtagonistDeath += ShowButton;
    }

    private void OnDisable()
    {
        _protagonistStatus.OnProtagonistDeath -= ShowButton;
    }

    public void OnButtonClicked()
    {
        Debug.Log("Revive");
        _protagonistStatus.RaiseEvent(false);
        _button.gameObject.SetActive(false);
    }

    private void ShowButton()
    {
        _button.gameObject.SetActive(true);
    }
}
