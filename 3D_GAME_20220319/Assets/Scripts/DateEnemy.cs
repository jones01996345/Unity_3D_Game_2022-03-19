using UnityEngine;

namespace Jones
{   /// <summary>
    /// 敵人資料
    /// 1.血量
    /// 2.攻擊
    /// 3.移動速度
    /// 4.追蹤範圍
    /// 5.攻擊範圍
    /// 6.經驗值
    /// 7.金幣物件
    /// 8.掉金幣數量
    /// 9.掉金幣機率
    /// </summary>
    //  CreateAssetMenu 建立資料選項
    //  menuName  選項名稱，可以使用 / 建立子選項(建議英文) 
    //  fileName  檔案名稱(建議英文)
    [CreateAssetMenu(menuName ="Jones/Date Enemy",fileName ="Date Enemy")]
    //  ScriptableObject 腳本化物件:將資料以物件方式儲存於 project 內
    public class DateEnemy : ScriptableObject
    {
        [Header("血量"), Range(0, 1000)]
        public float hp;
        [Header("攻擊"), Range(0, 500)]
        public float ack;
        [Header("攻擊冷卻"), Range(0, 5)]
        public float cd;
        [Header("延遲傳送傷害"), Range(0, 2)]
        public float delaySendDamage;
        [Header("移動速度"), Range(0, 50)]
        public float speed;
        [Header("追蹤範圍"), Range(5, 50)]
        public float rangeTrack;
        [Header("攻擊範圍"), Range(0, 10)]
        public float rangeAttack;
        [Header("攻擊區域位移")]
        public Vector3 v3AttackOffset;
        [Header("攻擊區域尺寸")]
        public Vector3 v3AttackSize=Vector3.one;
        [Header("經驗值"), Range(0, 1000)]
        public float exp;
        [Header("金幣物件")]
        public GameObject goCoin;
        [Header("金幣數量"), Range(0, 1000)]
        public int coinCount;
        [Header("金幣機率"), Range(0, 1)]
        public float coinProbability;
    }

}
