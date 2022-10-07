using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreTextMesh;
    [SerializeField] int score;

    [Header("Audio")]
    [SerializeField] AudioClip gameOverSFX;
    [SerializeField] AudioSource audioSource;


    [Header("Canvases")]
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas menuCanvas;
    [SerializeField] Canvas gameStartCanvas;
    public static GameManager Instance { get; private set; }

    public bool IsPlaying;
    private bool isGameOver;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    void Start()
    {
        scoreTextMesh.text = $"Score: {0}";
        IsPlaying = true;
    }
    void Update()
    {


    }

    public void IncreaseScore(int score)
    {
        Debug.Log(score);
        this.score += score;
        UpdateScoreText();
    }
    void UpdateScoreText()
    {
        scoreTextMesh.text = $"Score: {score}";
    }

    public void TriggerDeath()
    {
        isGameOver = true;
        IsPlaying = false;
        PlayGameOverSFX();

        gameOverCanvas.gameObject.SetActive(true);

    }

    private void PlayGameOverSFX()
    {
        audioSource.Stop();
        if (audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(gameOverSFX);
        }
    }
}
