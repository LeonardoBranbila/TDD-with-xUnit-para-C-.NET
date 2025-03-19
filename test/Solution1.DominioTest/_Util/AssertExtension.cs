namespace Solution1.DominioTest._Util
{
    public static class AssertExtension
    {
        public static void WithMessage(this ArgumentException exception, string message)
        {
            if (exception.Message == message) Assert.True(true);
            else Assert.False(true, $"I was expecting the message: {message}");
        }

    }
}
