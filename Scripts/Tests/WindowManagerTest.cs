using UnityEngine;
using WRACore.UIExtension.Managers;

namespace WRACore.Tests
{
    public class WindowManagerTest : MonoBehaviour
    {
        [SerializeField] private string windowName;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                WindowManager.Instance.SwitchWindow(windowName);
            }
        }
    }
}
