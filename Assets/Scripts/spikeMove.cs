using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.U2D;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spikeMove : MonoBehaviour
{
    public List<GameObject> walls;
    public List<SpriteShapeRenderer> wallrenderer;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public Slider lifeSlider;
    Rigidbody2D ballRB;
    public GameObject base1;
    public Vector2 touchPos;
    public float score;
    public int scoreForText;
    public int life=3;
    public float speed;
    public float distance;
    public bool ballIsMoving;
    public bool ballCanMove;
    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
        lifeSlider.value = life;
    }

    // Update is called once per frame
    void Update()
    {
        base1 = GameObject.FindWithTag("Player");
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2 spikemoveDir = new Vector2(base1.transform.position.x, base1.transform.position.y) - touchPos;
            distance = Vector2.Distance(Vector2.zero, touchPos);
            if (touch.phase == TouchPhase.Began)
            {

                if (touchPos == new Vector2(Mathf.Clamp(touchPos.x, -0.5f, 0.5f), Mathf.Clamp(touchPos.y, -0.5f, 0.5f)) && !ballIsMoving&&!ballIsMoving)
                {
                    transform.position = touchPos;
                    ballCanMove = true;
                    
                }
               // ballRB.velocity = new Vector2(0, 0);              
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (ballCanMove&&!ballIsMoving&&distance<1.5f)
                {
                    transform.position = touchPos;
                }
                else if (ballCanMove && !ballIsMoving && distance >= 1.5f)
                {
                    transform.position = Vector2.zero + (touchPos-Vector2.zero ).normalized * 1.5f;
                }
                if (ballIsMoving == false)
                {
                    ballRB.velocity = new Vector2(0, 0);
                }
                
            }
            if (touch.phase == TouchPhase.Ended)
            {
                if (ballCanMove)
                {

                    ballRB.AddForce(spikemoveDir.normalized * speed);
                    ballIsMoving = true;
                    ballCanMove = false;
                }
            }
        }
        
        if (ballRB.velocity == Vector2.zero)
        {
            ballIsMoving = false;
        }
        else
        {
            ballIsMoving = true;
        }
        if (life < 0)
        {
            life = 0;
        }
        if (walls[0].gameObject.GetComponent<SpriteShapeRenderer>().color == Color.red)
        {
            score -= Time.deltaTime;
        }
        if (walls[1].gameObject.GetComponent<SpriteShapeRenderer>().color == Color.red)
        {
            score -= Time.deltaTime;
        }
        if (walls[2].gameObject.GetComponent<SpriteShapeRenderer>().color == Color.red)
        {
            score -= Time.deltaTime;
        }
        if (walls[3].gameObject.GetComponent<SpriteShapeRenderer>().color == Color.red)
        {
            score -= Time.deltaTime;
        }
        //if (walls[4].gameObject.GetComponent<SpriteRenderer>().color == Color.red)
        //{
        //    score -= Time.deltaTime;
        //}
        //if (walls[5].gameObject.GetComponent<SpriteRenderer>().color == Color.red)
        //{
        //    score -= Time.deltaTime;
        //}
        //if (walls[6].gameObject.GetComponent<SpriteRenderer>().color == Color.red)
        //{
        //    score -= Time.deltaTime;
        //}
        //if (walls[7].gameObject.GetComponent<SpriteRenderer>().color == Color.red)
        //{
        //    score -= Time.deltaTime;
        //}
        scoreText.SetText("Score: " + scoreForText.ToString());
        lifeText.SetText(life.ToString());
        lifeSlider.value = life;
        scoreForText = Mathf.RoundToInt(score);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "walls")
        {
            ballRB.transform.position = new Vector2(0, 0);
            ballRB.velocity = new Vector2(0, 0);
            if (other.gameObject.GetComponent<SpriteShapeRenderer>().color == Color.red)
            {
                Debug.Log("asd");
                score += 100;
                other.gameObject.GetComponent<SpriteShapeRenderer>().color = Color.blue;
            }
            else if (other.gameObject.GetComponent<SpriteShapeRenderer>().color == Color.blue)
            {
                score -= 200;
                life--;
            }
        }
        else if (other.transform.tag == "donottouchy")
        {
            score -= 50;
            ballRB.transform.position = new Vector2(0, 0);
            ballRB.velocity = new Vector2(0, 0);
            life--;
        }
    }
}