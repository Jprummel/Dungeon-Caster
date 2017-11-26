using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    private enum Movedirection
    {
        LEFT,
        RIGHT
    }

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Movedirection _moveDirection;
    private bool _canMove = true;
    private Rigidbody2D _rb2D;

    public bool CanMove
    {
        get { return _canMove; }
        set { _canMove = value; }
    }

    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

	void Start () {
        _rb2D = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (!GameState.IsPaused)
        {
            if (_canMove)
            {
                if (_moveDirection == Movedirection.LEFT)
                {
                    _rb2D.velocity = -transform.right * _moveSpeed * Time.deltaTime;
                }
                else if (_moveDirection == Movedirection.RIGHT)
                {
                    _rb2D.velocity = transform.right * _moveSpeed * Time.deltaTime;
                }
            }else if (!_canMove)
            {
                _rb2D.velocity = new Vector2(0, 0);
            }
        }else if (GameState.IsPaused)
        {
            _rb2D.velocity = new Vector2(0,0);
        }    
    }
}
