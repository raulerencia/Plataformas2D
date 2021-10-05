using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int starsCount = 0;

    public Text contadorEstrellas;

    public int lives;
    public int score;
    public Text score_Text;
    public GameObject heart3;
    public GameObject heart2;
    public GameObject heart1;
    public GameObject victoryBox;
    public GameObject gameOverBox;

    public GameObject cam;


    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        score = 4;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        contadorEstrellas.text = starsCount + "";
        
        if (starsCount == score)
        {
            victoryBox.SetActive(true);
        }
    }

    public void sumar()
    {
        starsCount++;
    }

    public void LoseLive()
    {
        lives--;
        if (lives == 2)
        {
            heart3.SetActive(false);
            StartCoroutine(cam.GetComponent<CameraShake>().Shake(0.4f, 0.06f));
        }
        if (lives == 1)
        {
            heart2.SetActive(false);
            StartCoroutine(cam.GetComponent<CameraShake>().Shake(0.4f, 0.06f));
        }
        if (lives == 0)
        {
            heart1.SetActive(false);
            StartCoroutine(cam.GetComponent<CameraShake>().Shake(0.4f, 0.06f));
            gameOverBox.SetActive(true);
        }

    }

}
