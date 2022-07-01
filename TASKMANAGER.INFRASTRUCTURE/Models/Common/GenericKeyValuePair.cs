namespace TASKMANAGER.INFRASTRUCTURE.Models.Common
{
    public class GenericKeyValuePair
    {
        public string Key { get; set; }
        public string Value {get ; set; }

        public GenericKeyValuePair(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public GenericKeyValuePair()
        {
            Key = "";
            Value = "";
        }

        public GenericKeyValuePair(string value)
        {
            Key = value;
            Value = value;
        }
    }
}
