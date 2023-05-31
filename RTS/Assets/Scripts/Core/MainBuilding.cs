using Abstractions;
using UnityEngine;

public class MainBuilding : MonoBehaviour, ISelectable, IUnitProducer
{
    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private Transform _unitsParent;

    [SerializeField] private float _maxHealth = 1000f;
    [SerializeField] private Sprite _icon;

    private float _health = 1000f;
    public float Health => _health;

    public float MaxHealth => _maxHealth;

    public Sprite Icon => _icon;

    public void ProduceUnit()
    {
        Instantiate(_unitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
    }
}
