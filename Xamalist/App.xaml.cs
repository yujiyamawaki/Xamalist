﻿using Microsoft.WindowsAzure.MobileServices;
using Prism.Unity;
using Xamalist.Views;
using Microsoft.Practices.Unity;

namespace Xamalist
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        // アプリのエントリーポイント
        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        // コンテナに型を登録するメソッド
        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();

            // コンテナに モバイルサービスクライアントを登録
            var client = new MobileServiceClient(mobileAppUri: Consts.AzureWebsitesUrl);
            this.Container.RegisterInstance<IMobileServiceClient>(client);
            // AppData をコンテナに シングルトンで登録
            this.Container.RegisterType<IAppDataService, AppDataService>(new ContainerControlledLifetimeManager());
        }
    }
}

