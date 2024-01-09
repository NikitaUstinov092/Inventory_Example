using Zenject;

public class PlayerEntityInstaller : IInitializable
{
   private PlayerEntity _playerEntity;
   private DiContainer _diContainer;
   
   [Inject]
   public void Construct(PlayerEntity playerEntity, DiContainer diContainer)
   {
       _playerEntity = playerEntity;
       _diContainer = diContainer;
   }
    
   void IInitializable.Initialize()
   {
       _playerEntity.AddComponent(_diContainer.Resolve<UComponent_Equipment>()); 
       _playerEntity.AddComponent(_diContainer.Resolve<UComponenet_Effector>());
   }
}
