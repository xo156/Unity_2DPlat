using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public Projectile projectilePrefab;
    public bool hasKey; 
    public bool hasProjectile;

    public float jumpForce=15.0f;
    public float moveSpeed=5.0f;
    public int health=5;

    public float xDirection;
    public bool isGrounded;

    [SerializeField] float movement;

    Rigidbody2D rigidbody2D;
    Animator animator;

    public void Damage(int damage){
        Debug.Log($"{damage}를 받았다.");
        health-=damage;
        if(health < 0){
            health = 0;
        }

        if(health == 0){
            GameManager.Instance.GamaOver();
        }

        animator.SetTrigger("Hurt");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start()가 호출");

        rigidbody2D=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        //플레이어 방향 처리
        xDirection = Input.GetAxis("Horizontal");
        if (Mathf.Abs(xDirection) > 0){
            if (xDirection<0){
                transform.localScale=new Vector3(-1,1,1);
            }
            else{
                    transform.localScale=new Vector3(1,1,1);
            }
        }

        movement =xDirection*moveSpeed;
        if (Mathf.Abs(movement) > 0.1f) {//절대값을 취해 좌로 이동할때도 속도 변수를 처리 가능하게 함
            animator.SetFloat("Speed", Mathf.Abs(movement));
        }
        else {//정지해있을때
            animator.SetFloat("Speed", 0);
        }

        //플레이어가 땅("Platforms")에 발을 딛고 있는지
        isGrounded = Physics2D.CircleCast(transform.position, 0.3f, Vector2.down, 1.1f, LayerMask.GetMask("Platforms"));
        animator.SetBool("Grounded",isGrounded);

        //스페이스바를 눌렀을 때
        //땅("Platforms")에 발을 딛고 있는지 게임 메니저가
        //러닝 상태일때
        if (GameManager.Instance.State == GameManager.GameState.Running && Input.GetKeyDown(KeyCode.Space) && isGrounded){
            Debug.Log("플레이어 캐릭터가 점프");

            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //Vector2(0,1)
        }

        if(hasProjectile && Input.GetButtonDown("Fire1")){
            Debug.Log("발사체를 발사합니다.");

            Vector3 playerDirection = new Vector3(transform.localScale.x, 0, 0);

            Projectile projectile = GameObject.Instantiate<Projectile>(projectilePrefab, transform.position + playerDirection, Quaternion.identity);

            projectile.Fire(playerDirection);

            hasProjectile = false;
        }
    }
    void OnDrawGizmos() {
        Gizmos.color=Color.red;
        Gizmos.DrawLine(transform.position, transform.position+Vector3.down*1.1f);
    }

    void FixedUpdate() {
        rigidbody2D.velocity = new Vector2(movement, rigidbody2D.velocity.y);

    }
}
