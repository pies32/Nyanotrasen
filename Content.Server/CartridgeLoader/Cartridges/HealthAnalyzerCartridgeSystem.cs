using Content.Shared.CartridgeLoader;
using Content.Server.Medical.Components;
using Content.Server.Medical;

using static Content.Shared.MedicalScanner.SharedHealthAnalyzerComponent;
using Content.Shared.MedicalScanner;

namespace Content.Server.CartridgeLoader.Cartridges;

public sealed class HealthAnalyzerCartridgeSystem : EntitySystem
{
    [Dependency] private readonly IEntityManager _entityManager = default!;
    [Dependency] private readonly HealthAnalyzerSystem _healthAnalyzerSystem = default!;
    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<HealthAnalyzerCartridgeComponent, CartridgeInstalledEvent>(OnInstallation);
        SubscribeLocalEvent<HealthAnalyzerCartridgeComponent, CartridgeUninstalledEvent>(OnRemoval);

    }
    private void OnInstallation(EntityUid uid, HealthAnalyzerCartridgeComponent component, CartridgeInstalledEvent args)
    {
        var loaderComp = EntityManager.GetComponent<CartridgeLoaderComponent>(args.Loader);
        var PDA = loaderComp.Owner;
        HealthAnalyzerComponent analyzerComp = _entityManager.AddComponent<HealthAnalyzerComponent>(PDA);
        analyzerComp.ScanDelay = component.ScanDelay;
        analyzerComp.ScanningBeginSound = component.ScanningBeginSound;
        analyzerComp.ScanningEndSound = component.ScanningEndSound;
    }

    private void OnRemoval(EntityUid uid, HealthAnalyzerCartridgeComponent component, CartridgeUninstalledEvent args)
    {
        var loaderComp = EntityManager.GetComponent<CartridgeLoaderComponent>(args.Loader);
        var PDA = loaderComp.Owner;
        _entityManager.RemoveComponent<HealthAnalyzerComponent>(PDA);
        
    }
}
