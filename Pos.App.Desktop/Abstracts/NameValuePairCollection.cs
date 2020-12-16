using System.Collections.ObjectModel;

namespace Pos.App.Desktop.Abstracts
{
    public static class NameValuePairCollection
    {
        public static ObservableCollection<NameValuePair> BooleanDataSource = new ObservableCollection<NameValuePair>
        {
            new NameValuePair("YES","1"),
            new NameValuePair("NO","0"),
        };
    }
}
