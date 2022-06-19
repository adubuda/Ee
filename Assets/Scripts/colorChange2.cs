using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using TMPro;

public class colorChange2 : MonoBehaviour
{
    public Rigidbody2D ballRB;
    public static List<GameObject> circlewalls;
    public SpriteRenderer circlewallRenderer;
    public bool canChangetoRed;
    public bool canChangetoBlue;
    public float colorChangetoBlueTimer = 3;
    public float canChangetoRedCD = 0;

    // Start is called before the first frame update
    void Start()
    {
        circlewallRenderer.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {

        if (circlewallRenderer.GetComponent<SpriteRenderer>().color == Color.blue)
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
        if (circlewallRenderer.GetComponent<SpriteRenderer>().color == Color.red)
        {
            canChangetoRedCD = 2;
            canChangetoRed = false;
            StopAllCoroutines();
            colorChangetoBlueTimer -= Time.deltaTime;
            if (colorChangetoBlueTimer < 0)
            {
                circlewallRenderer.GetComponent<SpriteRenderer>().color = Color.blue;
                colorChangetoBlueTimer = 3;
            }
        }

    }



    IEnumerator ColorChangetoRed()
    {
        if (circlewallRenderer.GetComponent<SpriteRenderer>().color == Color.blue)
        {
            yield return new WaitForSeconds(Random.Range(2, 5));
            circlewallRenderer.GetComponent<SpriteRenderer>().color = Color.red;
        }


    }
}