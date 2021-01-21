using System;
using System.Collections.Generic;
using UnityEngine;

namespace MarkOne.StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        [Tooltip("Set the initial state of this StateMachine")]
        [SerializeField] private ScriptableObjects.TransitionTableSO _transitionTableSO = default;

#if UNITY_EDITOR
        [Space]
        [SerializeField] internal Debugging.StateMachineDebugger debugger = default;
#endif

        private readonly Dictionary<Type, Component> _cachedComponents = new Dictionary<Type, Component>();
        internal State currentState;

        private void Awake()
        {
            currentState = _transitionTableSO.GetInitialState(this);
            currentState.OnStateEnter();

#if UNITY_EDITOR
            debugger.Awake(this);
#endif
        }

        public new bool TryGetComponent<T>(out T component) where T : Component
        {
            var type = typeof(T);
            if(!_cachedComponents.TryGetValue(type, out var value))
            {
                if (base.TryGetComponent<T>(out component))
                {
                    _cachedComponents.Add(type, component);
                }

                return component != null;
            }

            component = (T)value;
            return true;
        }

        public T GetOrAddComponent<T>() where T : Component
        {
            if (!TryGetComponent<T>(out var component))
            {
                component = gameObject.AddComponent<T>();
                _cachedComponents.Add(typeof(T), component);
            }

            return component;
        }

        public new T GetComponent<T>() where T : Component
        {
            return TryGetComponent(out T component)
                ? component : throw new InvalidOperationException($"{typeof(T).Name} not found in {name}.");
        }

        private void Update()
        {
            if (currentState.TryGetTransition(out var transitionState))
            {
                Transition(transitionState);
            }

            currentState.OnUpdate();
        }

        private void Transition(StateAction transitionState)
        {
            currentState.OnStateExit();
            currentState = transitionState;
            currentState.OnStateEnter();
        }
    }
}