using UnityEngine;
using UnityEngine.UI;
namespace Jones
{
    public class HurtSystem : MonoBehaviour
    {
        [SerializeField, Header("血量"), Range(0, 5000)]
        private float hp = 100;
        [Header("血條介面")]
        [SerializeField]
        private Text textHp;
        [SerializeField]
        private Image imageHp;

        private float hpMax;

        private void Awake()
        {
            hpMax = hp;
            UpdateHealthUI();
        }
        /// <summary>
        /// 更新血條介面
        /// </summary>
        private void UpdateHealthUI()
        {
            textHp.text = hp + "/" + hpMax;
            imageHp.fillAmount = hp / hpMax;
        }
        /// <summary>
        /// 受傷
        /// </summary>
        /// <param name="damage">受到傷害</param>
        public void GetHurt(float damage)
        {
            hp -= damage;
            UpdateHealthUI();
        }
    }
}

