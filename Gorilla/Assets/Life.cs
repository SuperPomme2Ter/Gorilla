using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public ShootTurn proj;
    public int actualSpriteJ;
    public int actualSpriteIA;
    public Sprite full, fourL, threeL, twoL, oneL;
    public UnityEngine.UI.Image lifeJ;
    public UnityEngine.UI.Image lifeIA;
    public main game;
    public bool test = false;

    // Start is called before the first frame update
    void Start()
    {
       actualSpriteJ = 5;
       actualSpriteIA = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (proj.projectile.GetComponent<Ball>().touch==1 ) {
            actualSpriteJ -= 1;
            if (actualSpriteJ == 4) {

                lifeJ.sprite = fourL;
            }
            if (actualSpriteJ == 3)
            {
                lifeJ.sprite = threeL;
            }
            if (actualSpriteJ == 2)
            {
                lifeJ.sprite = twoL;
            }
            if (actualSpriteJ == 1)
            {
                lifeJ.sprite = oneL;
            }
            if (actualSpriteJ == 0)
            {
                Staticvar.winner = false;
                game.gameState = 11;
                test = true;
            }
            
        }
        if (proj.projectile.GetComponent<Ball>().touch == 2)
        {
            actualSpriteIA -= 1;
            if (actualSpriteIA == 4)
            {

                lifeIA.sprite = fourL;
            }
            if (actualSpriteIA == 3)
            {
                lifeIA.sprite = threeL;
            }
            if (actualSpriteIA == 2)
            {
                lifeIA.sprite = twoL;
            }
            if (actualSpriteIA == 1)
            {
                lifeIA.sprite = oneL;
            }
            if (actualSpriteIA == 0)
            {
                Staticvar.winner = true;
                game.gameState = 11;
                test = true;
            }

        }
        proj.projectile.GetComponent<Ball>().touch = 0;
    }
}
