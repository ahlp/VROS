using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private float maxAliveTime = 2.0f;

    private Rigidbody rigidBody;

    protected virtual void Awake() {
        rigidBody = GetComponent<Rigidbody>();
    }

    protected virtual void Start() {
        rigidBody.velocity = transform.forward * speed;
        Destroy(gameObject, maxAliveTime);
    }

    protected virtual void OnCollisionEnter(Collision other) {
        Destroy(this.gameObject);
    }


}
