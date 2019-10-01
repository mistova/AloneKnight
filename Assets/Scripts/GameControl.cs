using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    private bool gPause = false;
    private bool isWall = false;
    private int isAttack;
    private bool isSpwn = false;
    private bool isAlive = true;   
    public GameObject enemy;    
    public float spawnTime = 5f;
    public Transform[] spawnPoints;
    void Start()
    {
        instance = GetComponent<GameControl>();
        //InvokeRepeating("Spawn", spawnTime, spawnTime);
        Spawn();
    }
    void Update()
    {
        if (isSpwn)
        {
            isSpwn = false;
            Spawn();
        }
    }
    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
    public void gamePause()
    {
        instance.gPause = true;
    }
    public void gameStart()
    {
        instance.gPause = false;
    }
    public bool isPause()
    {
        return instance.gPause;
    }
    public void isWallTrue()
    {
        instance.isWall = true;
    }
    public void isWallFalse()
    {
        instance.isWall = false;
    }
    public bool wall()
    {
        return instance.isWall;
    }
    public void Attack(int att)
    {
        instance.isAttack = att;
    }
    public int isAtt()
    {
        return instance.isAttack;
    }
    public bool IsAlive()
    {
        return instance.isAlive;
    }
    public void Alive()
    {
        instance.isAlive = true;
    }
    public void NotAlive()
    {
        instance.isAlive = false;
    }
    public bool IsSpwn()
    {
        return instance.isSpwn;
    }
    public void Spwn()
    {
        instance.isSpwn = true;
    }
}
