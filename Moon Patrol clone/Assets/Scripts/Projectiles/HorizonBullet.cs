﻿using UnityEngine;

public class HorizonBullet : MonoBehaviour {
    [SerializeField] private Rigidbody2D bulletRigidBody;
    [SerializeField] private ProjectileSpeedSO projectileSpeed;

    private void Start() {
        bulletRigidBody.velocity = new Vector2( projectileSpeed.projectileSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D obj) {
        Debug.Log($"Vertical Bullet hit: {obj.name}");
    }
    
    private void OnDestroy() {
        Debug.Log($"{gameObject.name} Destroyed");
    }
}