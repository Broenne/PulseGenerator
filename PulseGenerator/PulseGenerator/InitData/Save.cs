namespace PulseGenerator.InitData
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    /// <summary>
    ///     The service for save.
    /// </summary>
    /// <seealso cref="PulseGenerator.InitData.ISave" />
    public class Save : ISave
    {
        #region Public Methods

        /// <summary>
        /// Does this instance.
        /// </summary>
        /// <param name="values">The values.</param>
        public void Do(IReadOnlyList<string> values)
        {
            try
            {
                if (values == null)
                {
                    return;
                }
                
                this.SaveToFile(values);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        private void SaveToFile(IReadOnlyList<string> values)
        {
            try
            {
                var directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                var path = $@"{directoryPath}\init.conf";

                File.WriteAllLines(path, values);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // ignore weil nicht so wichtig
                // throw;
            }
        }

        #endregion
    }
}