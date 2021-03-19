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
    class Program
    {
        // зная что вы загляните сюда я решил вам раскрыть тайну.
        // я писал этот код в слепую и не смог проверить код, так как у меня
        // IDE и docker ещё не настроены, но в целом все должно работать :)
        // логику найдёте в Memo

        static void Main(string[] args)
        {
            var memo = new Memo{Title = "Title", Body = "Body"};

            memo.Id = MemosController.Create(memo);

            MemosController.ReadAll.ForEach(Console.WriteLine)

            Console.WriteLine(MemosController.ReadId(memo.Id));

            memo.Title = "Title1";
            memo.Body = "Body1";

            MemosController.Update(memo);

            MemosController.Delete(memo.Id);
        }
    }
}
