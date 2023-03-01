using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerJumpPower = 10;
    Rigidbody2D rid;

    [SerializeField]
    private GameController gameController;

    [SerializeField]
    private StageData  stageData;
    private Movement2D movement2D;
    public static PlayerHP    playerHP;
     
    // Start is called before the first frame update
    private void Awake()
    {
        rid        = GetComponent<Rigidbody2D>();
        movement2D = GetComponent<Movement2D>();
        playerHP   = GetComponent<PlayerHP>();

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rid.velocity = Vector2.up * playerJumpPower;

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int timer = 0;
        if ( collision.CompareTag("Obstacle") )
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
    }
}
