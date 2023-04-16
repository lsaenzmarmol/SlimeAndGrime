using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TankAIScript : MonoBehaviour
{
    public Transform player;
    public Transform firingPoint; // The transform from where the projectile will be fired
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
        Debug.Log("Shooting at Player");
        // Instantiate a new instance of the projectile prefab at the firing point's position
        GameObject projectile = Instantiate(projectilePrefab, firingPoint.position, Quaternion.identity);

        // Calculate the direction towards the player from the firing point's position
        Vector3 direction = player.position - firingPoint.position;

        // Set the initial position of the projectile
        projectile.transform.position = firingPoint.position;

        // Apply a forward force to the projectile using AddForce()
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.AddForce(direction.normalized * projectileSpeed, ForceMode.VelocityChange);
    }

    void TryCollide()
    {
        // Code to try to collide with player
        Debug.Log("Trying to collide with player!");
    }
}

