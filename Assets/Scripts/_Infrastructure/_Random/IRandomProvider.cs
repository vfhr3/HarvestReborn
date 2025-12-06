namespace Utils.Random
{
    public interface IRandomProvider
    {
        float Value();
        float Range(float min, float max);
    }
}