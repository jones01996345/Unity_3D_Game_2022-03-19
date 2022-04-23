using UnityEngine;
using UnityEngine.AI;
namespace Jones
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField, Header("怪物資料")]
        private DateEnemy date;

        [SerializeField, Header("玩家物件名稱")]
        private string namePlayer = "主角";

        [SerializeField, Header("追蹤範圍圖層")]
        private LayerMask layerTrack;

        private Animator ani;
        private NavMeshAgent nav;
        private Transform traPlayer;
        private float timeAttack;
        private string parameterWalk = "關閉走路";
        private string parameterAttack = "觸發攻擊";
        private HurtSystem hurtPlayer;

        private void Awake()
        {
            ani = GetComponent<Animator>();
            nav = GetComponent<NavMeshAgent>();

            traPlayer = GameObject.Find(namePlayer).transform;
            hurtPlayer = traPlayer.GetComponent<HurtSystem>();

            nav.speed = date.speed;
            nav.stoppingDistance = date.rangeAttack;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 0, 1, 0.35f);
            Gizmos.DrawSphere(transform.position, date.rangeTrack);

            Gizmos.color = new Color(1, 0, 0, 0.35f);
            Gizmos.DrawSphere(transform.position, date.rangeAttack);

            Gizmos.color = new Color(1, 0.8f, 0, 0.6f);

            Gizmos.matrix = Matrix4x4.TRS(
                transform.position + transform.TransformDirection(date.v3AttackOffset),
                transform.rotation, transform.localScale);
            Gizmos.DrawCube(Vector3.zero, date.v3AttackSize);

        }
        /// <summary>
        /// 檢查玩家是否在追蹤範圍內
        /// </summary>
        private void Update()
        {
            CheckPlayerInTrackRange();
        }
        /// <summary>
        /// 檢查玩家是否在追蹤範圍內
        /// </summary>
        private void CheckPlayerInTrackRange()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, date.rangeTrack, layerTrack);

            if (hits.Length > 0)
            {
                // print(hits[0].name);
                MoveToPlayer();
            }
            else
            {
                nav.isStopped = true;               // 停止 導覽代理器
                ani.SetBool(parameterWalk, false);  // 等待
            }
        }
        /// <summary>
        /// 移動至玩家位置
        /// </summary>
        private void MoveToPlayer()
        {
            nav.isStopped = false;                  // 恢復 導覽代理器
            nav.SetDestination(traPlayer.position);

            // print("距離:" + nav.remainingDistance);

            if (nav.remainingDistance < date.rangeAttack)     // 如果 剩餘距離 < 攻擊範圍 就進行攻擊
            {
                if (timeAttack >= date.cd)
                {
                    //print("<color=red>攻擊</color>");
                    timeAttack = 0;
                    ani.SetTrigger(parameterAttack);        // 冷卻後攻擊
                    CheckAttackArea();
                }
                else
                {
                    timeAttack += Time.deltaTime;
                    ani.SetBool(parameterWalk, false);      // 冷卻間隔，不走路
                }
            }
            else
            {
                ani.SetBool(parameterWalk, true);           // 剩餘間隔 > 攻擊距離 進行走路動作
            }
        }
        private void CheckAttackArea()
        {
            transform.LookAt(traPlayer);
            Collider[] hits = Physics.OverlapBox(
                transform.position + transform.TransformDirection(date.v3AttackOffset), date.v3AttackSize / 2, Quaternion.identity, layerTrack);
            if (hits.Length>0)
            {
                //print("<color=yallow>敵人擊中目標:" + hits[0].name +"</color>");               
                hurtPlayer.GetHurt(date.ack);
            }
        }
    }
    
}
