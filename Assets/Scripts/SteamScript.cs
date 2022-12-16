using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
public class SteamScript : MonoBehaviour
{
    CGameID m_GameID;
    private void Start()
    {
        if (!SteamManager.Initialized) { return; }
        SteamUserStats.ResetAllStats(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (!SteamManager.Initialized){ return; }
        if (!Input.GetKeyDown(KeyCode.Space)){ return; }    
            SteamUserStats.SetAchievement("Test_Achievement");
            SteamUserStats.SetAchievement("test");
            SteamUserStats.StoreStats();
        if (!Input.GetKeyDown(KeyCode.P)){ return; }
            SteamUserStats.RequestCurrentStats();
    }
}
