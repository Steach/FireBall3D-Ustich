using UnityEngine.SceneManagement;

namespace FireBall.Core.Buttons
{
    public class ButtonRestartAction : ActionBase
    {
        public override void Execute(object data = null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}