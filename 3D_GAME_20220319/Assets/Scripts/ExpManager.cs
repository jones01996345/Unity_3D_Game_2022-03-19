using UnityEngine;
using UnityEngine.UI;
namespace Jones
{
    /// <summary>
    /// �g��Ⱥ޲z��
    /// �������a���g��ȡB�g��ȻݨD��B���Ÿ�ƨ�L���
    /// </summary>
    public class ExpManager : MonoBehaviour
    {
        [SerializeField, Header("���a���")]
        private DatePlayer datePlayer;
        [SerializeField, Header("�g��ȻݨD����")]
        private DataExpTable dataExpTable;
        /// <summary>
        /// ����
        /// </summary>
        private Text textLv;
        /// <summary>
        /// ��q��r
        /// </summary>
        private Text textHp;
        

        /// <summary>
        /// ��ܸ�T�޲z��
        /// </summary>
        private ShowInfoManager showInfoManager;

        private void Awake()
        {
            showInfoManager = GameObject.Find("��ܸ�T�޲z��").GetComponent<ShowInfoManager>();
            textLv = GameObject.Find("����").GetComponent<Text>();
            textHp = GameObject.Find("��q��r").GetComponent<Text>();
            UpdatePlayerUI();

        }
        /// <summary>
        /// ���o�g���
        /// </summary>
        /// <param name="getExp">��o�g���</param>
        public void GetExp(int getExp)
        {
            datePlayer.exp += getExp;
            showInfoManager.ShowUI("Exp",getExp);
            Levelup();

        }
        private void Levelup()
        {
            int expNeed = dataExpTable.exps[datePlayer.lv - 1];
            while (datePlayer.exp>=expNeed)
            {
                datePlayer.exp -=expNeed;
                datePlayer.lv++;
                expNeed = dataExpTable.exps[datePlayer.lv - 1];
                datePlayer.attack += datePlayer.lvUpAttack;
                datePlayer.hp += datePlayer.lvUpHp;
                UpdatePlayerUI();


            }
        }
        private void UpdatePlayerUI()
        {
            textLv.text = "Lv" + datePlayer.lv;
            textHp.text = datePlayer.hp + "/" + datePlayer.hp;
        }
    }

}
