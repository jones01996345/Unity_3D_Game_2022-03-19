using UnityEngine;

/// <summary>
/// �R�W�Ŷ�
/// </summary>
namespace Jones
{
    /// <summary>
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

        private string paramateterAttack = "Ĳ�o����";
        #endregion
        #region �ƥ�
        private void Awake()
        {
            ani = GetComponent<Animator>();
        }
        private void Update()
        {
            SwitchWeapon();
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

                ani.SetTrigger(paramateterAttack);
                psLight.Play();
            }

        }
        #endregion


    }
}
