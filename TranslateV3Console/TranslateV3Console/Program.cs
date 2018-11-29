using System;

namespace TranslateV3Console
{
    class Program
    {
        static  void Main(string[] args)
        {
            Console.WriteLine("Translation Demos");
            Translate.DoTranslateAsync().Wait();
            
            Languages.GetLanguagesAsync().Wait();
            Transliterate.DoTransliterateAsync().Wait();
            BreakSentence.DoBreak().Wait();
            Detect.DoDetect().Wait();
            DictionaryExamples.DoExamples().Wait();
            DictionaryLookup.DoLookup().Wait();

            Console.WriteLine("hit any key to continue");
            Console.ReadLine();
        }
    }
}
