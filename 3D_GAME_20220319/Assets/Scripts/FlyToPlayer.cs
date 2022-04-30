using UnityEngine;
namespace Jones
{
    public class FlyToPlayer : MonoBehaviour
    {
        [SerializeField, Header("���𭸦�ɶ�"), Range(0, 10)]
        private float delayToFly = 2.5f;
        [SerializeField, Header("����t��"), Range(0, 100)]
        private float speed = 10;
        [SerializeField, Header("�Z�����a�h�ִN�R���ç�s"), Range(0, 10)]
        private float distanceToDestory = 5;


        private Transform traPlayer;
        private string namePlayer = "�D��";
        private CoinManager coinManager;

        private void Awake()
        {
            Physics.IgnoreLayerCollision(3, 8);    //���a �P ���� ���I�� 
            Physics.IgnoreLayerCollision(8, 8);    //���� �P ���� ���I�� 
                
            traPlayer = GameObject.Find(namePlayer).transform;
            enabled = false;
            Invoke("DelayToFly", delayToFly);       // ����2.5��I�sDelayToFly
            coinManager = GameObject.Find("�����޲z��").GetComponent<CoinManager>();
        }

        //float a = 0, b = 10;
        private void Update()
        {
            //�m�߮t��
            //a=Mathf.Lerp(a, b, 0.5f);
            //print("A��:" + a);
            Fly();
        }
        private void DelayToFly()
        {
            enabled = true;
        }

        /// <summary>
        /// ����
        /// </summary>
        private void Fly()
        {
            Vector3 posCoin = transform.position;
            Vector3 posPlayer = traPlayer.position;

            posCoin = Vector3.Lerp(posCoin, posPlayer, speed * Time.deltaTime);

            transform.position = posCoin;
            CheckDistanceAndDesTroy();
        }

        /// <summary>
        /// �ˬd�Z���çR������
        /// </summary>
        private void CheckDistanceAndDesTroy()
        {
            float dis = Vector3.Distance(transform.position, traPlayer.position);
            if (dis<=distanceToDestory)
            {
                coinManager.AddCoin();
                Destroy(gameObject);
            }
        }
    }

}
