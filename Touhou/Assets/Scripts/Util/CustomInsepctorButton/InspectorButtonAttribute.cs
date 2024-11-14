using System;

[AttributeUsage(AttributeTargets.Method)]
public class InspectorButtonAttribute : Attribute
{
    public String Name { get; }
    public Boolean InEditMode { get; }
    public InspectorButtonAttribute(String pName)
    {
        Name = pName;
        InEditMode = false;
    }

    public InspectorButtonAttribute(String pName, Boolean InEditMode)
    {
        Name = pName;
        this.InEditMode = InEditMode;
    }
}
