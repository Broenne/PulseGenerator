namespace PulseGenerator.InitData
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// The file load service.
    /// </summary>
    /// <seealso cref="PulseGenerator.InitData.ILoad" />
    public class Load : ILoad
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Load"/> class.
        /// </summary>
        /// <param name="fileHelper">The file helper.</param>
        public Load(IFileHelper fileHelper)
        {
            this.FileHelper = fileHelper;
        }

        #endregion

        #region Properties

        private IFileHelper FileHelper { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Does this instance.
        /// </summary>
        /// <returns>Return the lines.</returns>
        public IReadOnlyList<ChannelInfo> Do()
        {
            try
            {
                var path = this.FileHelper.GetPath();
                
                var res = new List<ChannelInfo>();

                if(File.Exists(path))
                {
                    var lines = File.ReadAllLines(path);

                    foreach (var item in lines)
                    {
                        var spliitedLines = item.Split(';');

                        if (spliitedLines.Length != 3)
                        {
                            break;
                        }

                        // todo mb: das muss woanders vernünftig gemacht werden
                        res.Add(new ChannelInfo(Convert.ToUInt32(spliitedLines[0]), Convert.ToUInt32(spliitedLines[1]), Convert.ToUInt32(spliitedLines[2])));
                    }
                }
                
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}