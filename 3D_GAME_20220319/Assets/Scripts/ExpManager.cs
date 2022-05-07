using UnityEngine;
using UnityEngine.UI;
namespace Jones
{
    /// <summary>
    /// 經驗值管理器
    /// 紀錄玩家的經驗值、經驗值需求表、等級資料其他資料
    /// </summary>
    public class ExpManager : MonoBehaviour
    {
        [SerializeField, Header("玩家資料")]
        private DatePlayer datePlayer;
        [SerializeField, Header("經驗值需求表資料")]
        private DataExpTable dataExpTable;
        /// <summary>
        /// 玩家等級
        /// </summary>
        private Text textLv;
        /// <summary>
        /// 玩家血量文字
        /// </summary>
        private Text textHp;
        /// <summary>
        /// 主角
        /// </summary>
        private HurtSystem hurtSystemPlayer;
        

        /// <summary>
        /// 顯示資訊管理器
        /// </summary>
        private ShowInfoManager showInfoManager;

        private void Awake()
        {
            showInfoManager = GameObject.Find("顯示資訊管理器").GetComponent<ShowInfoManager>();
            textLv = GameObject.Find("玩家等級").GetComponent<Text>();
            textHp = GameObject.Find("玩家血量文字").GetComponent<Text>();
            UpdatePlayerUI();
            hurtSystemPlayer.UpdateDataHp(datePlayer.hp);

        }
        /// <summary>
        /// 取得經驗值
        /// </summary>
        /// <param name="getExp">獲得經驗值</param>
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
                hurtSystemPlayer.UpdateDataHp(datePlayer.hp);

            }
        }
        private void UpdatePlayerUI()
        {
            textLv.text = "Lv" + datePlayer.lv;
            textHp.text = datePlayer.hp + "/" + datePlayer.hp;
        }
    }

}
