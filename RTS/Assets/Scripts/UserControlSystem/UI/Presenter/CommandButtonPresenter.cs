using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandInterfaces;
using System;
using System.Collections.Generic;
using UnityEngine;
using UserControlSystem.CommandRealization;
using UserControlSystem.UI.View;
using Utils;

namespace UserControlSystem.UI.Presenter
{
    public class CommandButtonPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;

        private ISelectable _currentSelectable;
        private AssetsContext _context;

        void Start()
        {
            _selectable.OnSelected += ONSelected;
            ONSelected(_selectable.CurrentValue);
            
            _view.OnClick += ONButtonClick;
        }

        private void ONSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
                return;
            _currentSelectable = selectable;

            _view.Clear();
            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }

        private void ONButtonClick(ICommandExecutor commandExecutor)
        {
            var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
            if (unitProducer != null)
            {
                unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommand()));
                return;
            }

            var attacker = commandExecutor as CommandExecutorBase<IAttackCommand>;
            if (attacker != null)
            {
                attacker.ExecuteSpecificCommand(_context.Inject(new AttackCommand()));
                return;
            }

            var stopper = commandExecutor as CommandExecutorBase<IStopCommand>;
            if (stopper != null)
            {
                stopper.ExecuteSpecificCommand(_context.Inject(new StopCommand()));
                return;
            }

            var mover = commandExecutor as CommandExecutorBase<IMoveCommand>;
            if (mover != null)
            {
                mover.ExecuteSpecificCommand(_context.Inject(new MoveCommand()));
                return;
            }

            var patroller = commandExecutor as CommandExecutorBase<IPatrolCommand>;
            if (patroller != null)
            {
                patroller.ExecuteSpecificCommand(_context.Inject(new  PatrolCommand()));
                return;
            }

            throw new ApplicationException($"{nameof(CommandButtonPresenter)}.{nameof(ONButtonClick)}:" +
                                            $"Unknown type of command executor: {commandExecutor.GetType().FullName}!");
        }
    }
}