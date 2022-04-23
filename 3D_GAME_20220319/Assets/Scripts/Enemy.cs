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

        private void Awake()
        {
            ani = GetComponent<Animator>();
            nav = GetComponent<NavMeshAgent>();

            traPlayer = GameObject.Find(namePlayer).transform;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 0, 1, 0.35f);
            Gizmos.DrawSphere(transform.position, date.rangeTrack);

            Gizmos.color = new Color(1, 0, 0, 0.35f);
            Gizmos.DrawSphere(transform.position, date.rangeAttack);
        }
        /// <summary>
        /// 檢查玩家是否在追蹤範圍內
        /// </summary>
        private void Update()
        {
            CheckPlayerInTrackRange();
        }

        private void CheckPlayerInTrackRange()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, date.rangeTrack, layerTrack);
            print(hits[0].name);
        }
    }

}
