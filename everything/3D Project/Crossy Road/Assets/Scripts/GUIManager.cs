using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public bool gameOver = false;
    public RectTransform Panel;
    [SerializeField] private PlayerControl2 playerControlScript;
    [SerializeField] private CameraControl2 cameraControlScript;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text restartText;

    void Start()
    {
        gameOverPanel.SetActive(false);
        restartText.gameObject.SetActive(false);
        Panel.localScale = new Vector3(0, 0);
        playerControlScript = GameObject.Find("ParentPlayer").GetComponent<PlayerControl2>();
        cameraControlScript = GameObject.Find("Main Camera").GetComponent<CameraControl2>();
    }

    void Update()
    {
        DeathScreen();
    }

    public void DeathScreen()
    {
        if ((Input.GetKeyDown(KeyCode.G) && !gameOver))
        {
            print("Debug");
            Panel.localScale = new Vector3(0.5f, 1, 0.5f);
            gameOver = true;
            playerControlScript.gameOver = gameOver;
            StartCoroutine(GameOverSequence());
        }
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print("Quit");
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.H))
            Panel.localScale = new Vector3(0.5f, 1, 0.5f);
    }
    private IEnumerator GameOverSequence()
    {
        gameOverPanel.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        restartText.gameObject.SetActive(true);
    }
}
