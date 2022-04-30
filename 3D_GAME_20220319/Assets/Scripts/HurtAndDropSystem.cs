using UnityEngine;
using UnityEngine.AI;
using System.Collections;   //�ޥ� �t�� ���X(��Ƶ��c)-��P�{��

namespace Jones
{
    /// <summary>
    /// ���˨åB���a�����D��t��
    /// �~�Ӧۨ��˨t��
    /// </summary>
    public class HurtAndDropSystem : HurtSystem
    {
        [SerializeField, Header("�ĤH���")]
        private DateEnemy date;
        [SerializeField, Header("�e���ĤH���")]
        private Transform traCanvasHp;
        //traCamera = GameObject.Find("��v��").transform;
        /// <summary>
        /// ��v��
        /// </summary>
        private Transform traCamera;
        private NavMeshAgent nav;
        private Enemy enemy;
        // override �_�g�����O�� virtual�����
        protected override void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            enemy = GetComponent<Enemy>();
            //base.Awake();             //�����O�즳�����e
            hp = date.hp;
            hpMax = date.hp;
            UpdateHealthUI();
            traCamera = GameObject.Find("��v��").transform;

        }

        private void Update()
        {
            CanvasHpLookCamera();
        }
        /// <summary>
        /// �e����� ���V ��v��
        /// </summary>
        private void CanvasHpLookCamera()
        {
            traCanvasHp.eulerAngles = traCamera.eulerAngles;
        }

        protected override void Dead()
        {
            base.Dead();
            nav.enabled = false;
            enemy.enabled = false;
            StartCoroutine(DropCoin());
        }
        /// <summary>
        /// ��������
        /// </summary>
        private IEnumerator DropCoin()
        {
            float random = Random.value;                // ���o�H����0~1
            if (random<=date.coinProbability)           // �P�_ �H���� �O�_�p�󵥩� ���v
            {
                for (int i = 0; i < date.coinCount; i++)   //�j�魫�ƥͦ��D��
                {
                    Vector3 pos=new Vector3(Random.Range(-1,1),1,Random.Range(-1,1));
                    Instantiate(date.goCoin, transform.position + pos, Quaternion.Euler(90, Random.Range(0, 360), 0));
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
    }

    

}

