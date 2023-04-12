using Content.Shared.CartridgeLoader;
using Content.Server.Atmos.Components;
using Robust.Server.GameObjects;
using Content.Shared.Atmos.Components;
using Content.Server.Atmos.EntitySystems;
using Robust.Shared.Containers;

namespace Content.Server.CartridgeLoader.Cartridges;

public sealed class GasAnalyzerCartridgeSystem : EntitySystem
{

    [Dependency] private readonly GasAnalyzerSystem _gasAnalyzerSystem = default!;
    [Dependency] private readonly IEntityManager _entityManager = default!;
    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<GasAnalyzerCartridgeComponent, CartridgeInstalledEvent>(OnInstallation);
        SubscribeLocalEvent<GasAnalyzerCartridgeComponent, CartridgeUninstalledEvent>(OnRemoval);
    }

    private void OnInstallation(EntityUid uid, GasAnalyzerCartridgeComponent component, CartridgeInstalledEvent args)
    {
        var loaderComp = EntityManager.GetComponent<CartridgeLoaderComponent>(args.Loader);
        var PDA = loaderComp.Owner;
        _entityManager.AddComponent<GasAnalyzerComponent>(PDA);
    }

    private void OnRemoval(EntityUid uid, GasAnalyzerCartridgeComponent component, CartridgeUninstalledEvent args)
    {
        var loaderComp = EntityManager.GetComponent<CartridgeLoaderComponent>(args.Loader);
        var PDA = loaderComp.Owner;
        _entityManager.RemoveComponent<GasAnalyzerComponent>(PDA);
        
    }
}
