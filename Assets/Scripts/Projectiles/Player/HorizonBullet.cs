﻿#pragma warning disable 649

using Interfaces;
using ScriptableObjects.Projectile;
using UnityEngine;

namespace Projectiles.Player {
    public class HorizonBullet : MonoBehaviour {
        [SerializeField] private Rigidbody2D bulletRigidBody;
        [SerializeField] private ProjectileSpeedSO projectileSpeed;

        private void Start() {
            bulletRigidBody.velocity = new Vector2(projectileSpeed.projectileSpeed, 0);
        }

        private void OnDestroy() {
            Debug.Log($"{gameObject.name} Destroyed");
        }

        private void OnTriggerEnter2D(Collider2D obj) {
            var objetHit = obj.GetComponent<IDestroyable>();
            objetHit?.Destroyed();
            Destroy(gameObject);
            Debug.Log($"Vertical Bullet hit: {obj.name}");
        }
    }
}