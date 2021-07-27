using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public static int score;

    public static bool inGame;

    public static bool playerDead;

    public static float loopSpeed;

    [Header("Links")]
    public string twitterLink;
    public string policyLink;

    void Start () {
        MakeSingleton();
        score = 0;
        inGame = false;
        playerDead = false;
        loopSpeed = 80f;
	}
	
	void Update () {
		
	}

    void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleVibrate()
    {
        if(PlayerPrefs.GetInt("Vibration", 1) == 0)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Vibration", 0);
        }
    }

    public void OpenTwitter()
    {
        Application.OpenURL(twitterLink);
    }

    public void OpenPolicy()
    {
        Application.OpenURL(policyLink);
    }
}
