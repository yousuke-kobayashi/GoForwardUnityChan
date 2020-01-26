using System.Collections;
using UnityEngine;

public class CubeController : MonoBehaviour {
    public AudioClip block;
    AudioSource audioSource;

    float speed = -12;  //キューブの移動速度
    float deadLine = -10;  //消滅位置

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void Update () {
        //キューブを移動させる
        transform.Translate(speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄する
        if (transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
	}

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Cube")
        {
            audioSource.PlayOneShot(block);
        }
    }
}
