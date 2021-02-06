﻿#pragma warning disable 649

using Score;
using ScriptableObjects.Obstacles;
using UnityEngine;
using Vehicle;

namespace Obstacles {
    public class StoneController : MonoBehaviour {
        [SerializeField] private ObstaclesParamsSO rockParams;
        [SerializeField] private GameObject explosionEffect;

        private void Start() {
            GetComponent<SpriteRenderer>().sprite = rockParams.obstacleSprite;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            var vehicleController = other.GetComponentInParent<VehicleController>();
            var vehicleTire = other.GetComponent<VehicleTireController>();

            if (vehicleController != null || vehicleTire) vehicleController.PlayerDeath();
        }

        public void Destroy() {
            var scoreManager = GetComponent<ScoreManager>();
            scoreManager.AddOverallPlayerScore(rockParams.destroyScore);

            if (explosionEffect != null) {
                var explosionEffectGameObject = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(explosionEffectGameObject, 4f);
            }
            else {
                Debug.LogWarning($"{gameObject.name} missing explosion effect");
            }

            Destroy(gameObject);
        }
    }
}