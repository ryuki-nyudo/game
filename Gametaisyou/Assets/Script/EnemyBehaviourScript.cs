using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    // 2Dリジッドボディを受け取る変数
    Rigidbody2D rb2D;
    // アニメーション制御のやつ
    Animator anim;
    public float move_speed = 10f; //追跡スピード
    GameObject PlayerObject; // playerオブジェクトを受け取る器
    public Transform Player; // プレイヤーの座標情報などを受け取る器

    // Start is called before the first frame update
    void Start()
    {
        // アニメーター（アニメーション制御のやつ）を受け取る
        anim = GetComponent("Animator") as Animator;
        // ここで2Dリジッドボディを受け取る。
        rb2D = GetComponent<Rigidbody2D>();
        PlayerObject = GameObject.Find("player");
        Player = PlayerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 scale = transform.localScale;
        transform.localScale = scale;
        Vector2 e_pos = transform.position;  // 自分(敵キャラクタ)の世界座標
        Vector2 p_pos = Player.position;  // プレイヤーの世界座標
        // プレイヤーの方向に動くベクトル(move_speedで速度を調整)
        Vector2 force = (p_pos - e_pos) * move_speed;
        rb2D.AddForce(force, ForceMode2D.Force);



        // 境界外判定
        // -----------------
        // 画面の左下の座標を取得 (左上じゃないので注意)
        Vector2 screen_LeftBottom = Camera.main.ScreenToWorldPoint(Vector3.zero);
        // 画面の右上の座標を取得 (右下じゃないので注意)
        Vector2 screen_RightTop = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, 0)
            );
        // 現在の敵キャラクターの移動情報(向きと強さ)
        Vector2 enemy_velocity = rb2D.velocity;
        // 現在の敵キャラクターの位置座標
        Vector2 enemy_pos = transform.position;
        // 画面左端に達した時、プレイヤーが左方向に動いていたら、右方向の力に反転する
        if ((enemy_pos.x < screen_LeftBottom.x) && (enemy_velocity.x < 0))
            enemy_velocity.x *= -1;
        // 画面右端に達した時、プレイヤーが右方向に動いていたら、左方向の力に反転する
        if ((enemy_pos.x > screen_RightTop.x) && (enemy_velocity.x > 0))
            enemy_velocity.x *= -1;
        // 画面上端に達した時、プレイヤーが上方向に動いていたら、下方向の力に反転する
        if ((enemy_pos.y > screen_RightTop.y) && (enemy_velocity.y > 0))
            enemy_velocity.y *= -1;
        // 更新
        rb2D.velocity = enemy_velocity;
    }
}