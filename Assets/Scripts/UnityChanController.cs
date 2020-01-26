using System.Collections;
using UnityEngine;

public class UnityChanController : MonoBehaviour {
    Animator animator;
    Rigidbody2D rigid2D;

    float groundLevel1 = -3.0f; //地面の位置
    float dump = 0.8f;  //ジャンプの速度の減衰
    float jumpVelocity = 20;  //ジャンプの速度

    float deadLine = -9;  //ゲームオーバーになる位置

	void Start () {
        animator = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        //走るアニメーションを再生するために、Animatorのパラメータを調整する
        animator.SetFloat("Horizontal", 1);

        //着地しているかどうかを調べる
        bool isGround = (transform.position.y > groundLevel1) ? false : true;
        animator.SetBool("isGround", isGround);

        //ジャンプ状態のときにはボリュームを０にする
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //着地状態でクリックされた場合
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            //上方向の力をかける
            rigid2D.velocity = new Vector2(0, jumpVelocity);
        }

        //クリックをやめたら上方向への速度を減速する
        if(Input.GetMouseButton(0) == false)
        {
            if (rigid2D.velocity.y > 0)
            {
                rigid2D.velocity *= dump;
            }
        }

        //デッドラインを超えた場合ゲームオーバーにする
        if (transform.position.x < deadLine)
        {
            //UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //ユニティちゃんを破棄する
            Destroy(gameObject);
        }
	}
}
