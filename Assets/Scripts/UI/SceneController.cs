using UnityEngine.SceneManagement;

namespace Gedjua.Runner.Game.UI
{
    public class SceneController
    {
        public void NextScene()
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }

        public void PrevScene()
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        
        public void LoadScene(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex);
        }
    }
}

