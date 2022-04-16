using UnityEngine;

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
        [SerializeField,Header("�Z�� �I��")]
        private GameObject goWeaponBack;
        [SerializeField, Header("�Z�� ��W")]
        private GameObject goWeaponHand;
        [SerializeField, Header("�M��")]
        private ParticleSystem psLight;
        [SerializeField,Header("�Ĥ@���q���M�ɶ�")]
        private float timeSwordToBack=2.5f;
        [SerializeField, Header("�ĤG���q���M�ɶ�")]
        private float timeSwordToHide = 3.5f;

        private string paramateterAttack = "Ĳ�o����";
        private bool isAttack;
        private bool isBack;
        private float timer;
        private float timerToHide;
        #endregion
        #region �ƥ�
        private void Awake()
        {
            ani = GetComponent<Animator>();
        }
        private void Update()
        {
            SwitchWeapon();
            SwordToBack();
            SwordToHide();
        }
        #endregion

        #region ��k
        /// <summary>
        /// �����Z��
        /// </summary>
        private void SwitchWeapon()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                goWeaponBack.SetActive(false);
                goWeaponHand.SetActive(true);

                ani.SetTrigger(paramateterAttack);      //Ĳ�o�����ʵe
                psLight.Play();                         //��������S��

                timer = 0;                              //�C�������p�ɭ���
                isAttack = true;
            }

        }
        /// <summary>
        /// �Ĥ@���q:�M�l�q��W���^�I��
        /// </summary>
        private void SwordToBack()
        {
            if(isAttack)
            {
                timer += Time.deltaTime;
                if(timer>=timeSwordToBack)
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
            if(isBack)
            {
                timerToHide += Time.deltaTime;
                if(timerToHide>=timeSwordToHide)
                {
                    goWeaponBack.SetActive(false);
                    timerToHide = 0;
                }
            }
        }
        #endregion


    }
}
