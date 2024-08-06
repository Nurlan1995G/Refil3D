using Assets.RefillProject.CodeBase.Services;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.Infrastracture.AssetManagment
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}