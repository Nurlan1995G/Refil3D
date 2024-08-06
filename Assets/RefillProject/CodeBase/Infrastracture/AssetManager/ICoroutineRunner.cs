using System.Collections;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.Infrastracture.AssetManager
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}