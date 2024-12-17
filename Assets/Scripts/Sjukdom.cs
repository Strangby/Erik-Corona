using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Sjukdom : MonoBehaviour
{
    public int speed = 5;
    public float targetTime = 10.0f;
    private bool state;
    private Vector3 Target;
    private int Dice;
    string status = "Healthy";
    // Start is called before the first frame update
    void Start()
    {
        Target = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);
        
        if (transform.position == Target)
        {
            Target = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
        }
        targetTime -= Time.deltaTime;

        if (targetTime == 0.0f)
        {
            Dice = Random.Range(0, 100);
            
            if (Dice <= 20)
            {
                status = "Sick";
            }
            
            if (Dice >= 90)
            {
                status = "Immune";
            }
            
            if (Dice >= 21 && Dice <= 89)
            {
                status = "Healthy";
            }
        }
        
        if (status == "Healthy")
        {
            
        }
        
        if (status == "Sick")
        {

        }
        
        if (status == "Immune")
        {

        }
        
        if (status == "Dead")
        {

        }
    }
    
    IEnumerator Timer()
    {

        yield return null;
    }
    IEnumerator IDLE()
    {

        yield return null;
    }
}
