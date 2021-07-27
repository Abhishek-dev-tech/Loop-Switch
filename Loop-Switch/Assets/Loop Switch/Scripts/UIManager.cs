using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject MenuUI;
    public GameObject InGameUI;
    public GameObject DeathUI;
    public GameObject settingBackground;

    public Button playBtn;
    public Button restartBtn;

    public Text highScoreText;
    public Text gameScoreText;
    public Text deathScoreText;

    public RectTransform settingHeader;
    public RectTransform sound;
    public RectTransform vibration;
    public RectTransform twitter;
    public RectTransform policy;
    public RectTransform backBtn;

    public static UIManager instance;

    bool isSoundOn = true;

    void Start () {
        StartScreen();
        instance = this;

        playBtn.onClick.AddListener(GameScreen);
        restartBtn.onClick.AddListener(Restart);

	}
	
	void Update () {
        gameScoreText.text = GameManager.score.ToString();
        deathScoreText.text = gameScoreText.text;
        if (GameManager.playerDead) DeathScreen(); GameManager.playerDead = false;
	}

    void SoundFunc()
    {
        if (isSoundOn)
        {
            isSoundOn = false;
            AudioListener.volume = 0f;
        }
        else
        {
            isSoundOn = true;
            AudioListener.volume = 1f;
        }
    }

    void GameScreen()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.buttonSound);
        playBtn.GetComponent<Animator>().Play("play");
        GameManager.inGame = true;
        MenuUI.SetActive(false);
        InGameUI.SetActive(true);
    }

    void StartScreen()
    {
        MenuUI.SetActive(true);
        InGameUI.SetActive(false);
        DeathUI.SetActive(false);
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore", 0).ToString();
    }

    public void DeathScreen()
    {
        restartBtn.GetComponent<Animator>().Play("play");
        MenuUI.SetActive(false);
        InGameUI.SetActive(false);
        DeathUI.SetActive(true);
        if(GameManager.score >= PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", GameManager.score);
        }
    }

    public void Restart()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.buttonSound);
        SceneManager.LoadScene(0);
    }

    public void Setting()
    {
        if(!settingBackground.activeInHierarchy)
        {
            settingBackground.SetActive(true);
            MoveUIManager.instance.MoveX("SettingHeader",settingHeader,MoveUIManager.StartOrEnd.start);
            MoveUIManager.instance.MoveX("Sound",sound,MoveUIManager.StartOrEnd.start);
            MoveUIManager.instance.MoveX("Vibration",vibration,MoveUIManager.StartOrEnd.start);
            MoveUIManager.instance.MoveX("Twitter",twitter,MoveUIManager.StartOrEnd.start);
            MoveUIManager.instance.MoveX("Policy",policy,MoveUIManager.StartOrEnd.start);
            MoveUIManager.instance.MoveX("Back",backBtn,MoveUIManager.StartOrEnd.start);
        }
        else
        {
            MoveUIManager.instance.MoveX("SettingHeader",settingHeader,MoveUIManager.StartOrEnd.end);
            MoveUIManager.instance.MoveX("Sound",sound,MoveUIManager.StartOrEnd.end);
            MoveUIManager.instance.MoveX("Vibration",vibration,MoveUIManager.StartOrEnd.end);
            MoveUIManager.instance.MoveX("Twitter",twitter,MoveUIManager.StartOrEnd.end);
            MoveUIManager.instance.MoveX("Policy",policy,MoveUIManager.StartOrEnd.end);
            MoveUIManager.instance.MoveX("Back",backBtn,MoveUIManager.StartOrEnd.end);
            settingBackground.SetActive(false);
        }

    }


}
