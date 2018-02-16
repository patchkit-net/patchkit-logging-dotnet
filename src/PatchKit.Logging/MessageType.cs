namespace PatchKit.Logging
{
    /// <summary>
    /// Type of message.
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// Very detailed description about operation.
        /// Examples: 
        /// * Response from API
        /// * Downloaded file size
        /// </summary>
        Trace,

        /// <summary>
        /// Regular operation description.
        /// Examples:
        /// * "Unarchiving content package..."
        /// * "Requesting application info from API..."
        /// * "Unarchiving has been finished."
        /// </summary>
        Debug,

        /// <summary>
        /// Issue that is recoverable (in scope of current operation).
        /// Examples:
        /// * "Torrent download has failed. Falling back to HTTP downloader..."
        /// * "Connection has timed out. Trying again in 5 seconds..."
        /// * "Diff strategy has failed. Falling back to content strategy..."
        /// * "Main server didn't respond. Falling back to cache servers..."
        /// </summary>
        Warning,

        /// <summary>
        /// Issue that is not recoverable (in scope of current operation).
        /// Examples:
        /// * "Received invalid data from server."
        /// * "Downloaded file hash is invalid."
        /// * "Main server responded with error code 404."
        /// </summary>
        Error,
    }
}