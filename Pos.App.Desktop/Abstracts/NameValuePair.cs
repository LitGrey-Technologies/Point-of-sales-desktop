namespace Pos.App.Desktop.Abstracts
{
    public class NameValuePair<T>
    {
        public NameValuePair(string name, T value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; set; }
        public T Value { get; set; }
    }

    public class NameValuePair : NameValuePair<string>
    {
        public NameValuePair(string name, string value) : base(name, value)
        {

        }
    }

}
