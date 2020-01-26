using System.Collections;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {
    public GameObject cubePrefab;

    float delta = 0;  //時間計測用の変数
    float span = 1.0f;　//キューブの生成間隔
    float genPosX = 12;  //キューブの生成位置：X座標

    float offsetY = 0.3f;  //キューブの生成位置オフセット
    float spaceY = 6.9f;  //キューブの縦方向の間隔

    float offsetX = 0.5f;  //キューブの生成位置オフセット
    float spaceX = 0.4f;  //キューブの横方向の間隔

    int maxBlockNum = 4;  //キューブの生成個数の上限
    
	void Update () {
        delta += Time.deltaTime;

        //span秒以上の時間が経過したかを調べる
        if (delta > span)
        {
            delta = 0;  //経過時間のリセット
            //生成するキューブ数をランダムに決める
            int n = Random.Range(1, maxBlockNum + 1);

            //指定した数だけキューブを生成する
            for (int i = 0; i < n; i++)
            {
                //キューブの生成
                GameObject go = Instantiate(cubePrefab) as GameObject;
                go.transform.position = new Vector2(genPosX, offsetY + i * spaceY);
            }
            //次のキューブまでの生成時間を決める
            span = offsetX + spaceX * n;
        }
	}
}
