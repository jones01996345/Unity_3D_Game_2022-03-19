using UnityEngine;
using UnityEngine.AI;
namespace Jones
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField, Header("�Ǫ����")]
        private DateEnemy date;

        [SerializeField, Header("���a����W��")]
        private string namePlayer = "�D��";

        [SerializeField, Header("�l�ܽd��ϼh")]
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
        /// �ˬd���a�O�_�b�l�ܽd��
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
