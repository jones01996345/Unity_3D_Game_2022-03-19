using UnityEngine;
using Invector.vCharacterController;

/// <summary>
/// �R�W�Ŷ�
/// </summary>
namespace Jones
{
    /// <summary>
    /// �����t��
    /// 1.�Z������
    /// 2.�����ʵe
    /// 3.�M���S��
    /// 4.�����P�w
    /// </summary>
    public class Attack : MonoBehaviour
    {
        #region ���      
        private Animator ani;

        // SerializeField �ǦC�����:�N�p�H�������ݩʭ��O
        [SerializeField, Header("�Z�� �I��")]
        private GameObject goWeaponBack;
        [SerializeField, Header("�Z�� ��W")]
        private GameObject goWeaponHand;
        [SerializeField, Header("�M��")]
        private ParticleSystem psLight;
        [SerializeField, Header("�Ĥ@���q���M�ɶ�")]
        private float timeSwordToBack = 2.5f;
        [SerializeField, Header("�ĤG���q���M�ɶ�")]
        private float timeSwordToHide = 3.5f;
        [SerializeField, Header("�����ɶ�"), Range(0.1f, 1.5f)]
        private float timeCD = 1.1f;
        [SerializeField, Header("�����ϸ��")]
        private Vector3 v3AttackSize = Vector3.one;
        [SerializeField]
        private Vector3 v3AttackOffset;
        [SerializeField]
        private LayerMask layerAttack;
        [SerializeField, Header("���a���")]
        private DatePlayer date;

        private string paramateterAttack = "Ĳ�o����";
        private bool isAttack;
        private bool isBack;
        private bool CanAttack = true;
        private float timer;
        private float timerToHide;
        private float timerAttack;
        private vThirdPersonController controller;

        #endregion
        #region �ƥ�
        private void OnDrawGizmos()
        {

            Gizmos.color = new Color(1, 0, 0, 0.3f);
            // matrix �]�w�ϥܮy�СB���׻P�ؤo
            // TRS�y�СB���׻P�ؤo
            // transform.TransformDirection(�y��)�ഫ�ϰ�y�лP�@�ɮy��
            Gizmos.matrix = Matrix4x4.TRS(
                transform.position + transform.TransformDirection(v3AttackOffset),
                transform.rotation, transform.localScale);
            Gizmos.DrawCube(Vector3.zero, v3AttackSize);
        }

        private void Awake()
        {
            ani = GetComponent<Animator>();
            controller = GetComponent<vThirdPersonController>();

        }

        private void Update()
        {
            SwitchWeapon();
            SwordToBack();
            SwordToHide();
            AttackCD();
        }
        #endregion

        #region ��k
        /// <summary>
        /// �����Z��
        /// </summary>
        private void SwitchWeapon()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && CanAttack)
            {
                controller.lockMovement = true;                 //��w����
                controller._rigidbody.velocity = Vector3.zero;

                goWeaponBack.SetActive(false);
                goWeaponHand.SetActive(true);

                ani.SetTrigger(paramateterAttack);      //Ĳ�o�����ʵe
                psLight.Play();                         //��������S��
                CheckAttackArea();

                timer = 0;                              //�C�������p�ɭ���
                isAttack = true;
                CanAttack = false;
                timerToHide = 0;
                isBack = false;
            }

        }
        /// <summary>
        /// �Ĥ@���q:�M�l�q��W���^�I��
        /// </summary>
        private void SwordToBack()
        {
            if (isAttack)
            {
                timer += Time.deltaTime;
                if (timer >= timeSwordToBack)
                {
                    goWeaponHand.SetActive(false);
                    goWeaponBack.SetActive(true);

                    timer = 0;                      //���M��p�ɾ��k�s
                    isAttack = false;
                    isBack = true;
                }
            }
        }

        /// <summary>
        /// ���M�ĤG���q:�q�I������
        /// </summary>
        private void SwordToHide()
        {
            if (isBack)
            {
                timerToHide += Time.deltaTime;
                if (timerToHide >= timeSwordToHide)
                {
                    goWeaponBack.SetActive(false);
                    timerToHide = 0;
                }
            }
        }

        /// <summary>
        /// �����N�o
        /// </summary>
        private void AttackCD()
        {
            if (!CanAttack)
            {
                timerAttack += Time.deltaTime;
                if (timerAttack >= timeCD)
                {
                    timerAttack = 0;
                    CanAttack = true;
                    controller.lockMovement = false;
                }
            }
        }
        /// <summary>
        /// �ˬd�����ϰ�
        /// </summary>
        private void CheckAttackArea()
        {

            Collider[] hits = Physics.OverlapBox(
                transform.position + transform.TransformDirection(v3AttackOffset),
                v3AttackSize / 2, Quaternion.identity, layerAttack);
            if (hits.Length > 0)
            {
                //print("<color=yallow>�ĤH�����ؼ�:" + hits[0].name +"</color>");               
                hits[0].GetComponent<HurtAndDropSystem>().GetHurt(date.attack);
            }
        }
        #endregion
    }
}
         

