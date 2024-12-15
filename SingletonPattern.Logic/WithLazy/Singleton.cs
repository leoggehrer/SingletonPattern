namespace SingletonPattern.Logic.WithLazy
{
    /// <summary>
    /// Represents a thread-safe singleton class using lazy initialization.
    /// </summary>
    public sealed class Singleton
    {
        /// <summary>
        /// Provides a lazy-initialized instance of the <see cref="Singleton"/> class.
        /// </summary>
        private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());

        /// <summary>
        /// Prevents a default instance of the <see cref="Singleton"/> class from being created.
        /// </summary>
        private Singleton()
        {
        }

        /// <summary>
        /// Gets the singleton instance of the <see cref="Singleton"/> class.
        /// </summary>
        public static Singleton Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        /// <summary>
        /// Example method of the singleton class.
        /// </summary>
        public void DoSomething()
        {
            Console.WriteLine("Singleton instance with lazy is working!");
        }
    }
}

