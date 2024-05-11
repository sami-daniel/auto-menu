namespace AutoMenu.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AllowedUserAttribute : Attribute
    {
    }
}
