using System;
using System.Collections;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.Logic
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup Curtain;

        private void Awake() => 
            DontDestroyOnLoad(this);

        public void Show()
        {
            gameObject.SetActive(true);
            Curtain.alpha = 1f;
        }

        public void Hide() =>
            StartCoroutine(DoFideIn());

        private IEnumerator DoFideIn()
        {
            while(Curtain.alpha > 0) 
            {
                Curtain.alpha -= 0.03f;
                yield return new WaitForSeconds(0.03f);
            }

            gameObject.SetActive(false);
        }
    }
}