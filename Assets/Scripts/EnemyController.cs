using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Health;
    public float MaxSpeed;
    public float AccelerationRate;

    // Private Variables
    float Speed;
    float DriftFactor;
    GameObject Player;
    Vector2 PlayerDirection;
    Vector2 PreviousPlayerDirection;
    Rigidbody2D rb;
    BoxCollider2D col;

    public GameObject dieAnim;

    [SerializeField] GameObject m_sound;
    [SerializeField] private GameObject hit1, hit2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        Player = GameObject.FindWithTag("Player");
        DriftFactor = 1;
    }

    void Update()
    {
        //Should I rotate towards Player ?
        PlayerDirection = Player.transform.position - transform.position;
        if(Mathf.Sign(PlayerDirection.x) != Mathf.Sign(PreviousPlayerDirection.x))
        {
            RotateTowardsPlayer();
        }
        PreviousPlayerDirection = PlayerDirection;

        //Go towards Player
        rb.velocity = new Vector2(transform.forward.z * DriftFactor * Speed * Time.fixedDeltaTime, rb.velocity.y);

        //Die
        if(Health <= 0)
        {
            GameObject go = Instantiate<GameObject>(dieAnim);
            go.transform.position = transform.position;
            GameObject go7 = Instantiate<GameObject>(m_sound);
            

            ScoreManager.scoreManagerIstance.addScore();
            Destroy(gameObject);


        }

        if(Speed <= 0)
        {
            StartCoroutine(GetToSpeed(MaxSpeed));
        }
        //Debug.Log(Speed);
    }

    public void GetDamage(float dmg)
    {
        Health -= dmg;
        int rdm = Random.Range(0, 2);
        //Debug.Log(rdm);
        if (Health <= 0) return;
        if(rdm == 1)
        {
            GameObject go3 = Instantiate<GameObject>(hit2);
            go3.transform.position = transform.position;
            return;
        }

          GameObject go2 = Instantiate<GameObject>(hit1);
          go2.transform.position = transform.position;
        
    }

    void RotateTowardsPlayer()
    {
        if (PlayerDirection.x < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        DriftFactor = -1;
        StartCoroutine(GetToSpeed(0));
    }

    IEnumerator GetToSpeed( float s)
    {
        //Debug.Log(s);
        float baseSpeed = Speed;
        float SignMultiplier = Mathf.Sign(s - Speed);
        for(float f=baseSpeed; f*SignMultiplier<=s; f += AccelerationRate*SignMultiplier)
        {
            Speed = f;
            yield return null;
        }
        DriftFactor = 1;
    }
}
