using UnityEngine;
using UnityEngine.UI;
namespace Jones
{
    /// <summary>
    /// �����޲z
    /// </summary>
    public class CoinManager : MonoBehaviour
    {
        /// <summary>
        /// ������r
        /// </summary>
        [SerializeField,Header("������r")]
        private Text textCoin;
        private int coinTotal;
        /// <summary>
        /// �K�[����
        /// </summary>
        public void AddCoin()
        {
            coinTotal++;
            textCoin.text = "Coin" + coinTotal;
        }
    }
    
}

