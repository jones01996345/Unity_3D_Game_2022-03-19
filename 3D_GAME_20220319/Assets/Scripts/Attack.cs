using UnityEngine;
using Invector.vCharacterController;

/// <summary>
/// 命名空間
/// </summary>
namespace Jones
{
    /// <summary>
    /// 攻擊系統
    /// 1.武器切換
    /// 2.攻擊動畫
    /// 3.刀光特效
    /// 4.攻擊判定
    /// </summary>
    public class Attack : MonoBehaviour
    {
        #region 欄位      
        private Animator ani;

        // SerializeField 序列化欄位:將私人欄位顯示屬性面板
        [SerializeField, Header("武器 背後")]
        private GameObject goWeaponBack;
        [SerializeField, Header("武器 手上")]
        private GameObject goWeaponHand;
        [SerializeField, Header("刀光")]
        private ParticleSystem psLight;
        [SerializeField, Header("第一階段收刀時間")]
        private float timeSwordToBack = 2.5f;
        [SerializeField, Header("第二階段收刀時間")]
        private float timeSwordToHide = 3.5f;
        [SerializeField, Header("攻擊時間"), Range(0.1f, 1.5f)]
        private float timeCD = 1.1f;
        [SerializeField, Header("攻擊區資料")]
        private Vector3 v3AttackSize = Vector3.one;
        [SerializeField]
        private Vector3 v3AttackOffset;
        [SerializeField]
        private LayerMask layerAttack;
        [SerializeField, Header("玩家資料")]
        private DatePlayer date;

        private string paramateterAttack = "觸發攻擊";
        private bool isAttack;
        private bool isBack;
        private bool CanAttack = true;
        private float timer;
        private float timerToHide;
        private float timerAttack;
        private vThirdPersonController controller;

        #endregion
        #region 事件
        private void OnDrawGizmos()
        {

            Gizmos.color = new Color(1, 0, 0, 0.3f);
            // matrix 設定圖示座標、角度與尺寸
            // TRS座標、角度與尺寸
            // transform.TransformDirection(座標)轉換區域座標與世界座標
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

        #region 方法
        /// <summary>
        /// 切換武器
        /// </summary>
        private void SwitchWeapon()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && CanAttack)
            {
                controller.lockMovement = true;                 //鎖定移動
                controller._rigidbody.velocity = Vector3.zero;

                goWeaponBack.SetActive(false);
                goWeaponHand.SetActive(true);

                ani.SetTrigger(paramateterAttack);      //觸發攻擊動畫
                psLight.Play();                         //播放攻擊特效
                CheckAttackArea();

                timer = 0;                              //每次攻擊計時重算
                isAttack = true;
                CanAttack = false;
                timerToHide = 0;
                isBack = false;
            }

        }
        /// <summary>
        /// 第一階段:刀子從手上收回背後
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

                    timer = 0;                      //收刀後計時器歸零
                    isAttack = false;
                    isBack = true;
                }
            }
        }

        /// <summary>
        /// 收刀第二階段:從背後隱藏
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
        /// 攻擊冷卻
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
        /// 檢查攻擊區域
        /// </summary>
        private void CheckAttackArea()
        {

            Collider[] hits = Physics.OverlapBox(
                transform.position + transform.TransformDirection(v3AttackOffset),
                v3AttackSize / 2, Quaternion.identity, layerAttack);
            if (hits.Length > 0)
            {
                //print("<color=yallow>敵人擊中目標:" + hits[0].name +"</color>");               
                hits[0].GetComponent<HurtAndDropSystem>().GetHurt(date.attack);
            }
        }
        #endregion
    }
}
         

