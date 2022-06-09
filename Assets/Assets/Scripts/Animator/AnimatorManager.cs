using UnityEngine;

namespace Idle
{
    public sealed class AnimatorManager : MonoBehaviour
    {
        //Component List
        [Header("Components")]
        public Animator screensAnimator;
        public Animator shopAnimator;

        //Flexible method to call any animator in one line
        public void PlayAnimation(Animator animator, string animationName)
        {
            //Call PlayAnimation(AnimatorManager.ANY ANIMATOR FROM COMPONETS, "Animation name");
            animator.Play(animationName);
        }
    }

}
