using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public string currentcolor;
    public float jumpforce = 10f;
    public Rigidbody2D circle;
    public SpriteRenderer sr;
    public Color Blue;
    public Color Pink;
    public Color Purple;
    public Color Yellow;
    public static int score = 0;
    public Text scoretext;
    public GameObject[] obstacle;
    public GameObject colorchanger;
    
    void Start()
    {
        setRandomColor();
        PauseGame();
      
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
   
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            ResumeGame();
            circle.velocity = Vector2.up * jumpforce;
            
        }

        scoretext.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Scored")
        {
            score++;
            Destroy(collision.gameObject);
            int randomnumber = Random.Range(0, 2);
            if(randomnumber == 0)
            Instantiate(obstacle[0], new Vector2(transform.position.x, transform.position.y + 8f), Quaternion.identity);
            else
                Instantiate(obstacle[1], new Vector2(transform.position.x, transform.position.y + 8f), Quaternion.identity);

            return;
        }

        if(collision.tag == "ColorChanger")
        {
            setRandomColor();
            Destroy(collision.gameObject);
            Instantiate(colorchanger, new Vector2(transform.position.x, transform.position.y + 8f), transform.rotation);

            return;
        }

       if(collision.tag != currentcolor)
        {
            Debug.Log("You are Dead");
            score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void setRandomColor()
    {
        int rand = Random.Range(0, 4);

        switch(rand)
        {
            case 0:
                currentcolor = "Blue";
                sr.color = Blue;
                break;
            case 1:
                currentcolor = "Yellow";
                sr.color = Yellow;
                break;
            case 2:
                currentcolor = "Pink";
                sr.color = Pink;
                break;
            case 3:
                currentcolor = "Purple";
                sr.color = Purple;
                break;



        }
    }



}



