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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // First I need an array that is the right size so I have a place to store each multiple.
        // Then I can loop through every index from the beginning to the end of that array.
        // Since the first value should be the starting number itself, the pattern is really
        // number times 1, then number times 2, then number times 3, and so on.
        // While I am looping, I can use the current index to figure out which multiple I need
        // and store that answer in the matching spot in the array.
        // After the loop finishes, the array should be completely filled in and ready to return.

        double[] results = new double[length];

        for (int index = 0; index < length; index++)
        {
            results[index] = number * (index + 1);
        }

        return results;
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // To rotate right, I want to figure out where the list should split.
        // The values on the right side of that split are the ones that need to move to the front.
        // After that, the values that were at the beginning should stay in the same order and go after them.
        // Using ranges makes this easier to read because I can grab both parts of the list directly.
        // Once I have those two pieces, I can clear the original list and rebuild it in the rotated order.

        int splitIndex = data.Count - (amount % data.Count);

        List<int> rightSide = data.GetRange(splitIndex, data.Count - splitIndex);
        List<int> leftSide = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(rightSide);
        data.AddRange(leftSide);
    }
}
