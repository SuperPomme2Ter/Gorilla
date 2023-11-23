using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 ballVelocity = new Vector2(0f, 0f);
    [SerializeField] public GameObject ball;
    float _velX;
    float _velY;
    Vector2 _position;
    public Ball(GameObject ball, Vector2 pos, float velX, float velY)
    {
        _position = pos;
        _velX = velX;
        _velY = velY;



    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        ball.GetComponent<Ball>()._position.x += _velX;
        ball.GetComponent<Ball>()._position.y += _velY;
        if (_velX > 0f)
        {
            _velX -= 0.01f;
        }
        if (_velY > 0f)
        {
            _velY -= 0.01f;
        }
    }
}
