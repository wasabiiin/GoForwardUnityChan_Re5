using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//(追加8-1)

public class UIController : MonoBehaviour {

    //ゲームオーバーテキスト
    private GameObject gameOverText;

    //走行距離テキスト
    private GameObject runLengthText;

    //走った距離
    private float len = 0;

    //走る速度
    private float speed = 0.03f;

    //ゲームオーバーの判定
    private bool isGameOver = false;


    //Usethis for initialization
    private void Start(){
        //シーンビューからのオブジェクトの実態を検索する
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
        
    }


    //Update is called once per frame
    private void Update()
    {
        if (this.isGameOver == false) {
            //走った距離を更新する
            this.len += this.speed;
            //走った距離を表示する
            this.runLengthText.GetComponent<Text>().text = "Distance:  " + len.ToString("F2") + "m";
        }

        //ゲームオーバーになった場合
        if (this.isGameOver) {
            //クリックされたらシーンをロードする(追加8-1)
            if (Input.GetMouseButtonDown(0)) {
                //GameSceneを読み込む(追加8-1)
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    public void GameOver()
    {
        //ゲームオーバーになったときに、画面上にゲームオーバーを表示する
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        this.isGameOver = true;
    }

}