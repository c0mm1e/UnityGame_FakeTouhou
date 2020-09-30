using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletLogic : MonoBehaviour
{

    float PlayerBulletLifeTime = 5.0f;
    protected float PlayerBulletSpeed = 300.0f;
    // Start is called before the first frame update
    EnemyLogic m_enemyLogic;
    void Start()
    {
        Rigidbody pb_rigidbody=GetComponent<Rigidbody>();
        m_enemyLogic=FindObjectOfType<EnemyLogic>();
        if (pb_rigidbody){
            pb_rigidbody.velocity=transform.forward*PlayerBulletSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerBulletLifeTime-=Time.deltaTime;
        if (PlayerBulletLifeTime<0f){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.tag.CompareTo("Enemy")==0){
            Destroy(this.gameObject);  
            m_enemyLogic.DecreaseHealth();
        }
    }

}
