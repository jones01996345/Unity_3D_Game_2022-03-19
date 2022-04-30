using UnityEngine;
using UnityEngine.AI;
using System.Collections;   //引用 系統 集合(資料結構)-協同程序

namespace Jones
{
    /// <summary>
    /// 受傷並且附帶掉落道具系統
    /// 繼承自受傷系統
    /// </summary>
    public class HurtAndDropSystem : HurtSystem
    {
        [SerializeField, Header("敵人資料")]
        private DateEnemy date;
        [SerializeField, Header("畫布敵人血條")]
        private Transform traCanvasHp;
        //traCamera = GameObject.Find("攝影機").transform;
        /// <summary>
        /// 攝影機
        /// </summary>
        private Transform traCamera;
        private NavMeshAgent nav;
        private Enemy enemy;
        // override 復寫父類別有 virtual的資料
        protected override void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            enemy = GetComponent<Enemy>();
            //base.Awake();             //父類別原有的內容
            hp = date.hp;
            hpMax = date.hp;
            UpdateHealthUI();
            traCamera = GameObject.Find("攝影機").transform;

        }

        private void Update()
        {
            CanvasHpLookCamera();
        }
        /// <summary>
        /// 畫布血條 面向 攝影機
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
        /// 掉落金幣
        /// </summary>
        private IEnumerator DropCoin()
        {
            float random = Random.value;                // 取得隨機值0~1
            if (random<=date.coinProbability)           // 判斷 隨機值 是否小於等於 機率
            {
                for (int i = 0; i < date.coinCount; i++)   //迴圈重複生成道具
                {
                    Vector3 pos=new Vector3(Random.Range(-1,1),1,Random.Range(-1,1));
                    Instantiate(date.goCoin, transform.position + pos, Quaternion.Euler(90, Random.Range(0, 360), 0));
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
    }

    

}

