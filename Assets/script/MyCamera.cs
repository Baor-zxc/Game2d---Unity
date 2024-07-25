using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{

    
    public Transform player;

    public float minX,maxX;
    public float minY,maxY;
    internal static object current;
    public float smoothSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (player != null)
        // {
        //     Vector3 temp = transform.position;
        //     temp.x = player.position.x;
            
        //     if(temp.x<minX){
        //         temp.x=minX;
        //     }
        //     if(temp.x >maxX){
        //         temp.x=maxX;
        //     }

        //     transform.position = temp;
        // }


        if (player != null)
        {
            
            Vector3 targetPosition = new Vector3(player.position.x, player.transform.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);
            
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }

        
    }
}
