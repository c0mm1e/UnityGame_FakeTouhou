using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletLogic : MonoBehaviour
{
    float EnemyBulletLifeTime = 6.0f;
    protected float EnemyBulletSpeed = 200.0f;
    // Start is called before the first frame update
    PlayerLogic m_playerLogic;
    void Start()
    {
        Rigidbody eb_rigidbody=GetComponent<Rigidbody>();
        m_playerLogic=FindObjectOfType<PlayerLogic>();
        if (eb_rigidbody){
            eb_rigidbody.velocity=-transform.forward*EnemyBulletSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnemyBulletLifeTime-=Time.deltaTime;
        if (EnemyBulletLifeTime<0f){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.tag.CompareTo("Player")==0){
            Destroy(this.gameObject);  
            m_playerLogic.Die();
        }
    }
}
