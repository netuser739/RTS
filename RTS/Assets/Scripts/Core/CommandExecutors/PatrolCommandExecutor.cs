using Abstractions.Commands;
using Abstractions.Commands.CommandInterfaces;
using UnityEngine;

public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
{
    public override void ExecuteSpecificCommand(IPatrolCommand command)
    {
        Debug.Log($"{name} is patrolling");
    }
}
