using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Controller : MonoBehaviour
{
    public Transform player;
    Transform cam ;
    Vector3 camStarPos;
    float distance;

    GameObject[] backgrounds;
    Material[] mat;
    float[] backSpeed;

    float farthestBack;

    [Range(0.01f,0.05f)]

    public float parallaxSpeed;
    void Start()
    {
        cam = Camera.main.transform;
        camStarPos = cam.position;

        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for(int i = 0;i< backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;

        }
        BackSpeedCalculate(backCount);
    }


    void BackSpeedCalculate(int backCount)
    {
        for(int i = 0; i < backCount; i++)
        {
            if((backgrounds[i].transform.position.z - cam.position.z) > farthestBack){
                farthestBack = backgrounds[i].transform.position.z - cam.position.z;

            }
        }

        for(int i =0; i<backCount; i++)
        {
            backSpeed[i]= 1 - (backgrounds[i].transform.position.z - cam.position.z) / farthestBack;
        }
    }

    private void LateUpdate()
    {
        distance = cam.position.x-camStarPos.x;
        transform.position = new Vector3(cam.position.x - 5.5f,transform.position.y,0);

        for(int i =0 ;i<backgrounds.Length;i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            mat[i].SetTextureOffset("_MainTex",new Vector2(distance,0) * speed);
        }
    }
}
