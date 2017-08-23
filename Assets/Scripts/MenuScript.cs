using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
	public void Blacksmith() { SceneManager.LoadScene("Blacksmith"); }
    public void Deepspace() { SceneManager.LoadScene("Deepspace"); }
    public void Menu() { SceneManager.LoadScene("Menu"); }
}
