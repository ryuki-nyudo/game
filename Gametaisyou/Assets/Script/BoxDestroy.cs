using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroy : MonoBehaviour
{
    // 自身の子要素を管理するリスト
    List<GameObject> myParts = new List<GameObject>();

    GameObject Attackflag;
    public GameObject box;
    public BoxCollider2D col;

    public bool KAIsyutugen = false; //コライダーが消えたら貝を出現させるための判定

    // Start is called before the first frame update
    public void Start()
    {
        Attackflag = GameObject.Find("player");

        // 自分の子要素をチェック
        foreach (Transform child in gameObject.transform)
        {

            // ビルパーツに Rigidbody2D を追加して Kinematic にしておく
            child.gameObject.AddComponent<Rigidbody2D>();
            child.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

            // 子要素リストにパーツを追加
            myParts.Add(child.gameObject);

        }
    }

    // Update is called once per frame
    //public void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
           
    //    }
    //}

    //void boxdestroy()
    //{
    //    Destroy(this.gameObject);
    //    box.SetActive(false);
    //    Debug.Log("けした");
    //}

    public void Explode()
    {
        Debug.Log("huttonnda");
        // 各パーツをふっとばす
        foreach (GameObject obj in myParts)
        {
            
            // 飛ばすパワーと回転をランダムに設定
            Vector2 forcePower = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
            float torquePower = Random.Range(-10, 10);

            // パーツをふっとばす！
            obj.GetComponent<Rigidbody2D>().isKinematic = false;
            obj.GetComponent<Rigidbody2D>().AddForce(forcePower, ForceMode2D.Impulse);
            obj.GetComponent<Rigidbody2D>().AddTorque(torquePower, ForceMode2D.Impulse);


            
            col.enabled = false;　//コライダーを消す
            KAIsyutugen = true;　　　//貝を出現させる
            　
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Attackflag.GetComponent<Player>().attackflag == true)
        {
            
            Explode();
            
            //Invoke("boxdestroy", 0.01f);
        }
    }
}