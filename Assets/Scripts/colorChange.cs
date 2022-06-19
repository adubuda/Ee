using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using TMPro;

public class colorChange : MonoBehaviour
{  
    public Rigidbody2D ballRB;
    public static List<GameObject> walls;
    public SpriteShapeRenderer wallRenderer;
    public bool canChangetoRed;
    public bool canChangetoBlue;
    public float colorChangetoBlueTimer = 3;
    public float canChangetoRedCD = 0;

    // Start is called before the first frame update
    void Start()
    {
        wallRenderer.GetComponent<SpriteShapeRenderer>().color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {

        if (wallRenderer.GetComponent<SpriteShapeRenderer>().color == Color.blue)
        {
            canChangetoRedCD -= Time.deltaTime;
            if (canChangetoRedCD < 0)
            {
                canChangetoRed = true;
            }
            else
            {
                canChangetoRed = false;
            }
          
            if (canChangetoRed)
            {
                StartCoroutine(ColorChangetoRed());
                canChangetoRedCD += Time.deltaTime * 5000;  //for 1 time coroutine
                
            }
        }
        if (wallRenderer.GetComponent<SpriteShapeRenderer>().color == Color.red)
        {
            canChangetoRedCD = 3;
            canChangetoRed = false;
            StopAllCoroutines();
            colorChangetoBlueTimer -= Time.deltaTime;
            if (colorChangetoBlueTimer< 0)
            {
                wallRenderer.GetComponent<SpriteShapeRenderer>().color = Color.blue;
                colorChangetoBlueTimer = 5;
            }
        }

    }
    
 
  
    IEnumerator ColorChangetoRed()
    {
        if (wallRenderer.GetComponent<SpriteShapeRenderer>().color == Color.blue)
        {
            yield return new WaitForSeconds(Random.Range(3, 6));
            wallRenderer.GetComponent<SpriteShapeRenderer>().color = Color.red;
        }
        
        
    }
}
    
        