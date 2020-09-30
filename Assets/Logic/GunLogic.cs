using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour
{
    // The Bullet Prefab
    [SerializeField]
    GameObject Bullet;
    [SerializeField]
    Transform m_bulletSpawnTransform;
    float MAX_SHOT_CD=0.1f;
    float ShotCD=0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale>0.0f){
            if (Input.GetKey(KeyCode.Z)&&ShotCD<=0f){
                Instantiate(Bullet,m_bulletSpawnTransform.position,m_bulletSpawnTransform.rotation);  
                ShotCD=MAX_SHOT_CD;
            }
            ShotCD-=Time.deltaTime;
        }
    }


}


