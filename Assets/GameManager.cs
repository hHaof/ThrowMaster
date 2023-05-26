using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject menuPanel;
    public GameObject inGamePanel;
    public GameObject failPanel;
    public GameObject winPanel;
    [SerializeField] private GameObject audioController;
    [SerializeField] private GameObject confetti;
    bool PlayOnce = false;
    bool isWin = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene("Level 1");
        }

    }

    public void WrapWin()
    {
        StartCoroutine(ShowWinPanel());
    }
  
    public IEnumerator ShowWinPanel()
    {
       
        if (!PlayOnce)
        {
            audioController.GetComponent<AudioController>().PlayCongratesSound();
            PlayOnce = true;
        }

        confetti.SetActive(true);
        yield return new WaitForSeconds(2f);
        inGamePanel.SetActive(false);
        failPanel.SetActive(false);
        winPanel.SetActive(true);
        isWin = true;
    }


    public void WrapFail()
    {
        StartCoroutine(ShowFailPanel());
    }
    public IEnumerator ShowFailPanel()
    {
        yield return new WaitForSeconds(8.1f);
        if (!isWin){
            if (!PlayOnce)
            {
                audioController.GetComponent<AudioController>().PlayFailSound();
                PlayOnce = true;
            }
            yield return new WaitForSeconds(1f);
            inGamePanel.SetActive(false);
            failPanel.SetActive(true);

        }

    }

}
