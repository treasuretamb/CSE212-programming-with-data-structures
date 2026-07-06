public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create a fixed array of doubles with size 'length'.
        // 2. Loop through each index from 0 to length-1.
        // 3. At each index i, the multiple we want is 'number' times (i + 1),
        //    since the first item (index 0) should be 1 times number,
        //    the second item (index 1) should be 2 times number, and so on.
        // 4. Store that value in the array at index i.
        // 5. Return the completed array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. The last 'amount' items in the list need to move to the front,
        //    while everything else keeps its relative order and slides
        //    'amount' positions to the right.
        // 2. Take a copy of the last 'amount' items using GetRange, starting
        //    at index (data.Count - amount).
        // 3. Remove those same items from the end of the list using RemoveRange.
        // 4. Insert the copied items back at the beginning of the list (index 0)
        //    using InsertRange. This shifts the remaining original items to the
        //    right automatically.
        // 5. Because 'data' is modified directly (not returned), there is
        //    nothing to return - the caller's list is updated in place.

        List<int> endItems = data.GetRange(data.Count - amount, amount);
        data.RemoveRange(data.Count - amount, amount);
        data.InsertRange(0, endItems);
    }
}
