using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Store : MonoBehaviour {

	public Gun[] guns;
    Button[] buttons;

    PauseMenu pauseMenu;
    GunController gunCon;

    void Start() {
        buttons = GetComponentsInChildren<Button>();
        SetText();
        gunCon = FindObjectOfType<GunController>();
        pauseMenu = FindObjectOfType<PauseMenu>();
        gameObject.SetActive(false);
    }

    void SetText() {
        if (guns.Length == buttons.Length) {
            for (int i=0;i<guns.Length;i++) {
                buttons[i].GetComponentsInChildren<Text>()[0].text = guns[i].weaponName;
                buttons[i].GetComponentsInChildren<Text>()[1].text = guns[i].description;
                buttons[i].GetComponentsInChildren<Text>()[2].text = guns[i].cost + "";
            }
        }
    }

    public void OnClick1() {
        BuyGun(guns[0]);
    }

    public void OnClick2() {
        BuyGun(guns[1]);
    }

    public void OnClick3() {
        BuyGun(guns[2]);
    }

    void BuyGun(Gun gun) {
        if(FindObjectOfType<Player>().GetPoints() >= gun.cost && gun.weaponName != gunCon.GetGun().weaponName) {
            gunCon.EquipGun(gun);
            FindObjectOfType<Player>().RemovePoints(gun.cost);
            pauseMenu.Clear();
        }
        else {
            gameObject.SetActive(false);
            pauseMenu.gameObject.SetActive(true);
        }
    }

}
