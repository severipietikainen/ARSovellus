using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Changetext : MonoBehaviour
{
    TargetHit targetHit;
    public TMP_Text canvasText;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        targetHit = GameObject.Find("SpawnableObject").GetComponent<TargetHit>();
        if(targetHit.score == 1)
        {
         canvasText.text = "You have hit the ball. Well done!";
        }
    }
}
