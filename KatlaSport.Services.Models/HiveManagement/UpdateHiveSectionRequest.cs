namespace KatlaSport.Services.HiveManagement
{
    public class UpdateHiveSectionRequest
    {
        /// <summary>
        /// Gets or sets a store hive name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a store hive code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the hive identifier.
        /// </summary>
        public int HiveId { get; set; }
    }
}
