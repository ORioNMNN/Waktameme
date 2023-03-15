using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerJumpPower = 10;
    public int playerType = 1;
    [SerializeField]
    private Rigidbody2D rid;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private StageData  stageData;
    private Movement2D movement2D;
    public static PlayerHP    playerHP;
    private int maxJump = 1;
    private int jumpCount = 0;
    private GameObject HPControl;

    [Header("Collision")]
    [SerializeField]
    private LayerMask   groundLayer;    // 바닥 충돌 체크를 위한 레이	

    private bool        isGrounded;     // 바닥 체크
    private Vector2     footposition;   // 바닥 체크를 위한 플레이어 발 위치
    private Vector2     footArea;       // 바닥 체크를 위한 플레이어 발 인식 범위


    private new Collider2D collider2D; // 현재 오브젝트의 충돌 범위 정보
    // Start is called before the first frame update
    private void Awake()
    {
        rid        = GetComponent<Rigidbody2D>();
        movement2D = GetComponent<Movement2D>();
        playerHP   = GetComponent<PlayerHP>();
        collider2D = GetComponent<Collider2D>();
        if(playerType == 1)
        {
            maxJump = 2;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if ( gameController.IsGamePlay == false) return;
        PlayerMove();
        PlayerJump();
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement2D.MoveTo(new Vector3(1, 0, 0));

        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {

            movement2D.MoveTo(new Vector3(-1, 0, 0));


        }

        else
        {
            movement2D.MoveTo(new Vector3(0, 0, 0));
        }
    }
    private void PlayerJump()
    {
        // 플레이어 오브젝트의 Collider2D min, center, max 위치정보 
        Bounds bounds = collider2D.bounds;
        // 플레이어의 발 위치 설정
        footposition = new Vector2(bounds.center.x, bounds.min.y);
        // 플레이어의 발 인식 범위 설정
        footArea = new Vector2((bounds.max.x - bounds.min.x) * 0.5f, 0.1f);
        // 플레이어의 발 위치에 박스를 생성하, 박스가 바닥과 닿아있으면 isGrounded = true
        isGrounded = Physics2D.OverlapBox(footposition, footArea, 0, groundLayer);

        if (isGrounded == true && rid.velocity.y <= 0)
        {
           jumpCount = 0;
        }    

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount <= maxJump)
        {
            rid.velocity = Vector2.up * playerJumpPower;
            jumpCount++;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int timer = 0;
        if ( collision.CompareTag("Obstacle") && playerType != 5 )
        {

            bool isDie = playerHP.TakeDamage();
            if (isDie == true)
            {
                while(timer < 500)
                {
                    timer++;
                }
                GetComponent<Collider2D>().enabled = false;
                gameController.GameOver();
            }    
        }

        if ( collision.CompareTag("heal") )
        {
            bool isHeal = playerHP.TakeHeal();

        }

     
    }
}
