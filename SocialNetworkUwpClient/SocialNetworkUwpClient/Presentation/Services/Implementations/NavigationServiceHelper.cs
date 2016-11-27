using System;
using System.Linq;
using System.Reflection;
using GalaSoft.MvvmLight.Views;
using SocialNetworkUwpClient.Presentation.Models;

namespace SocialNetworkUwpClient.Presentation.Services.Implementations
{
    public static class NavigationServiceHepler
    {
        private static NavigationService _appNavigationService;
        private static MemberInfo[] _memberInfos;

        static NavigationServiceHepler()
        {
            Configurate();
        }

        public static Type GetPageTypeByKey(PageKeys pageKey)
        {
            string pageKeyName = pageKey.ToString();
            var pageMemberInfo = _memberInfos.Single(x => x.Name == pageKeyName);

            return GetTypeByMemberInfo(pageMemberInfo);
        }


        private static void Configurate()
        {
            _appNavigationService = new NavigationService();

            _memberInfos = typeof(PageKeys).GetMembers(BindingFlags.Public | BindingFlags.Static);

            foreach (var memberInfo in _memberInfos)
            {
                string typePath = memberInfo.CustomAttributes.First().ConstructorArguments.First().Value.ToString();
                Type pageType = Type.GetType(typePath);

                _appNavigationService.Configure(memberInfo.Name, pageType);
            }
        }


        private static Type GetTypeByMemberInfo(MemberInfo memberInfo)
        {
            string typePath = memberInfo.CustomAttributes.First().ConstructorArguments.First().Value.ToString();
            return Type.GetType(typePath);
        }

        public static INavigationService GetService => _appNavigationService;
    }
}