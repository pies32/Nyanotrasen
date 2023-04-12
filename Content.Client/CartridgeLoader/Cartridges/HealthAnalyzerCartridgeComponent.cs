using Content.Shared.MedicalScanner;

namespace Content.Server.CartridgeLoader.Cartridges;

[RegisterComponent]
[ComponentReference(typeof(SharedHealthAnalyzerCartridgeComponent))]
public sealed class HealthAnalyzerCartridgeComponent : SharedHealthAnalyzerCartridgeComponent
{
}


