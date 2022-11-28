using UnityEngine;
using UnityEngine.SceneManagement;

namespace Obvious.Soap.Example
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private KeyCode _reloadSceneKey = KeyCode.R;

        [SerializeField] private bool _setGameViewOnStart = false;
        
        private void Start()
        {
            #if UNITY_EDITOR
            if (_setGameViewOnStart)
                SoapEditorUtils.SetGameViewScaleAndSize();
            #endif    
        }

        void Update()
        {
            if (Input.GetKeyDown(_reloadSceneKey))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}