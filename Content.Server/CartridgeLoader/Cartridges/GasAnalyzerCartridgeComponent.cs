using Content.Shared.CartridgeLoader.Cartridges;
using Content.Shared.Atmos.Components;
using Content.Server.UserInterface;
using Robust.Server.GameObjects;
using Robust.Shared.Map;

namespace Content.Server.CartridgeLoader.Cartridges;

[RegisterComponent]
public sealed class GasAnalyzerCartridgeComponent : Component
{
    [ViewVariables] public EntityUid? Target;
    [ViewVariables] public EntityUid User;
    [ViewVariables] public EntityCoordinates? LastPosition;
    [ViewVariables] public bool Enabled;
}


