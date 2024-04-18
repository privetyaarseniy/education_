using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _board;
    [SerializeField]
    private int _xOffsetRange;
    [SerializeField]
    private int _yForce;
    Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.y < -17)
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject == _board)
        //{
        //    _rb.AddForce(new Vector3(Random.Range(-_xOffsetRange, _xOffsetRange + 1), _yForce, 0) * _rb.mass, ForceMode2D.Impulse);
        //}

        ContactPoint2D contact = collision.GetContact(0);
        
    }

}
