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
    private int odds = 0;
    private SpriteRenderer Spirt;
    private int Dice;
    private bool ResetTimer = false;
    private bool roll = false;
    string status = "Healthy";
    // Start is called before the first frame update
    void Start()
    {
        Target = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
        Spirt = GetComponent<SpriteRenderer>();
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

        if (targetTime <= 0.0f && roll == false)
        {
            Dice = Random.Range(0, 100);
            
            if (Dice + odds <= 20)
            {
                status = "Sick";
                Spirt.color = Color.green;
            }
            
            if (Dice + odds >= 90)
            {
                status = "Immune";
            }
            
            if (Dice + odds >= 21 && Dice <= 89)
            {
                status = "Healthy";
            }
            if (Dice + odds <= 0)
            {
                status = "Dead";
            }
            Debug.Log(status);
            roll = true;
        }
        
        if (status == "Healthy")
        {
            resettimer(10.0f);
            Spirt.color = Color.white;
        }
        
        if (status == "Sick")
        {
            resettimer(10.0f);
            odds = -69;
            Spirt.color = Color.green;
        }
        
        if (status == "Immune")
        {
            odds = 1000;
            Spirt.color = Color.yellow;
        }
        
        if (status == "Dead")
        {
            odds = -1000;
            Spirt.color = Color.black;
            speed = 0;
        }
    }
    void resettimer(float Tid)
    {
        if (ResetTimer == false)
        {
            targetTime = Tid;
            ResetTimer = true;
        }
        if (targetTime <= 0)
        {
            ResetTimer = false;
            roll = false;
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
