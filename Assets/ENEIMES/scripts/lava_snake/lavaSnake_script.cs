using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaSnake_script : MonoBehaviour
{
    public float coolDown;
    public bool isdown;
    public bool isUp;

    public float stayup;
    public float stayuptimer;

    public float coolDowntimer;

    public Vector3 targetpos;

    public Vector3 startpos;

    public Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        coolDowntimer = coolDown;
        startpos = transform.position;
        rig = GetComponent<Rigidbody2D>();
        isdown = true;
        isUp = false;
        stayuptimer = stayup;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(isUp)
        {
            moveup();
        }

        if (isdown)
        {
            resetpos();
        }
        
    }

    void FixedUpdate()
    {

        if (isdown)
        {
            coolDowntimer = coolDowntimer - Time.deltaTime;
            
        }

        if (isUp)
        {
            stayuptimer = stayuptimer - Time.deltaTime;  
        }


        if(coolDowntimer <= 0)
        {
            
            isdown = false;
            isUp = true;
            coolDowntimer = coolDown;
        }

        if(stayuptimer <= 0)
        {
            isdown = true;
            isUp = false;
            stayuptimer = stayup;
        }
    }
    private void moveup()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetpos , 2 * Time.deltaTime);

    }



      void resetpos()
    {
         transform.position = Vector3.MoveTowards(transform.position, startpos , 2 * Time.deltaTime);
    }
}
