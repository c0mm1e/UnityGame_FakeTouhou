using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyLogic : MonoBehaviour
{ 
    [SerializeField]
    TextMeshProUGUI m_textMeshPro;
    AudioLogic m_audioLogic;
    [SerializeField]
    GameObject Bullet;
    [SerializeField]
    Transform m_bulletSpawnTransform;
    int EnemyHealth;
    float MAX_SHOT_CD=6f;
    float ShotCD=3f;
    int ShootType=0;
    float Enemy_Speed=10f;
    Vector3 Direction1=0.75f*Vector3.right;
    // Start is called before the first frame update
    void Start()
    {
        m_audioLogic=FindObjectOfType<AudioLogic>();
        EnemyHealth=60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale>0.0f){
            Debug.Log(EnemyHealth);
            if (EnemyHealth<=0){
                m_audioLogic.enemydie();
                Destroy(gameObject);
                Debug.Log("Enemy is Dead");
            }
            Fire();
            Move();
        }
        m_textMeshPro.text="Health: "+EnemyHealth;
    }

    public void DecreaseHealth(){
        this.EnemyHealth--;
    }

    void Fire(){
        if (ShotCD<=0f){
            Shoot(ShootType);
            ShootType++;
            ShotCD=MAX_SHOT_CD;
        }
        ShotCD-=Time.deltaTime;
    }

    void Shoot(int ShootType){
        if (ShootType%3==0){
            StartCoroutine("ShootType1");
        }
        else if (ShootType%3==1){
            StartCoroutine("ShootType2");
        }
        else if (ShootType%3==2){
            StartCoroutine("ShootType3");
        }
    }
    IEnumerator ShootType1(){
        for (int i=0;i<9;i++){
            for (int j=0;j<36;j++){
                Instantiate(Bullet,m_bulletSpawnTransform.position,Quaternion.Euler(new Vector3(0,10*j+4*i,0)));
            }
            yield return new WaitForSeconds(0.4f);
        }
        yield return null;
    }

    IEnumerator ShootType2(){
        for (int i=0;i<4;i++){
            for (int j=0;j<25;j++){
                Instantiate(Bullet,m_bulletSpawnTransform.position,Quaternion.Euler(new Vector3(0,7.2f*j-90,0)));
                yield return new WaitForSeconds(0.04f);
            }
        }   
        yield return null; 
    }

    IEnumerator ShootType3(){
        for (int i=0;i<3;i++){
            for (int j=0;j<32;j++){
                if (j<=7){
                    Instantiate(Bullet,m_bulletSpawnTransform.position,Quaternion.Euler(new Vector3(0,6*j,0)));
                }
                else if (j>7 && j<=23){
                    Instantiate(Bullet,m_bulletSpawnTransform.position,Quaternion.Euler(new Vector3(0,96-6*j,0)));
                }
                else if (j>23){
                    Instantiate(Bullet,m_bulletSpawnTransform.position,Quaternion.Euler(new Vector3(0,6*j-192,0)));
                }
                yield return new WaitForSeconds(0.05f);
            }   
        }
        yield return null;
    }

    void Move(){
        this.transform.Translate(Direction1);
        if (this.transform.position.x>100 || this.transform.position.x<-100){
            Direction1=-Direction1;
        }
    }

    public int GetHealth(){
        return EnemyHealth;
    }

}
