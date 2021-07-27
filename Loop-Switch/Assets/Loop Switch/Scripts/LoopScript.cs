using UnityEngine;

public class LoopScript : MonoBehaviour {


	void Start () {
        	
	}
	
	void Update () {
        
        Rotate();
	}

    void Rotate()
    {
        transform.Rotate(Vector3.forward * GameManager.loopSpeed * Time.deltaTime);
    }
}
