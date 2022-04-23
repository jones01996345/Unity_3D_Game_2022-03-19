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
        private float timeAttack;
        private string parameterWalk = "��������";
        private string parameterAttack = "Ĳ�o����";
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
        /// �ˬd���a�O�_�b�l�ܽd��
        /// </summary>
        private void Update()
        {
            CheckPlayerInTrackRange();
        }
        /// <summary>
        /// �ˬd���a�O�_�b�l�ܽd��
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
                nav.isStopped = true;               // ���� �����N�z��
                ani.SetBool(parameterWalk, false);  // ����
            }
        }
        /// <summary>
        /// ���ʦܪ��a��m
        /// </summary>
        private void MoveToPlayer()
        {
            nav.isStopped = false;                  // ��_ �����N�z��
            nav.SetDestination(traPlayer.position);

            // print("�Z��:" + nav.remainingDistance);

            if (nav.remainingDistance < date.rangeAttack)     // �p�G �Ѿl�Z�� < �����d�� �N�i�����
            {
                if (timeAttack >= date.cd)
                {
                    //print("<color=red>����</color>");
                    timeAttack = 0;
                    ani.SetTrigger(parameterAttack);        // �N�o�����
                    CheckAttackArea();
                }
                else
                {
                    timeAttack += Time.deltaTime;
                    ani.SetBool(parameterWalk, false);      // �N�o���j�A������
                }
            }
            else
            {
                ani.SetBool(parameterWalk, true);           // �Ѿl���j > �����Z�� �i�樫���ʧ@
            }
        }
        private void CheckAttackArea()
        {
            transform.LookAt(traPlayer);
            Collider[] hits = Physics.OverlapBox(
                transform.position + transform.TransformDirection(date.v3AttackOffset), date.v3AttackSize / 2, Quaternion.identity, layerTrack);
            if (hits.Length>0)
            {
                //print("<color=yallow>�ĤH�����ؼ�:" + hits[0].name +"</color>");               
                hurtPlayer.GetHurt(date.ack);
            }
        }
    }
    
}
