namespace AngbandOS.Core.Interface;

public class ClassPropertyMetadata : PropertyMetadata
{
    public ClassPropertyMetadata() : base("", "") { }

    public new string? EntityTitle
    {
        get => base.EntityTitle;
        set => base.EntityTitle = value;
    }

    public new string? EntityNamePropertyName
    {
        get => base.EntityNamePropertyName;
        set => base.EntityNamePropertyName = value;
    }

    public new string? EntityKeyPropertyName
    {
        get => base.EntityKeyPropertyName;
        set => base.EntityKeyPropertyName = value;
    }
}