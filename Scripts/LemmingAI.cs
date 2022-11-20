using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemmingAI : MonoBehaviour
{
    public float speed;
    public float rayDistance;

    public Player player;


    void Update()
    {

        float num = Random.Range(1, 3);
        
        transform.position += transform.forward * speed * Time.deltaTime;

        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxDistance, Color.green);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), rayDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDistance, Color.green);

            if(num == 1)
            {
                for(int i=0; i<65; i++){
                    transform.Rotate(0f, 1f, 0f);
                    
                }
                
            }else if(num == 2)
            {
                for(int i=0; i>-65; i--){
                    transform.Rotate(0f, -1f, 0f);
                }
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            player.AddHunger(30);
            Destroy(gameObject);
        }
    }

}
