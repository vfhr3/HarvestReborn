namespace Infrastructure.Random
{
    public interface IRandomProvider
    {
        float Value();
        float Range(float min, float max);
    }
}