using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandInterfaces;
using UnityEngine;
using UnityEngine.UI;

public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable
{
    [SerializeField] private Transform _unitsParent;

    [SerializeField] private float _maxHealth = 1000f;
    [SerializeField] private Sprite _icon;

    private float _health = 1000f;
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;

    public override void ExecuteSpecificCommand(IProduceUnitCommand command) =>
        Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
}
