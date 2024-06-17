using UnityEngine;

namespace FireBall.Core.Buttons
{
    public class ButtonExitAction : ActionBase
    {
        public override void Execute(object data = null)
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}