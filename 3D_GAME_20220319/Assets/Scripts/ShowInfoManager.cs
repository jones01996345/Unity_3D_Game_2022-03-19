using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Jones
{
    /// <summary>
    /// ��ܸ�T�޲z��
    /// </summary>
    public class ShowInfoManager : MonoBehaviour
    {
        [SerializeField, Header("��o���~��T����")]
        private CanvasGroup groupInfo;
        [SerializeField, Header("���ܰT��")]
        private Text textInfo;

        public void ShowUI(string info,int value)
        {
            print("��ܪ��~��T"+info+"\n�ƭ�"+value);
            StartCoroutine(FadeIn());
            StartCoroutine(ScaleToOne());

            textInfo.text = info + "+" + value;

        }
        private IEnumerator FadeIn()
        {
            yield return new WaitForSeconds(0.2f);

            for (int i = 0; i < 10; i++)
            {
                groupInfo.alpha += 0.1f;
                yield return new WaitForSeconds(0.05f);
            }
        }
        private IEnumerator ScaleToOne()
        {
            yield return new WaitForSeconds(0.2f);
            RectTransform rect = groupInfo.GetComponent<RectTransform>();

            for (int i = 0; i < 10; i++)
            {
                rect.localScale += new Vector3(0, 0.1f, 0);
                yield return new WaitForSeconds(0.05f);
            }

        }

    }

}

