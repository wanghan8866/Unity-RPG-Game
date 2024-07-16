using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] float parallaxEffect;
    float xPosition;
    float length;
    private GameObject cam;
    

    void Start()
    {
        cam = Camera.main.gameObject;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        xPosition = cam.transform.position.x;
        
    }

    void Update()
    {
        float distanceMoved = cam.transform.position.x * (1-parallaxEffect);
        float distanceToMove = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector2(xPosition+distanceToMove, transform.position.y);

        if(distanceMoved > xPosition + length){
            xPosition += length;
        }else if(distanceMoved < xPosition - length){
            xPosition -= length;
        }
        
    }
}
