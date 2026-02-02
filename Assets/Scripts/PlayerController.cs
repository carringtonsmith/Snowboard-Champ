using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    Rigidbody2D rb2d;
    //GemManager gm is connected to GemManager script
    public GemManager gm;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //if a gem is collides with player destroy object
        if (other.gameObject.CompareTag("Gem"))
        {
            Destroy(other.gameObject);
            //score plus 1
            gm.gemCount++;
        }
    }
    
    //yellow gem is worth more points than blue one
}
