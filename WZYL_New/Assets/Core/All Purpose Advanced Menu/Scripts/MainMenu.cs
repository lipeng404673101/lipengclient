using UnityEngine;
using System.Collections;

/**
 * Handles the ingame menu.
 * @author Daniel Zadroga <danielzadroga@hotmail.com>
 * Email me for any questions regarding theis Unity package.
 */

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioListener))]
[RequireComponent(typeof(GUILayer))]

public class MainMenu : MonoBehaviour
{
    public GUISkin menuSkin;
    public AudioClip buttonClickSfx;

    private delegate void MenuComponentMethod();
    private MenuComponentMethod currentMenuComponent;

    private static float volume;
    public float gameVolume = 10.0F;
    public float masterVolume = 10.0F;
    public float musicVolume = 10.0F;
    protected AudioSource m_audio;
    public bool showGUI = false;

    // Initialization.
    void Start()
    {
        this.currentMenuComponent = MainMenuComponent;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (showGUI == false)
            {
                showGUI = true;
                return;
            }

            if (showGUI == true)
            {
                showGUI = false;
                this.currentMenuComponent = MainMenuComponent;
                return;
            }
        }
    }

    public void MainMenuComponent()
    {
        GUI.skin = this.menuSkin;
        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 250, 200, 50), "Campaign"))
            {
                InitiateButtonClickSfx();
                this.currentMenuComponent = CampaignComponent;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 195, 200, 50), "Survival"))
            {
                InitiateButtonClickSfx();
                this.currentMenuComponent = SurvivalComponent;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 140, 200, 50), "Multiplayer"))
            {
                InitiateButtonClickSfx();
                // Multiplayer logic - load a scene to the multiplayer initialization.
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 85, 200, 50), "Settings"))
            {
                InitiateButtonClickSfx();
                this.currentMenuComponent = SettingsComponent;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 30, 200, 50), "Controls"))
            {
                InitiateButtonClickSfx();
                this.currentMenuComponent = ControlsComponent;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - -25, 200, 50), "Credits"))
            {
                InitiateButtonClickSfx();
                this.currentMenuComponent = CreditsComponent;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - -80, 200, 50), "Exit"))
            {
                InitiateButtonClickSfx();
                Application.Quit();
            }
        }
        GUI.EndGroup();
    }

    public void SettingsComponent()
    {
        GUI.skin = this.menuSkin;
        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
        {
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 300, 800, 600), "");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 300, 800, 25), "Settings Menu");

            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 275, 400, 25), "Volume Settings");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 250, 400, 25), "Master Volume");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 200, 400, 25), "Game Volume");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 150, 400, 25), "Music Volume");

            AudioListener.volume = masterVolume / 10;
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 225, 400, 25), "");
            masterVolume = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 220, 400, 25), masterVolume, 0.0f, 10.0f);
            AudioListener.volume = gameVolume / 10;
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 175, 400, 25), "");
            gameVolume = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 170, 400, 25), gameVolume, 0.0f, 10.0f);

            AudioListener.volume = musicVolume / 10;
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 125, 400, 25), "");
            musicVolume = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 120, 400, 25), musicVolume, 0.0f, 10.0f);

            /* Overall Graphical Settings */
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 275, 400, 25), "Overall Graphical Settings");

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 250, 400, 25), "Low"))
            {
                InitiateButtonClickSfx();
                QualitySettings.SetQualityLevel(0);
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 225, 400, 25), "Medium"))
            {
                InitiateButtonClickSfx();
                QualitySettings.SetQualityLevel(1);
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 200, 400, 25), "High"))
            {
                InitiateButtonClickSfx();
                QualitySettings.SetQualityLevel(2);
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 175, 400, 25), "Ultra"))
            {
                InitiateButtonClickSfx();
                QualitySettings.SetQualityLevel(3);
            }

            /* Antialiasing Filter Settings */
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 150, 400, 25), "Antialiasing Filter Settings");

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 125, 400, 25), "None"))
            {
                InitiateButtonClickSfx();
                QualitySettings.antiAliasing = 0;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 100, 400, 25), "X2"))
            {
                InitiateButtonClickSfx();
                QualitySettings.antiAliasing = 2;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 75, 400, 25), "X4"))
            {
                InitiateButtonClickSfx();
                QualitySettings.antiAliasing = 4;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 50, 400, 25), "X8"))
            {
                InitiateButtonClickSfx();
                QualitySettings.antiAliasing = 8;
            }

            /* Anisotropic Filter Settings */
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 25, 400, 25), "Anisotropic Filter Settings");

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 0, 400, 25), "Disabled"))
            {
                InitiateButtonClickSfx();
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -25, 400, 25), "Enabled"))
            {
                InitiateButtonClickSfx();
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -50, 400, 25), "Force Enabled"))
            {
                InitiateButtonClickSfx();
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
            }

            /* Texture Quality Settings */
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -75, 400, 25), "Texture Quality Settings");

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -100, 400, 25), "Low"))
            {
                InitiateButtonClickSfx();
                QualitySettings.masterTextureLimit = 2;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -125, 400, 25), "Medium"))
            {
                InitiateButtonClickSfx();
                QualitySettings.masterTextureLimit = 1;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -150, 400, 25), "High"))
            {
                InitiateButtonClickSfx();
                QualitySettings.masterTextureLimit = 0;
            }

            /* vSync Settings */
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -175, 400, 25), "vSync");

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -200, 400, 25), "Off"))
            {
                InitiateButtonClickSfx();
                QualitySettings.vSyncCount = 0;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -225, 400, 25), "On"))
            {
                InitiateButtonClickSfx();
                QualitySettings.vSyncCount = 1;
            }

            /* Shadow Settings */
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 100, 400, 25), "Overall Shadow Settings");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 75, 400, 25), "Shadow Drawing Distance");

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 50, 400, 25), "1"))
            {
                InitiateButtonClickSfx();
                QualitySettings.shadowDistance = 1;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 25, 400, 25), "50"))
            {
                InitiateButtonClickSfx();
                QualitySettings.shadowDistance = 50;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 0, 400, 25), "100"))
            {
                InitiateButtonClickSfx();
                QualitySettings.shadowDistance = 100;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -25, 400, 25), "200"))
            {
                InitiateButtonClickSfx();
                QualitySettings.shadowDistance = 200;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -50, 400, 25), "300"))
            {
                InitiateButtonClickSfx();
                QualitySettings.shadowDistance = 300;
            }

            /* Vegetation Settings */
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -75, 400, 25), "Vegetation Settings");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -100, 400, 25), "Soft Vegetation");

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -125, 400, 25), "Off"))
            {
                InitiateButtonClickSfx();
                QualitySettings.softVegetation = false;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -150, 400, 25), "On"))
            {
                InitiateButtonClickSfx();
                QualitySettings.softVegetation = true;
            }

            /* Machine information */
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -175, 400, 75),
                "Machine Information: \n GPU: " + SystemInfo.graphicsDeviceName +
                "\n GPU Memory: " + SystemInfo.graphicsMemorySize + "MB" +
                "\n CPU: " + SystemInfo.processorType +
                "\n RAM: " + SystemInfo.systemMemorySize + "MB");

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -250, 800, 50), "Back"))
            {
                InitiateButtonClickSfx();
                this.currentMenuComponent = MainMenuComponent;
            }
        }
        GUI.EndGroup();
    }

    public void ControlsComponent()
    {
        GUI.skin = this.menuSkin;
        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
        {
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 300, 800, 600), "");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 300, 800, 25), "Controls - FPS Preset");

            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 275, 400, 25), "-Movement-");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 250, 400, 25), "W");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 225, 400, 25), "S");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 200, 400, 25), "A");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 175, 400, 25), "D");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 150, 400, 25), "-Shoot/Aim down sights-");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 125, 400, 25), "RMB");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 100, 400, 25), "LMB");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 75, 400, 25), "-Crouch-");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 50, 400, 25), "C");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 25, 400, 25), "-Prone-");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 0, 400, 25), "Z");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -25, 400, 25), "-Sprint-");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -50, 400, 25), "Left Shift");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -75, 400, 25), "-Primary Weapon-");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -100, 400, 25), "1");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -125, 400, 25), "-Secondary Weapon-");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -150, 400, 25), "2");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -175, 400, 25), "-Equipment-");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -200, 400, 25), "3");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 275, 400, 25), "-Pickup Weapon-");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 250, 400, 25), "E");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 225, 400, 25), "-Reload Weapon-");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 200, 400, 25), "R");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 175, 400, 25), "-Use Equipment-");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 150, 400, 25), "G");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 125, 400, 25), "-Use Equipment-");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 100, 400, 25), "G");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 75, 400, 25), "-Use Melee Weapon-");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 50, 400, 25), "F");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 25, 400, 25), "-Use Chat-");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 0, 400, 25), "T");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -25, 400, 25), "-Leaderboards-");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -50, 400, 25), "Tab");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -75, 400, 25), "-Interact-");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -100, 400, 25), "Q");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -125, 400, 25), "-View Menu-");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -150, 400, 25), "Escape");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -175, 400, 25), "-Console-");
            GUI.Box(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -200, 400, 25), "Tilde");

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -225, 800, 75), "Back"))
            {
                InitiateButtonClickSfx();
                this.currentMenuComponent = MainMenuComponent;
            }
        }
        GUI.EndGroup();
    }

    public void CreditsComponent()
    {
        GUI.skin = this.menuSkin;
        GUI.BeginGroup(new Rect(0, 0, 2560, 1600));
        {
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 300, 800, 600), "");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 300, 800, 25), "Credits");

            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 275, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 250, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 225, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 200, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 175, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 150, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 125, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 100, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 75, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 50, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 25, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 0, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -25, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -50, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -75, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -100, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -125, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -150, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -175, 400, 25), "Credit goes to:");
            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -200, 400, 25), "Credit goes to:");

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 275, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 250, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 225, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 200, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 175, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 150, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 125, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 100, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 75, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 50, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 25, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - 0, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -25, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -50, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -75, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -100, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -125, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -150, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -175, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 - -200, 400, 25), "www.websitehere.com"))
            {
                InitiateButtonClickSfx();
                Application.OpenURL("http://www.unity3d.com/");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - -225, 800, 75), "Back"))
            {
                InitiateButtonClickSfx();
                this.currentMenuComponent = MainMenuComponent;
            }
        }
        GUI.EndGroup();
    }

    public void CampaignComponent()
    {
        GUI.skin = this.menuSkin;
        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
        {
            GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 300, 400, 600), "");

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 300, 400, 50), "Continue"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("Level 1");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 250, 400, 50), "New"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 50), "Load"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 150, 400, 50), "Campaign level 1"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 50), "Campaign level 2"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 400, 50), "Campaign level 3"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 0, 400, 50), "Campaign level 4"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - -50, 400, 50), "Campaign level 5"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - -100, 400, 50), "Campaign level 5"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - -150, 400, 50), "Campaign level 5"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - -200, 400, 50), "Campaign level 5"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - -250, 400, 50), "Back"))
            {
                InitiateButtonClickSfx();
                this.currentMenuComponent = MainMenuComponent;
            }
        }
        GUI.EndGroup();
    }

    public void SurvivalComponent()
    {
        GUI.skin = this.menuSkin;
        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
        {
            GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 300, 400, 600), "");

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 300, 400, 50), "Survival level 1"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 250, 400, 50), "Survival level 2"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 50), "Survival level 3"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 150, 400, 50), "Survival level 4"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 50), "Survival level 5"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 400, 50), "Survival level 6"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 0, 400, 50), "Survival level 7"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - -50, 400, 50), "Survival level 8"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - -100, 400, 50), "Survival level 9"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - -150, 400, 50), "Survival level 10"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - -200, 400, 50), "Survival level 11"))
            {
                InitiateButtonClickSfx();
                //Application.LoadLevel("levelnamehere");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - -250, 400, 50), "Back"))
            {
                InitiateButtonClickSfx();
                this.currentMenuComponent = MainMenuComponent;
            }
        }
        GUI.EndGroup();
    }

    private void InitiateButtonClickSfx()
    {
        m_audio = this.GetComponent<AudioSource>();
        m_audio.PlayOneShot(buttonClickSfx);
    }

    private void OnGUI()
    {
        if (showGUI == true)
        {
            this.currentMenuComponent();
        }
    }
}