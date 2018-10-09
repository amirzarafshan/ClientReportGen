using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Dapper;

namespace ClientScripts.Database
{
    public class DBProviderBase
    {
        private readonly string _connString;

        public DBProviderBase()
        {
            _connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\pcm\PCMClient\pcmclient.mdb;Jet OLEDB:Database Password=PCMusic321;";
        }

        public DBProviderBase(string connString)
        {
            _connString = connString;
        }

        private IDbConnection GetDbConnection()
        {
            return new OleDbConnection(_connString);
        }

        public IEnumerable<T> Read<T>(string sql, object data)
        {
            using (var cn = GetDbConnection())
            {
                cn.Open();
                return cn.Query<T>(sql, data);
            }
        }
        public void Write(string sql, object data)
        {
            using (var cn = GetDbConnection())
            {
                cn.Open();
                using (var tran = cn.BeginTransaction())
                {
                    try
                    {
                        cn.Execute(sql, data, tran);
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
