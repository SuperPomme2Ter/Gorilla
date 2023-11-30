using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrain : MonoBehaviour
{
    // Start is called before the first frame update
    float x=0;
    float y;
    float maxY=1.2f;
    public List<GameObject> ground;
    [SerializeField] public GameObject platform;

    void Start()
    {
        while (x<=24)
        {
            
            y = Random.Range(0.2f, maxY) * 10;
            ground.Add(Instantiate(platform, new Vector2(-1000,-1000), transform.rotation));
            ground[ground.Count - 1].transform.position = new Vector2(-12+x, -5);
            ground[ground.Count-1].transform.localScale=new Vector2(1, y);
            x += 1;
           // ground[ground.Count-1].GetComponent<BoxCollider2D>(). = new Vector2(x, y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
