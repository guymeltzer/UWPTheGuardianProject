using MvvmCross.IoC;
using MvvmCross.ViewModels;
using TheGuardianWebAPI.Core.ViewModels;

namespace TheGuardianWebAPI.Core
{
    public class App : MvxApplication
{
    public override void Initialize()
    {
        CreatableTypes()
            .EndingWith("Service")
            .AsTypes()
            .RegisterAsLazySingleton();
        RegisterAppStart<HomeViewModel>();
    }
}
}