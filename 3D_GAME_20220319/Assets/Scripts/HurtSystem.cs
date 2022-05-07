using UnityEngine;
using UnityEngine.UI;
namespace Jones
{
    public class HurtSystem : MonoBehaviour
    {
        [SerializeField, Header("��q"), Range(0, 5000)]
        protected float hp = 100;
        [Header("�������")]
        [SerializeField]
        private Text textHp;
        [SerializeField]
        private Image imageHp;
        [SerializeField, Header("���`�ʵe�Ѽ�")]
        protected string parameterDead = "�}�����`";

        protected Animator ani;

        protected float hpMax;

        // protected  �O�@�׹���:�P�p�H�ܬۦ��A�Ȥ��\�l���O�s���O�@�ŧO���
        // virtual  ����:���\�l���O�_�g
        protected virtual void Awake()
        {
            hpMax = hp;
            //UpdateHealthUI();
        }

        private void Start()
        {
            ani=GetComponent<Animator>();
        }
        /// <summary>
        /// ��s�������
        /// </summary>
        protected void UpdateHealthUI()
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
            if (hp <= 0) Dead();
        }
        /// <summary>
        /// ��s���:��q�P�̤j��
        /// </summary>
        /// <param name="currentHp"></param>
        public void UpdateDataHp(float currentHp)
        {
            hp = currentHp;
            hpMax = currentHp;

        }

        protected virtual void Dead()
        {
            hp = 0;
            ani.SetBool(parameterDead, true);
        }

    }
}

