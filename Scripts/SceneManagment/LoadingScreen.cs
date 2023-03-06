using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SceneManagment
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Image progressBar;
        [SerializeField] private TextMeshProUGUI progressText;
        [SerializeField] private TextMeshProUGUI sceneIsReadText;
    

        private void Update()
        {
            if (progressBar != null)
            {
                progressBar.fillAmount = CustomSceneManager.Instance.PercentOfLoad;
            }

            if (progressText != null)
            {
                progressText.text = Mathf.Lerp(0, 100, CustomSceneManager.Instance.PercentOfLoad).ToString("P");
            }

            sceneIsReadText.gameObject.SetActive(CustomSceneManager.Instance.SceneIsReady);
            if (CustomSceneManager.Instance.SceneIsReady && Input.GetKeyDown(KeyCode.Space))
            {
                CustomSceneManager.Instance.SetActiveNextScene();
            }
        }

        public void SetActiveNextScene()
        {
            CustomSceneManager.Instance.SetActiveNextScene();
        }
    
    
    }
}
