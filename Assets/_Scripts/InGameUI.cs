using UnityEngine;
using System.Collections.Generic;

public class InGameUI : MonoBehaviour {

    public GameObject m_GameUI;
    public GameObject m_PauseUI;
    public GameObject m_StoreUI;
    public GameObject m_MenuUI;
    public GameObject m_InstructionsUI;
    public GameObject m_CreditsUI;

    private List<GameObject> m_AllUI = null;
    private SmoothMouseLook mouseLock;
    private ShipThrusters shipThrusters;
    private bool m_inStore = false;
    private GameObject m_PrevUI;

    void Start() {
        m_AllUI = new List<GameObject>();
        mouseLock = FindObjectOfType<SmoothMouseLook>();
        shipThrusters = FindObjectOfType<ShipThrusters>();
        shipThrusters.enabled = false;
        mouseLock.enabled = false;
        m_AllUI.Add(m_GameUI);
        m_AllUI.Add(m_PauseUI);
        m_AllUI.Add(m_StoreUI);
        m_AllUI.Add(m_MenuUI);
        m_AllUI.Add(m_InstructionsUI);
        m_AllUI.Add(m_CreditsUI);
        SwitchUI(m_MenuUI);
    }

    void Update() {
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && !m_inStore) {
            Time.timeScale = 0;
            mouseLock.enabled = false;
            Cursor.visible = true;
            SwitchUI(m_PauseUI);
        }
        if (m_inStore) {
            SwitchUI(m_StoreUI);
        }
    }

    public bool GetInStore() {
        return m_inStore;
    }

    public void SwitchUI(GameObject UI) {
        foreach(GameObject i in m_AllUI) {
            if (i != UI) {
                i.SetActive(false);
            } else {
                i.SetActive(true);
            }
        }
    }

    public void UnPause() {
        mouseLock.enabled = true;
#if UNITY_EDITOR
        Cursor.visible = true;
#else
        Cursor.visible = false;
#endif
        Time.timeScale = 1;
    }

    public void StartGame() {
#if UNITY_EDITOR
        Cursor.visible = true;
#else
        Cursor.visible = false;
#endif
        mouseLock.enabled = true;
        shipThrusters.enabled = true;
        SwitchUI(m_GameUI);
    }

    public void Return() {
        SwitchUI(m_PrevUI);
    }

    public void SetPrevUI(GameObject prev) {
        m_PrevUI = prev;
    }
}
