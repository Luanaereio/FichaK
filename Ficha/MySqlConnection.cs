using System;
using System.Data;

namespace Ficha
{
    internal class MySqlConnection
    {
        public MySqlConnection(string connectionString)
        {
        }

        public ConnectionState State { get; internal set; }

        internal void Close()
        {
            throw new NotImplementedException();
        }

        internal void Dispose()
        {
            throw new NotImplementedException();
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }
    }
}