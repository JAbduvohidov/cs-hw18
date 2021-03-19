using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace homework18
{
    public record Memo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Body { get; set; }
    }

    public static class MemosController
    {
        private const string connectionString = @"Data source=YOUR_DATA_SOURCE; Initial catalog=Memos; Integrated Security = True";

        public static Memo Create(Memo memo)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                int? memoId = db.Query<int>("INSERT INTO Memos (Title, Body) VALUES(@Title, @Body); SELECT CAST(SCOPE_IDENTITY() as int)", memo).FirstOrDefault;
                memo.Id = memoId;
            }
            return memo;
        }

        public static List<Memo> ReadAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Memo>("SELECT Id, Title, Body FROM Memos").ToList();
            }
        }

        public static Memo ReadId(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Memo>("SELECT Id, Title, Body FROM Memos WHERE Id = @Id", new { id }).FirstOrDefault();
            }
        }

        public static void Update(Memo memo)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute("UPDATE Memos SET Title = @Title, Body = @Body WHERE Id = @Id", memo);
            }
        }

        public static void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute("DELETE FROM Memos WHERE Id = @Id", new { id });
            }
        }
    }
}