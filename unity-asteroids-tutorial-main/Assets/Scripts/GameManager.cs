using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ParticleSystem explosionEffect;
    public ParticleSystem explosionEffect2;
    public ParticleSystem explosionEffect3;
    public ParticleSystem stars;


    public GameObject gameOverUI;

    public int score { get; private set; }
    public Text scoreText;

    public int lives { get; private set; }
    public Text livesText;

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        SkyboxRotate();

        if (lives <= 0 && Input.GetKeyDown(KeyCode.Return)) {
            NewGame();
        } 
    }

    public void NewGame()
    {
        Asteroid[] asteroids = FindObjectsOfType<Asteroid>();

        for (int i = 0; i < asteroids.Length; i++) {
            Destroy(asteroids[i].gameObject);
        }

        gameOverUI.SetActive(false);

        
        SetScore(0);
        SetLives(5);
        Respawn();
    }

    public void Respawn()
    {
        player.transform.position = Vector3.zero;
        player.gameObject.SetActive(true);
        
    }

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        explosionEffect.transform.position = asteroid.transform.position;
        explosionEffect.Play();
        explosionEffect2.transform.position = asteroid.transform.position;
        explosionEffect2.Play();

        if (asteroid.size < 0.7f) {
            SetScore(score + 100); // small asteroid
        } else if (asteroid.size < 1.4f) {
            SetScore(score + 50); // medium asteroid
        } else {
            SetScore(score + 25); // large asteroid
        }
    }

    public void PlayerDeath(Player player)
    {
        explosionEffect3.transform.position = player.transform.position;
        explosionEffect3.Play();
        
        SetLives(lives - 1);

        if (lives <= 0) {
            GameOver();
        } else {
            Invoke(nameof(Respawn), player.respawnDelay);
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString();
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        livesText.text = lives.ToString();
    }
    private void SkyboxRotate()
    {
        float offset = 1.0f;
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * offset);
    }


}
