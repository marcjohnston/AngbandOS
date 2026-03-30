
namespace AngbandOS.Core.Interface.Configuration;

public abstract class CompositeSingletonGameConfiguration : IGetKeyGameConfiguration
{
    public string GetKey => GameConfiguration.GetCompositeKey(CompositeKeys);
    public abstract string?[] CompositeKeys { get; }
}
