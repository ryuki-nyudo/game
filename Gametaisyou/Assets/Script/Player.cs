using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed;
    public float attackspeed = 18;

    //GameObject Enemy;
    //EnemyBehaviourScript script;

    float seconds;
    AudioSource audioSource;
    public AudioClip Sound1;

    public Vector3 force = new Vector3(-0.5f, 0.0f, 0.0f);
    private Rigidbody2D rb;


    public bool iflag;


    public bool attackflag;
    public bool slow;

    bool tap = true;
    int maxSt = 100;
    double currentSt;

    public Slider slider;

    public float enemypower = 400;
    public bool nock;
    public float ntime;
    public float nTimer = 0.5f;

    public GameObject AttackEffect;

    public bool goalitem;
    // public GameObject MPitem;
    // MPitem key;

    void Start()
    {
        // MPitem = GameObject.Find("key");
        // key = MPItem.GetComponent<itemScript>();
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        iflag = false;

        attackflag = false;
        slow = false;

        slider.value = 1;
        currentSt = maxSt;

        nock = false;

        goalitem = false;

        //Enemy = GameObject.Find("Enemy");
        //script = Enemy.GetComponent<EnemyBehaviourScript>();
    }
    void Update()
    {
        ntime += Time.deltaTime;
    }

    // 物理演算をしたい場合はFixedUpdateを使うのが一般的
    void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        if (nock == false && ntime >= nTimer)
        {
            //右入力で左向きに動く
            if (horizontal > 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                Accel();
            }
            //左入力で左向きに動く
            else if (horizontal < 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                Accel();


            }

            //上入力で上向きに動く
            if (vertical > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);

                Accel();

                //rb.AddForce(force, ForceMode2D.Force);

            }
            //下入力で下向きに動く
            else if (vertical < 0)
            {

                rb.velocity = new Vector2(rb.velocity.x, -speed);
                Accel();

            }
            if (currentSt < maxSt)
            {
                currentSt += 0.09;
                slider.value = (float)currentSt / (float)maxSt;
                if (slow == true)
                {
                    speed = 1;
                    currentSt += 0.35;
                    slider.value = (float)currentSt / (float)maxSt; ;
                    if (currentSt > 70)
                    {
                        slow = false;
                        speed = 3;
                    }
                }
            }
            if (currentSt < 10)
            {
                slow = true;
            }
        }

    }

    public void Accel()
    {
        if (Input.GetKeyDown(KeyCode.Space) /*&& mpitem.iflag = false*/)
        {
            if (tap == true)
            {
                if (slow == false)
                {
                    if (currentSt >= 10)
                    {
                        //Effect();
                        int move = 10;

                        currentSt = currentSt - move;

                        slider.value = (float)currentSt / (float)maxSt; ;
                        tap = false;
                        speed += attackspeed;
                        attackflag = true;
                        Invoke("Decelerate", 0.3f);
                        //Destroy(AttackEffect);
                    }
                }
            }
        }
        else if (Input.GetKeyDown("joystick button 1") /*&& mpitem.iflag = true*/)
        {
            if (tap == true)
            {
                if (slow == false)
                {
                    if (currentSt >= 10)
                    {
                        //Effect();
                        audioSource.PlayOneShot(Sound1);
                        int move = 10;

                        currentSt = currentSt - move;

                        slider.value = (float)currentSt / (float)maxSt; ;
                        tap = false;
                        speed += attackspeed;
                        attackflag = true;
                        Invoke("Decelerate", 0.3f);
                        //Destroy(AttackEffect);
                    }
                }
            }
        }

    }

    //void Update()
    //{

    //    int kkarisu = script.karisu;

    //    if (kkarisu == 1)
    //    {
    //        rb.AddForce(force, ForceMode2D.Impulse);
    //    }

    //}
    void Decelerate()
    {
        //if(mpitem.iflag == fasle){
        speed -= attackspeed;
        attackflag = false;
        tap = true;
        // }
        // else if(mpitem.iflag == true){
        //     speed -= 18;
        //     attackflag = false;
        //     tap = true;
        // }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            //キー入力無効＆ノックバック
            nock = true;
            if (nock == true)
            {
                ntime = 0f;
                Vector3 distination = (transform.position - collision.gameObject.transform.position).normalized;
                rb.AddForce(distination * enemypower, ForceMode2D.Impulse);
                //Camera.main.gameObject.GetComponent<ShakeCamera>().Shake();
                nock = false;
                Shake();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "goalitem")
        {
            Destroy(other.gameObject);
            goalitem = true;
        }
    }

    void Effect()
    {
        Debug.Log("deta");
        GameObject effect = Instantiate(AttackEffect) as GameObject;
        effect.transform.position = gameObject.transform.position;
    }
    private void Shake()
    {
        Gamepad gamepad = Gamepad.current;
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0.5f, 1.0f);
            Debug.Log("Shake");
        }
    }
}