using UnityEngine;
using System.Collections;
using UnityEngine.UI;    //添加UI命名空间

public class SliderLogic : MonoBehaviour {
    EnemyLogic m_enemyLogic;
    public Slider HPStrip;    //添加血条Slider的引用
    public int HP;
    int MAX_HP=60;
    void Start () {
        m_enemyLogic=FindObjectOfType<EnemyLogic>();
        HPStrip.value = HPStrip.maxValue = MAX_HP;    //初始化血条
    }
    void Update(){
        HP=m_enemyLogic.GetHealth();
        HPStrip.value=HP;
    }
}
