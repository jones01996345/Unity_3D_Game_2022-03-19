using UnityEngine;
namespace Jones
{

    /// <summary>
    /// 玩家資訊
    /// 等級、經驗值、攻擊力
    /// </summary>
    [CreateAssetMenu(menuName ="Jones/DatePlayer",fileName ="Dateplayer")]
    public class DatePlayer : ScriptableObject
    {
        [Header("等級")]
        public int lv = 1;
        [Header("經驗值")]
        public int exp = 0;
        [Header("攻擊力")]
        public float attack = 20;
        [Header("血量")]
        public float hp = 1000;
        [Header("提升攻擊力")]
        public float lvUpAttack = 10;
        [Header("提升血量")]
        public float lvUpHp = 200;
        [ContextMenu("Rest To Original")]
        private void RestToOriginal()
        {
            lv = 1;
            exp = 0;
            attack = 20;
            hp = 1000;
        }

    }

}

