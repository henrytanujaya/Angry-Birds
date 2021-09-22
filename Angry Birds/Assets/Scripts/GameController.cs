using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public SlingShooter SlingShooter;
    public List<Bird> Birds;
    public List<Enemy> Enemies;

    private bool _isGameEnded = false;
    public TrailController TrailController;
    private Bird _shotBird;
    public BoxCollider2D TapCollider;

    public string level;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Text _statusInfo;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Birds.Count; i++)
        {
            Birds[i].OnBirdDestroyed += ChangeBird;
            Birds[i].OnBirdShot += AssignTrail;
        }

        for(int i = 0; i < Enemies.Count; i++)
        {
            Enemies[i].OnEnemyDestroyed += CheckGameEnd;
        }

        TapCollider.enabled = false;
        SlingShooter.InitiateBird(Birds[0]);
        _shotBird = Birds[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBird()
    {
        TapCollider.enabled = false;
        if (_isGameEnded)
        {
            _statusInfo.text = "You Win!";
            _panel.gameObject.SetActive(true);
        }

        Birds.RemoveAt(0);

        if (Birds.Count == 0 && Enemies.Count > 0)
        {
            _statusInfo.text = "You Lose!";
            _panel.gameObject.SetActive(true);
        }

        if(Birds.Count > 0)
        {
            SlingShooter.InitiateBird(Birds[0]);
            _shotBird = Birds[0];
        }

        else
        {
            _isGameEnded = true;
        }
    }

    public void CheckGameEnd(GameObject destroyedEnemy)
    {
        for(int i = 0; i < Enemies.Count; i++)
        {
            if(Enemies[i].gameObject == destroyedEnemy)
            {
                Enemies.RemoveAt(i);
                break;
            }
        }

        if(Enemies.Count == 0)
        {
            _isGameEnded = true;
        }
    }

    public void AssignTrail(Bird bird)
    {
        TrailController.SetBird(bird);
        StartCoroutine(TrailController.SpawnTrail());
        TapCollider.enabled = true;
    }

    void OnMouseUp()
    {
        if(_shotBird != null)
        {
            _shotBird.OnTap();
        }
    }
}
