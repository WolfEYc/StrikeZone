using UnityEngine;
using UnityEngine.SceneManagement;

namespace Strikezone
{
    public class SceneMaster : Singleton<SceneMaster>
    {
        [SerializeField] Toggle loadingCanvas;
        AsyncOperation _swtichHandle;

        public void LoadScene(int scene)
        {
            loadingCanvas.Switch(true);
            _swtichHandle = SceneManager.LoadSceneAsync(scene);
            _swtichHandle.completed += SceneHandleOncompleted;
        }
    
        void SceneHandleOncompleted(AsyncOperation obj)
        {
            loadingCanvas.Switch(false);
        }
        
    }
}
