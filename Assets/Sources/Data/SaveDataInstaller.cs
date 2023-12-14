using Zenject;

public class SaveDataInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var saver = new Saver();
        SaveData data = saver.Load();

        Container.Bind<SaveData>().FromInstance(data).AsSingle();
    }
}