public static class ArrayShiftExtension {
    public static void ShiftRight<T>(this T[] array) {
        for(int i=array.Length-1; i > 0; i--)
        {
            array[i] = array[i - 1];
        }
    }

    public static void ShiftLeft<T>(this T[] array)
    {
        for (int i = 0; i < array.Length-1; ++i)
        {
            array[i] = array[i + 1];
        }
    }
}
