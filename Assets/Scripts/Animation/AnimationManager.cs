using System;
using System.Collections;
using UnityEngine;

namespace Animation
{
    public class AnimationManager : MonoBehaviour
    {
        private Animator _animator;
        private float _currentBlendAmount;
        private float _initialTime;
        private float _endTime;
        private Coroutine _blendWeightCoroutine;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void GetTorchAnimation()
        {
            _blendWeightCoroutine = StartCoroutine(IncrementBlendAmount());
        }
        
        private IEnumerator IncrementBlendAmount()
        {
            while (_currentBlendAmount < 1f)
            {
                _currentBlendAmount += Time.deltaTime * 5f;
                float layerWeight = Mathf.Lerp(0, 1, _currentBlendAmount);
                _animator.SetLayerWeight(1,layerWeight);
                yield return null;
            }
            _animator.SetLayerWeight(1,1f);
            
        }
    }
}
