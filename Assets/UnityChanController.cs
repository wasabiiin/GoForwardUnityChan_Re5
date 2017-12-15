using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnityChanController : MonoBehaviour {
    //アニメーションするためのコンポーネントを入れる
    Animator animator;

    //Unityちゃんを移動させるコンポーネントを入れる(追加4-5)
    Rigidbody2D rigid2D;

    //地面の位置
    private float groundLevel = -3.0f;

    //ジャンプの速度の減衰(追加4-5)
    private float dump = 0.8f;

    //ジャンプの速度(追加4-5)
    float jumpVelocity = 22;

    //ゲームオーバーになる位置(追加7-4)
    private float deadLine = -9;



    // Use this for initialization
    void Start () {
        //アニメータのコンポーネントを取得する
        this.animator = GetComponent<Animator>();

        //Rigidbody2Dのコンポーネントを取得する(追加4-5)
        this.rigid2D = GetComponent<Rigidbody2D>();

    }


    // Update is called once per frame
    void Update () {
        //走るアニメーションを再生するために、Animatorのパラメーターを調整する
        this.animator.SetFloat("Horizontal", 3);

        //着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //ジャンプ状態のときにはボリュームを０にする
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //着地状態でクリックされた場合(追加4-5)
        if (Input.GetMouseButtonDown(0) && isGround) {
            //上方向の力をかける(追加4-5)
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        //クリックをやめたら上方向への速度を減速する(追加4-5)
        if (Input.GetMouseButton (0) == false) {
            if (this.rigid2D.velocity.y > 0) {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //デッドラインを超えた場合ゲームオーバーにする(追加7-4)
        if (transform.position.x < this.deadLine) {
            //UIContorollerのGameOver関数を呼び出して画面上に「GameOver」と表記する(追加7-4)
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //ユニティちゃんを破棄する(追加7-4)
            Destroy(gameObject);
        }

    }
}
