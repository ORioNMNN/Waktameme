using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;


public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameController gameContoller;

    [Header("Main UI")]
    [SerializeField]
    private GameObject mainPanel;
    [SerializeField]
    private TextMeshProUGUI textMainGrade;
    [SerializeField]
    private TextMeshProUGUI textMainScore;

    [Header("Game UI")]
    [SerializeField]
    private GameObject      gamePanel;
    [SerializeField]
    private TextMeshProUGUI textScore;

    [Header("Result UI")]
    [SerializeField]
    private GameObject      resultPanel;
    [SerializeField]
    private TextMeshProUGUI textResultScore;
    [SerializeField]
    private TextMeshProUGUI textResultGrade;
    [SerializeField]
    private TextMeshProUGUI textResultHighScore;

    [Header("Shop UI")]
    [SerializeField]
    private GameObject shopPanel;



    private void Awake()
    {
        textMainGrade.text = PlayerPrefs.GetString("HIGHGRADE");
    }

    public void GameStart()
    {
        mainPanel.SetActive(false);
        gamePanel.SetActive(true);

    }
    public void GameOver()
    {
        int currentScore = (int)gameContoller.CurrentScore;

        textResultScore.text = currentScore.ToString(); // ???? ???? ????
        CalculateGradeAndTalk(currentScore);
        CalculateHighScore(currentScore);



        gamePanel.SetActive(false);
        resultPanel.SetActive(true);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoShop()
    {
        gamePanel.SetActive(false);
        shopPanel.SetActive(true);
    }    
    private void Update()
    {
        textScore.text = gameContoller.CurrentScore.ToString("F0");
    }

    private void CalculateGradeAndTalk(int score)
    {
        if (score < 2000)
        {
            textResultGrade.text = "F";
        }

        if (score < 2000)
        {
            textResultGrade.text = "D";
        }

        if (score < 2000)
        {
            textResultGrade.text = "C";
        }

        if (score < 2000)
        {
            textResultGrade.text = "B";
        }

        if (score < 2000)
        {
            textResultGrade.text = "A";
        }

    }

    private void CalculateHighScore(int score)
    {
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");

        if( score > highScore)
        {
            PlayerPrefs.SetString("HIGHSCORE", textResultGrade.text);
            // ???? ???? ????
            PlayerPrefs.SetInt("HIGHSCORE", score);
            // ???? ???? ????

            textResultHighScore.text = score.ToString();
        }

        else
        {
            textResultHighScore.text = highScore.ToString();
        }
    }
}









