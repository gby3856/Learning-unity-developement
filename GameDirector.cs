using TMPro;
using UnityEngine;
using UnityEngine.UI; //UI를 사용하므로 잊지 않고 추가
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

        this.startGame.gameObject.SetActive(true);    // 시작 버튼만 표시
        this.RestartGame.gameObject.SetActive(false); // 처음에는 Restart 버튼 숨김

        if (startGame != null) //스타트게임 누르면 
        {
            startGame.onClick.AddListener(StartGame); // 스타트게임 메서드 실행
        }

        if (RestartGame != null)
        {
            RestartGame.onClick.AddListener(restartGame);
        }
    }
    
    public void StartGame() //게임 플레이 중에 필요한 오브젝트 모두 활성화, 그 외의 것은 비활성화
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
        this.hpGauge.GetComponent<UnityEngine.UI.Image>().fillAmount -= 0.1f; //UnityEngine.UI.Image 라고 써야함!
    }

    public void IncreaseHp()
    {
        this.hpGauge.GetComponent<UnityEngine.UI.Image>().fillAmount += 0.1f;
    }

   

    void Update()
    {
        if (player == null) return;

        if (this.hpGauge.GetComponent<UnityEngine.UI.Image>().fillAmount > 0) //아직 체력이 남아서 게임 플레이 중 상태일 때
        {
            scoreText.text = "Score: " + Mathf.FloorToInt(CalculateScore());
        }
        else //게임 오버 시
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
        
        if(this.player.transform.position.x <-12 || this.player.transform.position.x > 12) //플레이어가 화면 밖으로 이동하면 게임오버
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
