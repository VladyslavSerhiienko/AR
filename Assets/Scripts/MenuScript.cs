using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Class that controls the transitions between scenes
public class MenuScript : MonoBehaviour {
    public void Blacksmith() { SceneManager.LoadScene("Blacksmith"); } // Open a "Blacksmith" scene 
    public void Deepspace() { SceneManager.LoadScene("Deepspace"); } // Open a "Deepspace" scene 
    public void Menu() { SceneManager.LoadScene("Menu"); } // Open a "Menu" scene 
}
