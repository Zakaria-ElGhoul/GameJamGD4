using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loadingScreen;
    public ProgressBar progressBar;
    public TMP_Text textField;

    private void Awake()
    {
        instance = this;
        SceneManager.LoadSceneAsync((int)SceneIndexes.TITLE_SCREEN, LoadSceneMode.Additive);
    }

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    public void LoadGame()
    {
        loadingScreen.SetActive(true);

        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.TITLE_SCREEN));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.GAME, LoadSceneMode.Additive));
        StartCoroutine(GetSceneLoadProgress());
        StartCoroutine(GetTotalProgress());
    }

    float totalSceneProgress;
    float totalSpawnProgress;
    public IEnumerator GetSceneLoadProgress()
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                totalSceneProgress = 0;

                foreach (AsyncOperation operation in scenesLoading)
                {
                    totalSceneProgress += operation.progress;
                }

                totalSceneProgress = (totalSceneProgress / scenesLoading.Count) * 100f;

                textField.text = string.Format("Loading Enviroment: {0}%", totalSceneProgress);

                yield return null;
            }
        }
    }

    public IEnumerator GetTotalProgress()
    {
        float totalprogress = 0;

        while (RoomFirstDungeonGenerator.current == null || !RoomFirstDungeonGenerator.current.isDone)
        {
            if (RoomFirstDungeonGenerator.current == null)
            {
                totalSpawnProgress = 0;
            }
            else
            {
                totalSpawnProgress = Mathf.Round(RoomFirstDungeonGenerator.current.progress * 100f);

                textField.text = string.Format("Spawning Enemies: {0}%", totalSpawnProgress);
            }
            totalprogress = Mathf.Round((totalSceneProgress + totalSpawnProgress) / 2);

            progressBar.current = Mathf.RoundToInt(totalprogress);

            yield return null;
        }
        loadingScreen.SetActive(false);
    }   
}
