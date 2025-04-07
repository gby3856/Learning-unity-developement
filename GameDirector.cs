using TMPro;
using UnityEngine;
using UnityEngine.UI; //UI�� ����ϹǷ� ���� �ʰ� �߰�
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public class GameDirector : MonoBehaviour
{
    public static GameDirector Instance;

    [Header("References")]
    public GameObject jellyfishgenerator;
    public GameObject arrowgenerator;
    GameObject hpGauge;
    GameObject player;
    public GameObject GameOver;
    public GameObject title;
    public Button RestartGame;
    public Button startGame;
    public Button LButton;
    public Button RButton;
    public GameObject knifeanim;
    public GameObject heartinfo;
    float PlayStartTime;
    public TMP_Text scoreText;
    public TMP_Text HP;
    public float KnifeStartSpeed;
    public float knifeSpeedIncrease;
    public float maximumKnifeSpeed;
    public float subDropSpeed;
    public float speedIncreaseScoreCut;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public float subdropspeed()
    {
        return subDropSpeed;
    }
    public float CalculateGameSpeed()
    {
        float speed = KnifeStartSpeed + (knifeSpeedIncrease* Mathf.Floor(CalculateScore() / speedIncreaseScoreCut));
        return Mathf.Min(speed, maximumKnifeSpeed);
    }
    float CalculateScore()
    {
        return Time.time - PlayStartTime;
    }
    void SaveHighScore()
    {
        int score = Mathf.FloorToInt(CalculateScore());
        int currentHighScore = PlayerPrefs.GetInt("highScore");
        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
        }
    }
    int GetHighScore()
    {
        return PlayerPrefs.GetInt("highScore");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.knifeanim.SetActive(true);
        this.heartinfo.SetActive(true);
        this.hpGauge = GameObject.Find("hpGauge");
        this.player = GameObject.Find("player_0");
        this.jellyfishgenerator.SetActive(false);
        this.arrowgenerator.SetActive(false);
        this.LButton.gameObject.SetActive(false);
        this.RButton.gameObject.SetActive(false);
        this.hpGauge.SetActive(false);
        this.scoreText.gameObject.SetActive(false);
        this.HP.gameObject.SetActive(false);
        this.GameOver.SetActive(false);
        this.title.SetActive(true);

        this.startGame.gameObject.SetActive(true);    // ���� ��ư�� ǥ��
        this.RestartGame.gameObject.SetActive(false); // ó������ Restart ��ư ����

        if (startGame != null) //��ŸƮ���� ������ 
        {
            startGame.onClick.AddListener(StartGame); // ��ŸƮ���� �޼��� ����
        }

        if (RestartGame != null)
        {
            RestartGame.onClick.AddListener(restartGame);
        }
    }
    
    public void StartGame() //���� �÷��� �߿� �ʿ��� ������Ʈ ��� Ȱ��ȭ, �� ���� ���� ��Ȱ��ȭ
    {
        this.title.SetActive(false);
        this.startGame.gameObject.SetActive(false);
        this.LButton.gameObject.SetActive(true);
        this.RButton.gameObject.SetActive(true);
        this.hpGauge.SetActive(true);
        this.jellyfishgenerator.SetActive(true);
        this.arrowgenerator.SetActive(true);
        this.scoreText.gameObject.SetActive(true);
        this.HP.gameObject.SetActive(true);
        this.knifeanim.SetActive(false);
        this.heartinfo.SetActive(false);
        this.PlayStartTime = Time.time;
        
    }
    public void restartGame()
    {
        this.PlayStartTime=0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void DecreaseHp()
    {
        this.hpGauge.GetComponent<UnityEngine.UI.Image>().fillAmount -= 0.1f; //UnityEngine.UI.Image ��� �����!
    }

    public void IncreaseHp()
    {
        this.hpGauge.GetComponent<UnityEngine.UI.Image>().fillAmount += 0.1f;
    }

   

    void Update()
    {
        if (player == null) return;

        if (this.hpGauge.GetComponent<UnityEngine.UI.Image>().fillAmount > 0) //���� ü���� ���Ƽ� ���� �÷��� �� ������ ��
        {
            scoreText.text = "Score: " + Mathf.FloorToInt(CalculateScore());
        }
        else //���� ���� ��
        {
            this.jellyfishgenerator.SetActive(false);
            this.arrowgenerator.SetActive(false);
            Destroy(player);
            this.GameOver.SetActive(true);
            this.LButton.gameObject.SetActive(false);
            this.RButton.gameObject.SetActive(false);
            this.hpGauge.SetActive(false);
            this.HP.gameObject.SetActive(false);
            GetHighScore();
            SaveHighScore();
            scoreText.text = "Top Score: " + GetHighScore();
            this.RestartGame.gameObject.SetActive(true);
        }
        
        if(this.player.transform.position.x <-12 || this.player.transform.position.x > 12) //�÷��̾ ȭ�� ������ �̵��ϸ� ���ӿ���
        {
            this.jellyfishgenerator.SetActive(false);
            this.arrowgenerator.SetActive(false);
            Destroy(player);
            this.GameOver.SetActive(true);
            this.LButton.gameObject.SetActive(false);
            this.RButton.gameObject.SetActive(false);
            this.hpGauge.SetActive(false);
            this.HP.gameObject.SetActive(false);
            GetHighScore();
            SaveHighScore();
            scoreText.text = "Top Score: " + GetHighScore();
            this.RestartGame.gameObject.SetActive(true);
        }
    }
}
