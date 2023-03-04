using System;
using System.Collections.Generic;
using PopupSystem;
using UnityEngine;

[CreateAssetMenu(fileName = ASSET_NAME, menuName = ASSET_MENU_NAME)]
public class BasicPopupQueueVariable : SharedVariable, ISerializationCallbackReceiver
{
    public event Action<Queue<PopupController>> OnValueChanged = delegate (Queue<PopupController> list) { };

    private Queue<PopupController> currentValue;
    private Queue<PopupController> InitialValue { get; }

    public Queue<PopupController> CurrentValue
    {
        get => currentValue;
        set
        {
            if (currentValue != value)
            {
                currentValue = value;
                OnValueChanged(value);
            }
        }
    }
    
    private const string ASSET_NAME = nameof(BasicPopupQueueVariable);
    private const string ASSET_MENU_NAME = ProjectConstants.SHARED_VARIABLE_MENU_PATH + ASSET_NAME;

    public void OnAfterDeserialize ()
    {
        CurrentValue = InitialValue;
    }

    public void OnBeforeSerialize ()
    {
    }
}