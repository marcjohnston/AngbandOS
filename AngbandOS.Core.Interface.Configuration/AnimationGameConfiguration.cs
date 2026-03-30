
namespace AngbandOS.Core.Interface.Configuration;

public class AnimationGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual char Character { get; set; }
    public virtual ColorEnum Color { get; set; }
    public virtual string Name { get; set; }
    public virtual ColorEnum AlternateColor { get; set; }
    public virtual string Sequence { get; set; }
}
