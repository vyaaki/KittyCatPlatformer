using UnityEditor.Animations;
using UnityEngine;

namespace MenuScene
{
    public class CharacterChooser : MonoBehaviour
    {
        public void OnClickCharacter(AnimatorController animatorController)
        {
            PlayerCustomization.usedAnimatorController = animatorController;
        }
    }
}