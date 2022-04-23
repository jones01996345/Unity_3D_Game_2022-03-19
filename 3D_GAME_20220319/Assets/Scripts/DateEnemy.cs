using UnityEngine;

namespace Jones
{   /// <summary>
    /// �ĤH���
    /// 1.��q
    /// 2.����
    /// 3.���ʳt��
    /// 4.�l�ܽd��
    /// 5.�����d��
    /// 6.�g���
    /// 7.��������
    /// 8.�������ƶq
    /// 9.���������v
    /// </summary>
    //  CreateAssetMenu �إ߸�ƿﶵ
    //  menuName  �ﶵ�W�١A�i�H�ϥ� / �إߤl�ﶵ(��ĳ�^��) 
    //  fileName  �ɮצW��(��ĳ�^��)
    [CreateAssetMenu(menuName ="Jones/Date Enemy",fileName ="Date Enemy")]
    //  ScriptableObject �}���ƪ���:�N��ƥH����覡�x�s�� project ��
    public class DateEnemy : ScriptableObject
    {
        [Header("��q"), Range(0, 1000)]
        public float hp;
        [Header("����"), Range(0, 500)]
        public float ack;
        [Header("�����N�o"), Range(0, 5)]
        public float cd;
        [Header("����ǰe�ˮ`"), Range(0, 2)]
        public float delaySendDamage;
        [Header("���ʳt��"), Range(0, 50)]
        public float speed;
        [Header("�l�ܽd��"), Range(5, 50)]
        public float rangeTrack;
        [Header("�����d��"), Range(0, 10)]
        public float rangeAttack;
        [Header("�����ϰ�첾")]
        public Vector3 v3AttackOffset;
        [Header("�����ϰ�ؤo")]
        public Vector3 v3AttackSize=Vector3.one;
        [Header("�g���"), Range(0, 1000)]
        public float exp;
        [Header("��������")]
        public GameObject goCoin;
        [Header("�����ƶq"), Range(0, 1000)]
        public int coinCount;
        [Header("�������v"), Range(0, 1)]
        public float coinProbability;
    }

}
