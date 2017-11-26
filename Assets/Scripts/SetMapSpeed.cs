using UnityEngine;

public class SetMapSpeed : MonoBehaviour {

    [SerializeField] private float _enemyMoveSpeed;
    public float EnemyMoveSpeed
    {
        get { return _enemyMoveSpeed; }
        set { _enemyMoveSpeed = value; }
    }
}
