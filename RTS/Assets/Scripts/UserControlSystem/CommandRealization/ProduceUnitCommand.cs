using Abstractions.Commands.CommandInterfaces;
using UnityEngine;
using Utils;

namespace UserControlSystem.CommandRealization
{
    public sealed class ProduceUnitCommand : IProduceUnitCommand
    {
        [InjectAsset("Chomper")] private GameObject _unitPrefab;

        public GameObject UnitPrefab => _unitPrefab;
    }
}
