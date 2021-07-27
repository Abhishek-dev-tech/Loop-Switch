using UnityEngine;

public class PlayerScript : MonoBehaviour {

    Vector2 target;
    public float speed = 1f;

	void Start () {
        target = this.transform.position;
    }
	void Update () {
        if (!GameManager.inGame) return;
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.score++;
            CameraFollow.instance.ColorChange();
            Move();
            SpawnManager.instance.Spawn();
        }
        this.transform.position = Vector2.Lerp(transform.position, target, speed);
    }

    void Move()
    {
        if (GameManager.loopSpeed <= 150)
        {
            GameManager.loopSpeed += 1;
        }
        SoundManager.Instance.PlaySound(SoundManager.Instance.moveSound);
        //CameraShaker.Instance.ShakeOnce(2f, 2f, .05f, .05f);
        Vector2 tempTarget = target;

        if(SpawnManager.instance.axis == 1)
            tempTarget.y += 2;
        if (SpawnManager.instance.axis == -1)
            tempTarget.x += 2;

        target = tempTarget;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if(collision.gameObject.tag == "Loop")
        {
            Destroy(this.gameObject);
            GameManager.playerDead = true;
            //CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
            if (PlayerPrefs.GetInt("Vibration", 1) == 1)
                Handheld.Vibrate();
        }

    }
    
}
