using Abstractions.Commands;
using Abstractions.Commands.CommandInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UserControlSystem.UI.View
{
    public sealed class CommandButtonsView : MonoBehaviour
    {
        [SerializeField] private GameObject _moveButton;
        [SerializeField] private GameObject _produceUnitButton;
        [SerializeField] private GameObject _attackButton;
        [SerializeField] private GameObject _patrolButton;
        [SerializeField] private GameObject _stopButton;

        public Action<ICommandExecutor> OnClick;

        private Dictionary<Type, GameObject> _buttonsByExecutorType;

        private void Start()
        {
            _buttonsByExecutorType = new Dictionary<Type, GameObject>
            {
                { typeof(CommandExecutorBase<IAttackCommand>), _attackButton },
                { typeof(CommandExecutorBase<IMoveCommand>), _moveButton },
                { typeof(CommandExecutorBase<IPatrolCommand>), _patrolButton },
                { typeof(CommandExecutorBase<IStopCommand>), _stopButton },
                { typeof(CommandExecutorBase<IProduceUnitCommand>), _produceUnitButton }
            };
            Clear();
        }

        public void MakeLayout(List<ICommandExecutor> commandExecutors)
        {
            foreach (var currentExecutor in commandExecutors) 
            {
                var buttonGameObject = _buttonsByExecutorType.First(type => type.Key.IsInstanceOfType(currentExecutor)).Value;
                buttonGameObject.SetActive(true);
                var button = buttonGameObject.GetComponent<Button>();
                button.onClick.AddListener(() => OnClick?.Invoke(currentExecutor));
            }
        }

        public void Clear()
        {
            foreach (var kvp in _buttonsByExecutorType)
            {
                kvp.Value.GetComponent<Button>().onClick.RemoveAllListeners();
                kvp.Value.SetActive(false);
            }
        }
    }
}