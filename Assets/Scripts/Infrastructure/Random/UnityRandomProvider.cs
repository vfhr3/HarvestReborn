namespace Infrastructure.Random
{
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