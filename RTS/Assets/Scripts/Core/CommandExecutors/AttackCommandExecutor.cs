using Abstractions.Commands.CommandInterfaces;
using Abstractions.Commands;
using UnityEngine;

public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
{
    public override void ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log($"{name} is attacking");
    }
}
