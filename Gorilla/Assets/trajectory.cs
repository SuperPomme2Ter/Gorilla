using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trajectory : MonoBehaviour
{
    // Start is called before the first frame update
    public main game;
    public ShootTurn calculJ;
    public IATurn calculIA;
    public LineRenderer trail;
    public Vector3[] positions=new Vector3[500];
    void Start()
    {
        trail.enabled = false;
        trail.material = new Material(Shader.Find("Sprites/Default"));
        trail.positionCount = positions.Length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

}
