using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TankAIScript : MonoBehaviour
{
    public Transform player;
    public float shootingRange = 20f;
    public float shootingInterval = 5f;
    public float collisionRange = 5f;
    public GameObject projectilePrefab; // The prefab of the projectile to fire
    public float projectileSpeed = 20f; // The speed at which the projectile will be fired

    private NavMeshAgent agent;
    private float nextShootTime = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= shootingRange && Time.time >= nextShootTime)
        {
            // Shoot at player
            Shoot();
            nextShootTime = Time.time + shootingInterval;
        }
        else if (distanceToPlayer <= collisionRange)
        {
            // Try to collide with player
            TryCollide();
        }
        else
        {
            // Move towards the player using NavMeshAgent
            agent.SetDestination(player.position);
        }
    }

    void Shoot()
    {
        // Instantiate a new instance of the projectile prefab
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Calculate the direction towards the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Set the velocity of the projectile towards the player
        projectile.GetComponent<Rigidbody>().velocity = direction * projectileSpeed;
    }

    void TryCollide()
    {
        // Code to try to collide with player
        Debug.Log("Trying to collide with player!");
    }
}

