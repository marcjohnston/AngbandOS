using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class PlainRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override string Name => "Plain";
}
