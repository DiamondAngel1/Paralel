using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace paralel{
class Program{
    static void Main(){
        string folderFor = @"C:\Users\User\Desktop\firstFolder";
        string folderTo = @"C:\Users\User\Desktop\secondFolder"; 

        if (!Directory.Exists(folderFor) || !Directory.Exists(folderTo)){
            Console.WriteLine("Одна з папок не існує");
            return;
        }

        string[] files = Directory.GetFiles(folderFor);
        
        Console.WriteLine($"Знайдено {files.Length} файлів");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        
        //For
        for (int i = 0; i < files.Length; i++){
            string destFile = Path.Combine(folderTo, Path.GetFileName(files[i]));
            File.Copy(files[i], destFile, true);
        }
        
        stopwatch.Stop();
        Console.WriteLine($"Час For: {stopwatch.ElapsedMilliseconds} мс");

        stopwatch.Restart();
        
        //Paralel.for
        Parallel.For(0, files.Length, i =>{
            string destFile = Path.Combine(folderTo, Path.GetFileName(files[i]));
            File.Copy(files[i], destFile, true);
        });

        stopwatch.Stop();
        Console.WriteLine($"Час Parallel.For: {stopwatch.ElapsedMilliseconds} мс");
    }
}

}
