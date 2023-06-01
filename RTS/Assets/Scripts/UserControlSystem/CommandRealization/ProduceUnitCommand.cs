using Abstractions.Commands.CommandInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandRealization
{
    public sealed class ProduceUnitCommand : IProduceUnitCommand
    {
        [SerializeField] private GameObject _unitPrefab;

        public GameObject UnitPrefab => _unitPrefab;
    }
}
