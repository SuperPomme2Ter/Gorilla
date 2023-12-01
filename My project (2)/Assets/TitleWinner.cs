using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleWinner : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text _text;
    void Start()
    {
        if (Staticvar.winner==false)
        {
            _text.text = "    Winner : IA";
        }
        else
        {
            _text.text = "Winner : Player";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
