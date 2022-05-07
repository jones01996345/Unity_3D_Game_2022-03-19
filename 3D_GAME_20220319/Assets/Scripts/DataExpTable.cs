using UnityEngine;
namespace Jones
{
    /// <summary>
    /// 經驗值需求表資料
    /// 1~99經驗值需求
    /// 等級1:100
    /// 等級2:200
    /// 等級99:9900
    /// </summary>
    [CreateAssetMenu(menuName = "Jones/Data Exp Table",fileName = "Data Exp Table")]
    public class DataExpTable : ScriptableObject
    {
        [Header("等級1~99經驗值需求")]
        public int[] exps;

        [ContextMenu("Create Exp Data")]
        private void CreateExpData()
        {
            exps = new int[100];
            for (int i = 0; i < exps.Length; i++)
            {
                exps[i] = (i + 1) * 100;
            }
        }


    }

}
