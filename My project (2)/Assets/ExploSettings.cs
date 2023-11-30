using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploSettings : MonoBehaviour
{
    public GameObject EXPLOSION;
    public bool launched = false;
    // Start is called before the first frame update
    void Start()
    {
        EXPLOSION.SetActive(false);
    }
    public void animStatus()
    {
        if (EXPLOSION.GetComponent<Animation>().isActiveAndEnabled)
        {
            EXPLOSION.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
