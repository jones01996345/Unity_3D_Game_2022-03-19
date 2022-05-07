using UnityEngine;
using UnityEngine.UI;
namespace Jones
{
    public class HurtSystem : MonoBehaviour
    {
        [SerializeField, Header("血量"), Range(0, 5000)]
        protected float hp = 100;
        [Header("血條介面")]
        [SerializeField]
        private Text textHp;
        [SerializeField]
        private Image imageHp;
        [SerializeField, Header("死亡動畫參數")]
        protected string parameterDead = "開關死亡";

        protected Animator ani;

        protected float hpMax;

        // protected  保護修飾詞:與私人很相似，僅允許子類別存取保護級別資料
        // virtual  虛擬:允許子類別復寫
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
        /// 更新血條介面
        /// </summary>
        protected void UpdateHealthUI()
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
            if (hp <= 0) Dead();
        }
        /// <summary>
        /// 更新資料:血量與最大值
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

