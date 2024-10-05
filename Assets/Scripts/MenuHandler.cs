using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuHandler : MonoBehaviour
{
    public static MenuHandler instance;
    public TextMeshProUGUI bestScore;
    public TMP_InputField namePlayerInput;

    public string playerName;
    private int currentPoint;

    public string hightPlayerName;
    public int hightPlayerPoint;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void StartGame()
    {
        //saveHightScore("Z", 0);
        playerName = namePlayerInput.text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void Set_Point(int point)
    {
        currentPoint = point;
    }

    public int Get_Point()
    {
        return currentPoint;
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int point;
    }

    public void saveHightScore(string name, int point)
    {
        SaveData data = new SaveData();
        data.name = name;
        data.point = point;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void loadHightScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            hightPlayerName = data.name;
            hightPlayerPoint = data.point;

        }
    }

    public bool checkHightScore(int currentPoint)
    {
        if (currentPoint > hightPlayerPoint)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}