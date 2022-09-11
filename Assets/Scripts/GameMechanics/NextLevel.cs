using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] UnityEvent finishLevelEvent;
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        finishLevelEvent.Invoke();
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
