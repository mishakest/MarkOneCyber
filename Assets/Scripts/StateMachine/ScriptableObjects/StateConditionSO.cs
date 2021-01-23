﻿using System.Collections.Generic;
using UnityEngine;

namespace MarkOne.StateMachine.ScriptableObjects
{
    public abstract class StateConditionSO : ScriptableObject
    {
        [Tooltip("The condition will only be evaluated once each frame, and cached for subsequent uses.\r\n\r\nThe caching is unique to each instance of the State Machine and of the Scriptable Object (i.e. Instances of the State Machine or Condition don't share results if they belong to different GameObjects).")]
        [SerializeField] internal bool cacheResult = true;

        internal StateCondition GetCondition(StateMachine stateMachine, bool expectedResult, Dictionary<ScriptableObject, object> createdInstances)
        {
            if (!createdInstances.TryGetValue(this, out var obj))
            {
                var condition = CreateCondition();
                condition.originSO = this;
                createdInstances.Add(this, condition);
                condition.Awake(stateMachine);

                obj = condition;
            }

            return new StateCondition(stateMachine, (Condition)obj, expectedResult);
        }

        protected abstract Condition CreateCondition();
    }

    public abstract class StateConditionSO<T> : StateConditionSO where T : Condition, new()
    {
        protected override Condition CreateCondition() => new T();
    }
}