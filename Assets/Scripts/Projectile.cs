using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 5.0f;
    public float timeToBeDestroyed = 5.0f;

    Vector3 direction;
    Rigidbody2D rigidbody2D;

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.collider.CompareTag("Enemy")) {
            Debug.Log("발사체가 적과 충돌");

            GameObject.Destroy(coll.collider.gameObject);
            GameObject.Destroy(gameObject);
        }
        else if (coll.collider.CompareTag("Platform")) {
            Debug.Log("발사체가 플랫폼과 충돌했습니다.");

            GameObject.Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (GameManager.Instance.State == GameManager.GameState.Paused) {
            return; 
        }

        transform.Rotate(new Vector3(0, 0, rotateSpeed));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody2D.velocity = direction * moveSpeed;
    }

    public void Fire(Vector3 direction) {
        this.direction = direction;
        GameObject.Destroy(gameObject, timeToBeDestroyed);
    }
}
