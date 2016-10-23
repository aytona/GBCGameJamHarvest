using UnityEngine;
using System.Collections.Generic;

public class InGameUI : MonoBehaviour {

    public GameObject m_GameUI;
    public GameObject m_PauseUI;
    public GameObject m_StoreUI;

    private List<GameObject> m_AllUI;

    private bool m_inStore = false;

    void Start() {
#if UNITY_EDITOR
        Cursor.visible = true;
#else
        Cursor.visible = false;
#endif
        m_AllUI.Add(m_GameUI);
        m_AllUI.Add(m_PauseUI);
        m_AllUI.Add(m_StoreUI);
    }

    void Update() {
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && !m_inStore) {
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
}
