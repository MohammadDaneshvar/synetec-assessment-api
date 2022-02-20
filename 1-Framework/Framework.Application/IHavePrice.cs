namespace Framework.Application
{
    public interface IHaveCost
    {
        long Price { get; set; }
        bool OnlyCalculateCommandPrice { get; set; }
    }
}
