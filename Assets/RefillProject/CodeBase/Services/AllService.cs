using Assets.RefillProject.CodeBase.Infrastracture.Factory;
using Assets.RefillProject.CodeBase.Infrastracture.States;
using System;

namespace Assets.RefillProject.CodeBase.Services
{
    public class AllService                                       //Синглтон паттерн
    {
        private static AllService _instance;

        public static AllService Container => _instance ?? (_instance = new AllService());

        public void RegisterSingle<TService>(TService implementation) where TService : IService =>
            Implementation<TService>.ServiceInstance = implementation;

        public TService Single<TService>() where TService : IService => 
            Implementation<TService>.ServiceInstance;

        private static class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}
