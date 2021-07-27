using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public static CameraFollow instance;
    Transform target;
    public float cameraOffsetY = 2f;
    public float speed = 1f;
    public Color[] colors;
    public float lerpFactor = 1f;

	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        instance = this;
	}
	
	void Update () {
        if (target == null) return;
        this.transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y + cameraOffsetY, target.position.z - 10), Time.deltaTime * speed);
    }

    public void ColorChange()
    {
        int idx = Random.Range(0, colors.Length);
        Color oldColor = GetComponent<Camera>().backgroundColor;
        GetComponent<Camera>().backgroundColor = Color.Lerp(oldColor, colors[idx], lerpFactor * Time.deltaTime);
    }
}
