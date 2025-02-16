namespace URLShortnerMicroserivce.Model
{
    /// <summary>
    /// Response model class for the getOrignalUrl method.
    /// </summary>
    public class GetOrignalUrlResponse : GenerateShortUrlResponse
    {
        /// <summary>
        /// This will be filled only if any error or entry not present in DB.
        /// </summary>
        public string message {  get; set; }
    }
}
