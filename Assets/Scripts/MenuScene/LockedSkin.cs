using UnityEngine;
using UnityEngine.UI;

namespace MenuScene
{
    public class LockedSkin : MonoBehaviour
    {
        private const int TO_UNLOCK = 30;
        [SerializeField] private Sprite lockedSprite;
        [SerializeField] private Sprite unlockedSprite;
        [SerializeField] private GameObject unlockText;

        private void Start()
        {
            var image = gameObject.GetComponent<Image>();
            if (PlayerStatistic.Source().Scores < TO_UNLOCK)
            {
                gameObject.GetComponent<Toggle>().interactable = false;
                image.overrideSprite = lockedSprite;
            }
            else
            {
                gameObject.GetComponent<Toggle>().interactable = true;
                image.overrideSprite = unlockedSprite;
                Destroy(unlockText);
            }
        }
    }
}