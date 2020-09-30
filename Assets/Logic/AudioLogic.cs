using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLogic : MonoBehaviour
{
    AudioSource m_audioSource;
    [SerializeField]
    AudioClip m_playerdie;
    [SerializeField]
    AudioClip m_enemydie;    
    // Start is called before the first frame update
    void Start()
    {
        m_audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playerdie(){
        m_audioSource.PlayOneShot(m_playerdie);
    }
    public void enemydie(){
        m_audioSource.PlayOneShot(m_enemydie);
    }
}
