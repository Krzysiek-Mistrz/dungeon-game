using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            Destroy(player.gameObject);
            Destroy(floatingTextManager.gameObject);
            Destroy(hud);
            Destroy(menu);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += LoadState;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // references
    public Player player;
    public FloatingTextManager floatingTextManager;
    public Weapon weapon;
    public RectTransform hitpointBar;
    public Animator deathMenuAnim;
    public GameObject hud;
    public GameObject menu;

    // logic
    public int coins;
    public int experience;

    // floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 mention, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, mention, duration);
    }

    // upgrade weapon
    public bool TryUpgradeWeapon()
    {
        // is the weapon max level
        if (weaponPrices.Count <= weapon.weaponLevel)
            return false;

        if (coins >= weaponPrices[weapon.weaponLevel])
        {
            coins -= weaponPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }

        return false;
    }

    // hitpoint bar
    public void OnHitpointChange()
    {
        float ratio = (float)player.hitPoint / (float)player.maxHitPoint;
        hitpointBar.localScale = new Vector3(1, ratio, 1);
    }

    // experience system
    public int GetCurrentLevel()
    {
        int r = 0;
        int add = 0;
        while (experience >= add)
        {
            add += xpTable[r];
            r++;

            // if level == max
            if (r == xpTable.Count)
                return r;
        }

        return r;
    }

    public int GetXpToLevel(int level)
    {
        int r = 0;
        int xp = 0;

        while (r < level)
        {
            xp += xpTable[r];
            r++;
        }

        return xp;
    }

    public void GrantXp(int xp)
    {
        int currLevel = GetCurrentLevel();
        experience += xp;
        if (GetCurrentLevel() > currLevel)
            OnLevelUp();
    }

    public void OnLevelUp()
    {
        Debug.Log("Level Up!");
        player.OnLevelUp();
        OnHitpointChange();
    }

    // respawn function
    public void Respawn()
    {
        player.isAlive = true;
        player.lastImmune = Time.time;
        player.pushDirection = Vector3.zero;
        deathMenuAnim.SetTrigger("Hide");
        //player.Heal(player.maxHitPoint);
        player.hitPoint = player.maxHitPoint;
        OnHitpointChange();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void OnSceneLoaded(Scene s, LoadSceneMode mode)
    {
        player.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }

    /*SAVE
     *INT preferedSkin
     *INT coins
     *INT experience
     *INT weaponLevel
     */
    public void SaveState()
    {
        string save = "";

        // current state save
        save += "0" + "|";
        save += coins.ToString() + "|";
        save += experience.ToString() + "|";
        save += weapon.weaponLevel.ToString();
        save += "0";

        PlayerPrefs.SetString("SaveState", save);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= LoadState;

        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        // loading state
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        coins = int.Parse(data[1]);
        // xp
        experience = int.Parse(data[2]);
        if (GetCurrentLevel() != 1)
            player.SetLevel(GetCurrentLevel());
        // changing weapon level
        weapon.SetWeaponLevel(int.Parse(data[3]));

        // player.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }
}
