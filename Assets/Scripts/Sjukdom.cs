using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Sjukdom : MonoBehaviour
{
    public int speed = 5;
    public bool state;
    private Vector3 Target;
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
    }
    IEnumerator IDLE()
    {


        yield return null;
    }
}
