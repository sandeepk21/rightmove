namespace RightMoveADF.API
{
    public class ResponceUkProperty
    {
        public string Request_ID { get; set; }
        public string Message { get; set; }
        public int Success { get; set; }
        public DateTime? Request_Timestamp { get; set; }    
        public DateTime? Response_Timestamp { get; set; }
        public object Entity { get; set; }
        public object Warnings { get; set; }
        public object Errors { get; set; }
    }
}
