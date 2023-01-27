using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float PLAYER_STEP_ON_Y_POS_MIN = 0.7f;
    public AudioClip deathSound = default;
    public float jumpForce = default;
    private int jumpCount = default;
    private bool isGrounded = false;
    private bool isDead = false;
    

#region  Player's Components
    private Rigidbody2D playerRigid = default;
    private Animator playerAni = default;
    private AudioSource playerAudio = default; 
#endregion // player components
    // Start is called before the first frame update
    void Start()
    {
        // set player component
        playerRigid =   gameObject.GetComponentMust<Rigidbody2D>();
        playerAni   =   gameObject.GetComponentMust<Animator>();
        playerAudio =   gameObject.GetComponentMust<AudioSource>();

        // GFunc.Assert(playerRigid != null || playerRigid != default);
        // GFunc.Assert(playerAni != null || playerAni != default);
        // GFunc.Assert(playerAudio != null || playerAudio != default);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            return;
        }
        Jump();
        AnimPropertyUpdate();
    }

    // Player Die
    private void Die()
    {
        playerAni.SetTrigger("Die");
        playerAudio.clip = deathSound;
        playerAudio.Play();
        playerRigid.velocity = Vector2.zero;
        isDead = true;

        GameManager.instance.OnPlayerDead();
    }
    private void Jump()
    {
        if(Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            // 점프 횟수 증가
            jumpCount++;
            // 점프 직전에 속도를 순간적으로 제로(0, 0)로 변경
            playerRigid.velocity = Vector2.zero;
            // 리지드바디에 위쪽으로 힘 주기
            playerRigid.AddForce(new Vector2(0f, jumpForce));
            // 오디오 소스 재생
            playerAudio.Play();
        }
        else if(Input.GetMouseButtonUp(0) && playerRigid.velocity.y > 0)
        {
            // 마우스 왼쪽 버튼에서 손을 떼는 순간 && 속도의 y 값이 양수라면(위로 상승 중)
            // 현재 속도를 절반으로 변경
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        }
    }

    private void AnimPropertyUpdate()
    {
        playerAni.SetBool("Grounded", isGrounded); 
    }
    // 트리거 충돌 감지 처리를 위한 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Deadzone") && isDead == false)
        {
            Die();
        }
    }
    // 바닥에 닿았는지 체크하는 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.contacts[0].normal.y > PLAYER_STEP_ON_Y_POS_MIN)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }
    // 바닥에서 벗어났는지 체크하는 함수
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        jumpCount = 0;
    }
}
