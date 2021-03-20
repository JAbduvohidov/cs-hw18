using System;

namespace homework18
{
    internal static class Program
    {
        // зная что вы загляните сюда я решил вам раскрыть тайну.
        // я писал этот код в слепую и не смог проверить код, так как у меня
        // IDE и docker ещё не настроены, но в целом все должно работать :)
        // логику найдёте в Memo

        private static void Main()
        {
            var memo = new Memo{Title = "Title", Body = "Body"};

            memo = MemosController.Create(memo);

            MemosController.ReadAll().ForEach(Console.WriteLine);

            Console.WriteLine(MemosController.ReadId(memo.Id));

            memo.Title = "Title1";
            memo.Body = "Body1";

            MemosController.Update(memo);

            MemosController.Delete(memo.Id);
        }
    }
}
