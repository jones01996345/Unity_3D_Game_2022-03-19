using UnityEngine;
namespace Jones
{

    /// <summary>
    /// ���a��T
    /// ���šB�g��ȡB�����O
    /// </summary>
    [CreateAssetMenu(menuName ="Jones/DatePlayer",fileName ="Dateplayer")]
    public class DatePlayer : ScriptableObject
    {
        [Header("����")]
        public int lv = 1;
        [Header("�g���")]
        public int exp = 0;
        [Header("�����O")]
        public float attack = 20;
        [Header("��q")]
        public float hp = 1000;
        [Header("���ɧ����O")]
        public float lvUpAttack = 10;
        [Header("���ɦ�q")]
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

