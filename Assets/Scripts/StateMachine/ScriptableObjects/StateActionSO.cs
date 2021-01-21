﻿using UnityEngine;
using System.Collections.Generic;

namespace MarkOne.StateMachine.ScriptableObjects
{
    public abstract class StateActionSO : ScriptableObject
    {
        internal StateAction GetAction(StateMachine stateMachine, Dictionary<ScriptableObject, object> createdInstances)
        {
            if (createdInstances.TryGetValue(this, out var obj))
                return (StateAction)obj;

            var action = CreateAction();
            createdInstances.Add(this, action);
            action.originSO = this;
            action.Awake(stateMachine);
            return action;
        }

        protected abstract StateAction CreateAction();
    }

    public abstract class StateActionSO<T> : StateActionSO where T : StateAction, new()
    {
        protected override StateAction CreateAction() => new T();
    }
}