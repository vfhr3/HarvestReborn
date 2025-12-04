namespace Utils.Random
{
    public interface IRandomProvider
    {
        float Value();
        float Range(float min, float max);
    }

    public class UnityRandomProvider : IRandomProvider
    {
        public float Value()
        {
            return UnityEngine.Random.value;
        }

        public float Range(float min, float max)
        {
            return UnityEngine.Random.Range(min, max);
        }
    }
}