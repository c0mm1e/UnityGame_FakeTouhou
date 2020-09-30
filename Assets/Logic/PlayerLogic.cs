using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerLogic : MonoBehaviour
{
    AudioLogic m_audioLogic;
    const float MOVEMENT_SPEED = 1.2f;
    const int MAX_HEALTH = 1;
    CharacterController m_characterController;
    int m_health = MAX_HEALTH;
    // Start is called before the first frame update
    void Start()
    {
        m_audioLogic=FindObjectOfType<AudioLogic>();
        m_characterController=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale>0.0f){
            PlayerMove();
        }
    }

    void PlayerMove(){
        if (Input.GetKey(KeyCode.UpArrow)&&this.transform.localPosition.z<=113){
            this.transform.Translate(MOVEMENT_SPEED*Vector3.forward);
        }
        if (Input.GetKey(KeyCode.DownArrow)&&this.transform.localPosition.z>=-118){
            this.transform.Translate(MOVEMENT_SPEED*Vector3.back);
        }
        if (Input.GetKey(KeyCode.RightArrow)&&this.transform.localPosition.x<=270){
            this.transform.Translate(MOVEMENT_SPEED*Vector3.right);
        }
        if (Input.GetKey(KeyCode.LeftArrow)&&this.transform.localPosition.x>=-270){
            this.transform.Translate(MOVEMENT_SPEED*Vector3.left);
        }
    }

    public bool IsDead(){
        return m_health<=0;
    }

    public void Die(){
        m_health=0;
        m_audioLogic.playerdie();
        Destroy(gameObject);
        Debug.Log("Player is Dead");
    }
}