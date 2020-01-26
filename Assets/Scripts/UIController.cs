using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    GameObject gameOverText;
    GameObject runLengthText;

    float len = 0;  //走った距離
    float speed = 0.03f;  //走る速度

    bool isGameOver = false;  //ゲームオーバーの判定

	void Start () {
        //シーンビューからオブジェクトの実体を検索する
        gameOverText = GameObject.Find("GameOver");
        runLengthText = GameObject.Find("RunLength");
	}
	
	void Update () {
		if (isGameOver == false)
        {
            //走った距離を更新する
            len += speed;
            //走った距離を表示する
            runLengthText.GetComponent<Text>().text = "Distance: " + len.ToString("F2") + "m";
        }

        //ゲームオーバーになった場合
        if (isGameOver == true)
        {
            //クリックされたらシーンをロードする
            if (Input.GetMouseButtonDown(0))
            {
                //GameSceneを読み込む
                SceneManager.LoadScene("GameScene");
            }
        }
	}

    public void GameOver()
    {
        //ゲームオーバーになったときに、画面上にゲームオーバーを表示する
        gameOverText.GetComponent<Text>().text = "GameOver";
        isGameOver = true;
    }
}
