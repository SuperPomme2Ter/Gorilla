using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrain : MonoBehaviour
{
    // Start is called before the first frame update
    float x;
    float y;
    float maxX=0.6f;
    float maxY=1.2f;
    float rest = 24;
    public List<GameObject> ground;
    [SerializeField] public GameObject platform;

    void Start()
    {
        while (maxX > 0)
        {
            x = Random.Range(0.1f, maxX) * 10;
            y = Random.Range(0.1f, maxY) * 10;
            ground.Add(Instantiate(platform, new Vector2(-1000,-1000), transform.rotation));
            ground[ground.Count - 1].transform.position = new Vector2(-12+x/2+(24-rest), -5);
            ground[ground.Count-1].transform.localScale=new Vector2(x, y);
           // ground[ground.Count-1].GetComponent<BoxCollider2D>(). = new Vector2(x, y);
            rest -= x;
            maxX = rest/10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
