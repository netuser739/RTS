using Abstractions.Commands;
using Abstractions.Commands.CommandInterfaces;
using UnityEngine;

public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
{
    public override void ExecuteSpecificCommand(IStopCommand command)
    {
        Debug.Log($"{name} is stopped");
    }
}
