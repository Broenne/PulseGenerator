namespace PulseGenerator.InitData
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///  The service for save initialize.
    /// </summary>
    public interface ISave
    {
        /// <summary>
        /// Does this instance.
        /// </summary>
        /// <param name="values">The values.</param>
        void Do(IReadOnlyList<string> values);
    }
}