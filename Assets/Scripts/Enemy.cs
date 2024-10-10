using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {
    enum EnemyState {
        Patrol,//적 캐릭터가 순찰하는 상태
        Chase//적 캐릭터가 플레이어를 추적하는 상태
    }

    enum EnemyDirection {
        Left = -1, //좌로 
        Idle = 0, //정지
        Right = 1 //우로
    }

    public float chasingRange = 3.0f;
    public float changeMindTime = 3.0f;
    public float moveSpeed = 5.0f;
    public float xDirection;
    public bool isGrounded;

    [SerializeField] EnemyState state;
    [SerializeField] EnemyDirection direction;

    [SerializeField] float movement;
    [SerializeField] Vector3 edgeOffset;
    [SerializeField] Vector3 directionToPlayer;
    [SerializeField] float distanceToPlayer;

    Rigidbody2D rigidbody2D;
    Animator animator;
    GameObject player;

    [SerializeField] float elapsedTime;//경과 시간(마지막으로 방향 바꾸고 나서)

    void Start() {
        state = EnemyState.Patrol;
        direction = EnemyDirection.Idle;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    void Update() {
        movement = xDirection * moveSpeed;
        if (Mathf.Abs(movement) > 0.1) {
            animator.SetFloat("Speed", Mathf.Abs(movement));
        }
        else {
            animator.SetFloat("Speed", 0);
        }

        //플레이어 포지션에서 적 포지션을 빼면 방향이 나옴
        directionToPlayer = player.transform.position - transform.position;

        //플레이어 캐릭터와의 거리
        distanceToPlayer = directionToPlayer.magnitude;//현재 벡터의 길이

        //적의 앞 부분이 절벽인가
        isGrounded = Physics2D.CircleCast(transform.position + edgeOffset, 0.3f, Vector2.down, 1.1f, LayerMask.GetMask("Platforms"));
        if (!isGrounded) {
            direction = direction == EnemyDirection.Left ? direction = EnemyDirection.Right : direction = EnemyDirection.Left;
            xDirection = (float)direction;
            elapsedTime = 0;
        }

        if (xDirection != 0) {
            transform.localScale = new Vector3(xDirection, 1, 1);
        }

        if (state == EnemyState.Patrol) {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= changeMindTime) {
                direction = (EnemyDirection)Random.Range(-1, 2);
                //3초 경과후 적의 방향 변경, -1초과 2미만의 정수
                xDirection = (float)direction;
                elapsedTime = 0;
            }

            if (distanceToPlayer <= chasingRange) {
                state = EnemyState.Chase;
                direction = directionToPlayer.x < 0 ? EnemyDirection.Left : EnemyDirection.Right;
            }
        }
        else if (state == EnemyState.Chase) {
            direction = directionToPlayer.x < 0 ? EnemyDirection.Left : EnemyDirection.Right;
            xDirection = (float)direction;

            if (distanceToPlayer > chasingRange) {
                state = EnemyState.Patrol;
            }
        }
    }

    void LateUpdate() { //업데이트 이후
        edgeOffset = new Vector3(transform.localScale.x * 0.5f, 0, 0);
    }

    void FixedUpdate() {
        rigidbody2D.velocity = new Vector2(movement, rigidbody2D.velocity.y);
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + edgeOffset, transform.position + edgeOffset + Vector3.down * 1.1f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chasingRange); //원점은 적 캐릭터, 반지름은 추격 범위
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.collider.CompareTag("Player")){
            Debug.Log("플레이어가 적과 충돌");

            coll.collider.SendMessage("Damage",1);
        }
    }
}
