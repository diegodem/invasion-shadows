using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : CharacterStats
{

    public float lookRadius = 10f;
    public ParticleSystem rayAttack;
    public float attackDuration;
    public ParticleSystem deathExplosion;
    public ParticleSystem aura;
    private float attackTimer = 0;
    private bool dead = false;

    private CapsuleCollider collider;
    private AudioSource[] sounds;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
        collider = rayAttack.gameObject.GetComponent<CapsuleCollider>();
        health = maxHealth;
        sounds = GetComponentsInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead) {
            if (attackTimer > 0) {
                attackTimer -= Time.deltaTime;
            }else{
                float distance = Vector3.Distance(target.position, transform.position);
                collider.enabled = false;

                // If the player is close to the enemy, the enemy attacks
                if (distance <= agent.stoppingDistance) {
                    Attack();
                    FaceTarget();
                // If the player is at a medium distance, the enemy follows the player
                }else{
                    if (distance <= lookRadius) {
                        agent.SetDestination(target.position);
                    }else{
                        agent.ResetPath();
                    }
                }
            }
        }
        

        

        
    }

    void Attack() {
        rayAttack.Play();
        attackTimer = attackDuration;
        collider.enabled = true;
    }

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 120f);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public override void Die() {
        dead = true;
        sounds[1].Play();
        Invoke("Explode",0.2f);
    }

    void Explode() {
        deathExplosion.Play();
        
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        aura.Stop();
        Invoke("Erase",0.4f);
    }

    void Erase() {
        Destroy(gameObject);
    }

    public override void DamageSound(){
        sounds[0].Play();
    }
}
