using Content.Shared.MedicalScanner;
using Robust.Shared.Serialization;

namespace Content.Server.CartridgeLoader.Cartridges;

[Serializable, NetSerializable]
[ComponentReference(typeof(Shared.MedicalScanner.SharedHealthAnalyzerComponent))]
public abstract class SharedHealthAnalyzerCartridgeComponent : Shared.MedicalScanner.SharedHealthAnalyzerComponent
{
   
}


