namespace PulseGenerator.InitData
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    ///     The service for save.
    /// </summary>
    /// <seealso cref="PulseGenerator.InitData.ISave" />
    public class Save : ISave
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="Save" /> class.
        /// </summary>
        /// <param name="fileHelper">The file helper.</param>
        public Save(IFileHelper fileHelper)
        {
            this.FileHelper = fileHelper;
        }

        #endregion

        #region Properties

        private IFileHelper FileHelper { get; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Does this instance.
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
                var path = this.FileHelper.GetPath();

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