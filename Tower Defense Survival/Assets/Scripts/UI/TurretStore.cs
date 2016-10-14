using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurretStore : MonoBehaviour {

    public Gun[] guns;
    Button[] buttons;

    PauseMenu pauseMenu;

    void Start() {
        buttons = GetComponentsInChildren<Button>();
        SetText();
        pauseMenu = FindObjectOfType<PauseMenu>();
        gameObject.SetActive(false);
    }

    void SetText() {
        if (guns.Length == buttons.Length) {
            for (int i = 0; i < guns.Length; i++) {
                buttons[i].GetComponentsInChildren<Text>()[0].text = guns[i].weaponName;
                buttons[i].GetComponentsInChildren<Text>()[1].text = guns[i].description;
                buttons[i].GetComponentsInChildren<Text>()[2].text = guns[i].cost + "";
            }
        }
    }

    public void OnClick1() {

    }

    public void OnClick2() {

    }

    public void OnClick3() {

    }

}
