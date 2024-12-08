using UnityEngine;
using UnityEngine.SceneManagement;

public class LightManager : MonoBehaviour
{
    [System.Serializable]
    public class SceneLightSettings
    {
        public string sceneName;           // Name of the scene
        public GameObject lightPrefab;     // Directional Light prefab for the scene
        public Material skyboxMaterial;    // Skybox material for the scene
    }

    public SceneLightSettings[] sceneSettings; // Array of settings for each scene
    private GameObject currentLight;           // Reference to the currently active light

    void Start()
    {
        // Subscribe to scene changes
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Apply settings for the currently active scene
        ApplySceneLight(SceneManager.GetActiveScene().name);
    }

    void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Apply settings when a new scene is loaded
        ApplySceneLight(scene.name);
    }

    private void ApplySceneLight(string sceneName)
    {
        // Find the matching settings for the current scene
        foreach (var settings in sceneSettings)
        {
            if (settings.sceneName == sceneName)
            {
                // Destroy the current light if it exists
                if (currentLight != null)
                {
                    Destroy(currentLight);
                }

                // Instantiate the light prefab for this scene
                if (settings.lightPrefab != null)
                {
                    currentLight = Instantiate(settings.lightPrefab);
                    Debug.Log($"Instantiated light prefab for scene: {sceneName}");
                }
                else
                {
                    Debug.LogWarning($"No light prefab assigned for scene: {sceneName}");
                }

                // Apply the skybox material for this scene
                if (settings.skyboxMaterial != null)
                {
                    RenderSettings.skybox = settings.skyboxMaterial;
                    DynamicGI.UpdateEnvironment(); // Update global illumination for the new skybox
                    Debug.Log($"Applied skybox for scene: {sceneName}");
                }
                else
                {
                    Debug.LogWarning($"No skybox material assigned for scene: {sceneName}");
                }

                return;
            }
        }
    }
}
