using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spell/Create new Spell", order = 51)]
public class Spell : ScriptableObject
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private uint _projectilesPerShot;
    [SerializeField] private float _spread;

    [SerializeField] private Sprite _icon;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int _price;

    private MousePositionGetter _mousePositionGetter = new MousePositionGetter();

    public float AttackSpeed => _attackSpeed;
    public uint ProjectilesPerShot => _projectilesPerShot;
    public float Spread => _spread;
    public Sprite Icon => _icon;
    public string Name => _name;
    public string Description => _description;
    public int Price => _price;

    public void Shoot(Transform hand)
    {
        for (int i = 0; i < _projectilesPerShot; i++)
            CastFireBall(hand);
    }

    private void CastFireBall(Transform hand)
    {
        Vector3 targetAngle = _mousePositionGetter.Get3DRotationFrom(hand, Vector3.up).eulerAngles;
        targetAngle.y += Random.Range(-_spread, _spread);

        Instantiate(_projectile.gameObject, hand.position, Quaternion.Euler(targetAngle));
    }
}
