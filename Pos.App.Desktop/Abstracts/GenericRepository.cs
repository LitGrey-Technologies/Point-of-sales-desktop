using MySqlConnector;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;

namespace Pos.App.Desktop.Abstracts
{
    public class GenericRepository
    {
        private readonly string _connectionString = "DataSource=localhost;Database=pos;port=3306;username=root;password=root";
        private MySqlConnection _connection;
        private MySqlCommand _dbCommand;

        public async Task<DataTable> GetAllAsync(string query)
        {
            _connection = new MySqlConnection(_connectionString);
            _dbCommand = new MySqlCommand(query, _connection);
            if (ValidateDbConnection())
            {
                var adapter = new MySqlDataAdapter(_dbCommand);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                await _connection.CloseAsync();
                return dataTable;
            }
            return null;
        }
        public async Task<ObservableCollection<NameValuePair>> GetNamedValuePairObservableCollectionLookUpsAsync(string query)
        {
            _connection = new MySqlConnection(_connectionString);
            _dbCommand = new MySqlCommand(query, _connection);
            if (ValidateDbConnection())
            {
                var valuePairs = new ObservableCollection<NameValuePair>();
                var adapter = new MySqlDataAdapter(_dbCommand);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    var id = row.ItemArray[0].ToString();
                    var name = row.ItemArray[1].ToString();
                    valuePairs.Add(new NameValuePair(name, id));
                }
                await _connection.CloseAsync();
                return valuePairs;
            }
            return null;
        }
        public async Task<DataTable> FindAsync(string query)
        {
            _connection = new MySqlConnection(_connectionString);
            _dbCommand = new MySqlCommand(query, _connection);
            var adapter = new MySqlDataAdapter(_dbCommand);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            await _connection.CloseAsync();
            return dataTable;
        }

        public async Task<int> GetCount(string query)
        {
            var data = await FindAsync(query);
            if (data.Rows.Count > 0)
            {
                return Convert.ToInt32(data.Rows[0].ItemArray[0]);
            }
            return 0;
        }
        public async Task<bool> ExecuteQueryAsync(string query)
        {
            _connection = new MySqlConnection(_connectionString);
            _dbCommand = new MySqlCommand(query, _connection);
            if (ValidateDbConnection())
            {
                return await Task.Run(() => _dbCommand.ExecuteNonQuery() > 0);
            }

            await _connection.CloseAsync();
            return false;
        }
        private bool ValidateDbConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection.State == ConnectionState.Open;
        }
    }
}
