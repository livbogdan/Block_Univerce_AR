using UnityEngine;
using UnityEngine.SceneManagement;

    public class Load_Scene : MonoBehaviour
    {
        public string scene;

        public void LoadScene()
        {
            if (!string.IsNullOrEmpty(this.scene))
            {
                int id;
                bool isNumeric = int.TryParse(this.scene, out id);

                if (isNumeric)
                    SceneManager.LoadScene(id);
                else
                    SceneManager.LoadScene(this.scene);
            }
        }

    public void Quit()
    {
        //UnityEngine.Debug.LogError("Exit Application");
        Application.Quit();
    }
}