using UnityEngine;
namespace Jones
{
    /// <summary>
    /// �g��ȻݨD����
    /// 1~99�g��ȻݨD
    /// ����1:100
    /// ����2:200
    /// ����99:9900
    /// </summary>
    [CreateAssetMenu(menuName = "Jones/Data Exp Table",fileName = "Data Exp Table")]
    public class DataExpTable : ScriptableObject
    {
        [Header("����1~99�g��ȻݨD")]
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
