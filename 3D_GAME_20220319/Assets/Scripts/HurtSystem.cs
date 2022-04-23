using UnityEngine;
using UnityEngine.UI;
namespace Jones
{
    public class HurtSystem : MonoBehaviour
    {
        [SerializeField, Header("��q"), Range(0, 5000)]
        private float hp = 100;
        [Header("�������")]
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
        /// ��s�������
        /// </summary>
        private void UpdateHealthUI()
        {
            textHp.text = hp + "/" + hpMax;
            imageHp.fillAmount = hp / hpMax;
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="damage">����ˮ`</param>
        public void GetHurt(float damage)
        {
            hp -= damage;
            UpdateHealthUI();
        }
    }
}

