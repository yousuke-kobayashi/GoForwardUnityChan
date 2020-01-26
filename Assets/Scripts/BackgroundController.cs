using System.Collections;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    float scrollSpeed = -0.03f;  //スクロール速度
    float deadLine = -16;  //背景終了位置
    float startLine = 15.8f;  //背景開始位置
    
	void Update () {
        //背景を移動する
        transform.Translate(scrollSpeed, 0, 0);

        //画面外に出たら、画面右端に移動する
        if (transform.position.x < deadLine)
        {
            transform.position = new Vector2(startLine, 0);
        }
	}
}
