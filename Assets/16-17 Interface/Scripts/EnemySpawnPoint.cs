using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private BehaviorTypes _agroBehavior;
    [SerializeField] private BehaviorTypes _idleBehavior;

    [SerializeField] private Vector3 _offset;

    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private GameObject _player;

    private Dictionary<BehaviorTypes, IEnemyBehavior> _behaviorMap = new Dictionary<BehaviorTypes, IEnemyBehavior>();

    private void Awake()
    {
        _behaviorMap = new Dictionary<BehaviorTypes, IEnemyBehavior>()
    {
        { BehaviorTypes.Idle_Stand, new IdleStandBehavior() },
        { BehaviorTypes.Idle_Patrol, new IdlePatrolBehavior() },
        { BehaviorTypes.Idle_RandomWalk, new IdleRandomWalkBehavior() },
        { BehaviorTypes.Agro_Follow, new AgroFollowBehavior() },
        { BehaviorTypes.Agro_RunAway, new AgroRunAwayBehavior() },
        { BehaviorTypes.Agro_SelfDestruct, new AgroSelfDestructBehavior() }
    };
    }

    void Start()
    {
 
        IEnemyBehavior agro = _behaviorMap[_agroBehavior];
        IEnemyBehavior idle = _behaviorMap[_idleBehavior];

        Enemy enemy = Instantiate(_enemyPrefab, transform.position + _offset, Quaternion.identity);
        enemy.Initialize(agro, idle, _player);
    }
}
