using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour
{
    [SerializeField] playerData data;

    [SerializeField] TextMeshProUGUI textPoints;
    [SerializeField] TextMeshProUGUI textKilled;

    [SerializeField] GameObject gameOverPanel;

    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _savePanel;

    private float _timer = 0;
    private bool isDead;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        isDead = false;
    }

    private void Update()
    {
        if (isDead)
        {
            _spawner.isActive = false;
            _audioSource.Stop();
            _savePanel.SetActive(false);

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }

            textPoints.text = data.pointCount.ToString();
            textKilled.text = data.killCount.ToString();

            _timer += Time.deltaTime;
            if (_timer > 10)
            {
                SceneManager.LoadScene(0);
            }
        }

    }

    public void playerDeath()
    {
        gameOverPanel.SetActive(true);
        isDead = true;
    }
}
