namespace TestManager.Utilites.Attributes
{
    public enum Modules
    {
        [ModuleName("Main",typeof(int))]
        Main,
        [ModuleName("Receive", typeof(int))]
        Receive,
        [ModuleName("Issue", typeof(int))]
        Issue,
        [ModuleName("Activities", typeof(int))]
        Activities,
        [ModuleName("Finance", typeof(int))]
        Finance,
    }
}