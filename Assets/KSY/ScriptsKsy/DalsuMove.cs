using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DalsuMove : MonoBehaviour
{

    public enum CurrentState { idle, patrol, chase, attack, chaseStart };
    CurrentState curState;

    public float dsdmg = 1;

    Animator dsanim;

    public AudioClip dsStep;
    public AudioClip dsKey;
    public AudioClip dsWs;
    public AudioClip dsAt;

    CharacterController cc;
    Vector3 patrolCenter;
    Vector3 patrolNext;
    public GameObject hm;

    private List<AudioSource> dsAs = new List<AudioSource>();
    private Transform dsTransform;
    private Transform pTransform;
    private NavMeshAgent dsnvAgent;
    //private �÷��̾ũ��Ʈ�̸� playerSc;
    private float dist;
    private PlayerHealth playerHealth;

    //���� ���� �Ÿ�
    public float chaseDist = 20.0f;
    //���� ���� �Ÿ�
    public float attackDist = 3.0f;

    bool canAt = true;


    void Start()
    {
        AddAudioSource(dsStep);
        AddAudioSource(dsKey);
        AddAudioSource(dsWs);
        AddAudioSource(dsAt);

        patrolCenter = transform.position;
        patrolNext = patrolCenter;

        dsTransform = GetComponent<Transform>();
        cc = GetComponent<CharacterController>();
        dsnvAgent = GetComponent<NavMeshAgent>();
        dsanim = GetComponent<Animator>();
        playerHealth = hm.GetComponent<PlayerHealth>();
        curState = CurrentState.patrol;

        bool canAt = true;

    }



    void Update()
    {
        pTransform = hm.transform;
        StartCoroutine(CheckState());
        StartCoroutine(CheckStateForAction());
    }

    IEnumerator CheckState()
    {
        dist = Vector3.Distance(dsTransform.position, pTransform.position);
        yield return new WaitForSeconds(0.25f);
        if (dist <= attackDist)  //isHiding�� �ƴ϶��
        {
            curState = CurrentState.attack;
        }
        else if (dist <= chaseDist)  //isHiding�� �ƴ϶��
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (pTransform.position - transform.position).normalized, out hit, chaseDist))
                if (hit.transform == pTransform)
                {
                    if (curState == CurrentState.chase)
                    {
                        curState = CurrentState.chase;
                    }
                    else if (curState == CurrentState.chaseStart)
                    {
                        curState = CurrentState.chase;
                    }
                    else if (curState == CurrentState.patrol)
                    {
                        curState = CurrentState.chaseStart;
                    }
                }

        }
        else
        {
            curState = CurrentState.patrol;
        }
    }

    IEnumerator CheckStateForAction()
    {
        switch(curState)
        {
            case CurrentState.attack:
                StartCoroutine(Attack());
                break;
            case CurrentState.patrol:
                Patrol();
                break;
            case CurrentState.chaseStart:
                ChaseStart();
                break;
            case CurrentState.chase:
                Chase();
                break;
            
        }
        yield return null;
    }

    void Patrol()
    {
        Vector3 dir = pTransform.position - dsTransform.position;
        //dsanim.SetTrigger("Patrol");
        dsnvAgent.speed = 0.8f;
        //cc.Move(dir.normalized * dsnvAgent.speed * Time.deltaTime);
        patrolNext = patrolCenter + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        dsnvAgent.SetDestination(patrolNext);
    }

    void ChaseStart()
    {
        AudioSource.PlayClipAtPoint(dsWs, dsnvAgent.transform.position);
        Chase();
    }   
    
    void Chase()
    {
        Vector3 dir = pTransform.position - dsTransform.position;
        dsnvAgent.speed = 2.0f;
        //cc.Move(dir.normalized * dsnvAgent.speed * Time.deltaTime);
        dsnvAgent.SetDestination(pTransform.position);
        //dsanim.SetTrigger("Chase");
    }

    IEnumerator Attack()
    {
        // �÷��̾ ���� �ٶ󺸵��� ����
        cc.Move(Vector3.zero);
        //dsTransform.LookAt(pTransform.position);

        if (dist <= attackDist && canAt == true)
        {
            canAt = false;
            //dsanim.SetTrigger("Attack");
            playerHealth.TakeDamage((int)dsdmg);
            yield return new WaitForSeconds(2.1f); // ���� �ִϸ��̼� �ð���ŭ ���
            canAt = true;
            if (dist <= attackDist && canAt == true)
            {
                canAt = false;
                //dsanim.SetTrigger("At");
                playerHealth.TakeDamage((int)dsdmg);
                yield return new WaitForSeconds(2.1f); // ���� �ִϸ��̼� �ð���ŭ ���
                canAt = true;
                if (dist <= attackDist && canAt == true)
                {
                    canAt = false;
                    //dsanim.SetTrigger("At2");
                    playerHealth.TakeDamage((int)dsdmg);
                    yield return new WaitForSeconds(2.1f); // ���� �ִϸ��̼� �ð���ŭ ���
                    canAt = true;
                }
            }
        }
        else if (dist <= chaseDist)
        {
            curState = CurrentState.chase;

        }


    }

    void AddAudioSource(AudioClip clip)
    {
        AudioSource newSource = gameObject.AddComponent<AudioSource>();
        newSource.clip = clip;
        dsAs.Add(newSource);
    }

    void DSFootStep()
    {
        // dsAs[0].Play();
        AudioSource.PlayClipAtPoint(dsStep, dsnvAgent.transform.position);
        AudioSource.PlayClipAtPoint(dsKey, dsnvAgent.transform.position);
    }

    void DSAT()
    {
        AudioSource.PlayClipAtPoint(dsAt, dsnvAgent.transform.position);
    }

    //void LookAtP()
    //{
    //    // this.transform.LootAt(pTransform);
    //    Vector3 dsDir = dsnvAgent.desiredVelocity;
    //    dsDir.Set(dsDir.x, 0f, dsDir.z);
    //    Quaternion targetAngle = Quaternion.LookRotation(dsDir);
    //    dsnvAgent.transform.rotation = Quaternion.Slerp(dsnvAgent.transform.rotation, targetAngle, 120);
    //}

 
}
