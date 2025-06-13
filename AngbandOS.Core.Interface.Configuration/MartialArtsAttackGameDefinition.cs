namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class MartialArtsAttackGameDefinition
{
    public virtual string Key { get; set; }
    public virtual int Chance { get; set; }
    public virtual int Dd { get; set; }
    public virtual string Desc { get; set; }
    public virtual int Ds { get; set; }
    protected virtual string MartialArtsEffectBindingKey { get; set; }
    public virtual int MinLevel { get; set; }
    public virtual bool IsDefault { get; set; } = false;
}