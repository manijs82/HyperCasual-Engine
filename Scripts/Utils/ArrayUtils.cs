namespace HyperCasual_Engine.Utils
{
    public static class ArrayUtils
    {
        public static float GetSumUntilIndex(float[] array, int index)
        {
            float result = 0;
            for (int i = 0; i <= index; i++)
            {
                result += array[i];
            }

            return result;
        }
    }
}