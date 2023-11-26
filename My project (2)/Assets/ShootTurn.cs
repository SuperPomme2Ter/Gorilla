using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootTurn : MonoBehaviour
{
    [SerializeField] public GameObject inst_projectile;
    [SerializeField]
    private InputActionReference Up, Left, Right,Down;
    GameObject projectile;
    public main game;
    public Vector3 shoot=new Vector3(0,0,0);
    public Vector3 v;
    public Movements playerRb;


    // Start is called before the first frame update
    void Start()
    {
            projectile = Instantiate(inst_projectile, new Vector2(-10000, -1000), transform.rotation);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (game.gameState == 2)
        {
            if (Up.action.inProgress)
            {
                shoot.y += 0.1f;
            }
            if (Down.action.inProgress)
            {
                shoot.y -= 0.1f;
            }
            if (Left.action.inProgress)
            {
                shoot.x -= 0.1f;
            }
            if (Right.action.inProgress)
            {
                shoot.x += 0.1f;
            }
            v= (transform.position + new Vector3(1, 0, 0)+shoot)- (transform.position + new Vector3(1, 0, 0));
            Vector3 currentPos=transform.position+new Vector3(1,0,0);
            for (int i = 0; i < 50; i++)
            {
                if (currentPos.y < -3.0f)
                    break;
                v += Physics.gravity*Time.fixedDeltaTime;
                Vector3 nextPos=currentPos+v*Time.fixedDeltaTime;
                Debug.DrawLine(currentPos,nextPos);
                currentPos = nextPos;
            }
            game.transition = false;
        }
        if (projectile.GetComponent<Ball>().transition)
        {
            game.gameState = 4;
            projectile.GetComponent<Ball>().transition = false;
        }
    }
    public void Throw(InputAction.CallbackContext ctx)
    {
        if (!game.transition)
        {
            if (game.gameState == 2)
            {
                if (ctx.phase == InputActionPhase.Started)
                {
                    projectile.GetComponent<Ball>().createBall(transform.position + new Vector3(1, 0), shoot.x, shoot.y);
                    print("aaaawababugh");
                    game.gameState = 3;
                    game.transition = true;

                }
            }
        }
    }
}
