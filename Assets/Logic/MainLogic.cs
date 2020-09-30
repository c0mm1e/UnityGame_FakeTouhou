using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class MainLogic : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI m_playerpause;
    [SerializeField]
    TextMeshProUGUI m_hint;
    [SerializeField]
    TextMeshProUGUI m_pause;   
    EnemyLogic m_enemyLogic;
    PlayerLogic m_playerLogic;

    void Start(){
        m_enemyLogic=FindObjectOfType<EnemyLogic>();
        m_playerLogic=FindObjectOfType<PlayerLogic>();
    }

    private void Update(){
 
        if (Input.GetKeyDown(KeyCode.Return)){
            StartGame();
        }
 
        if (Input.GetKeyDown(KeyCode.P)){
            PauseGame();
        }
 
        if (Input.GetKeyDown(KeyCode.R)){
            ReplayGame();
            Time.timeScale = 1.0f;
        }
 
        if (Input.GetKeyDown(KeyCode.Escape)){
            ExitGame();
        }
        if (m_playerLogic.IsDead()){
            m_pause.text="You lose!";
            m_hint.text="Press \"R\" to restart game\nPress \"Esc\" to quit game";
            Time.timeScale=0f;
        }
        if (m_enemyLogic.GetHealth()<=0){
            m_pause.text="You win!";
            m_hint.text="Press \"R\" to restart game\nPress \"Esc\" to quit game";
            Time.timeScale=0f;            
        }
    }
    public void StartGame(){
        Time.timeScale = 1.0f;
    }
 
    public void PauseGame(){
        Time.timeScale=1.0f-Time.timeScale;
        if (Time.timeScale==0.0f){
            m_playerpause.text="Press \"P\" to continue playing";
        }
        else{
            m_playerpause.text="";
        }
    }
 
    public void ReplayGame(){
        if (m_enemyLogic.GetHealth()<=0 || m_playerLogic.IsDead()){
            Application.LoadLevel(0);
        }
    }
 
    public void ExitGame(){
        Application.Quit();
    }
}