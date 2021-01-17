using UnityEngine;
using UnityEngine.UI;

namespace DSC.UI.Helper
{
    [RequireComponent(typeof(Image))]
    public class DSC_UI_ImageAlphaHit : MonoBehaviour
    {
        #region Variable

        #region Variable - Inspector

        [Min(0)]
        [SerializeField] float m_fAlphaMinimumHit;

        #endregion

        Image m_hImage;

        #endregion

        #region Base - Mono

        void Awake()
        {
            m_hImage = GetComponent<Image>();
            m_hImage.alphaHitTestMinimumThreshold = m_fAlphaMinimumHit;
        }

        #endregion
    }
}