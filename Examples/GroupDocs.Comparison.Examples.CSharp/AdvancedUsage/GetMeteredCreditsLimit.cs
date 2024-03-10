﻿using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Options;

    /// <summary>
    /// This example demonstrates how to get credit consumption quantity
    /// </summary>
    class GetMeteredCreditsLimit
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # GetMeteredCreditsLimit : how to get credit consumption quantity\n");

            Console.WriteLine("Credits before using Comparer: {0}", Metered.GetConsumptionQuantity());
            using (Comparer comparer = new Comparer(Constants.SOURCE_WORD))
            {
                comparer.Add(Constants.TARGET_WORD);
                comparer.Compare(File.Create(Constants.RESULT_WORD), new SaveOptions(), new CompareOptions());
            }
            Console.WriteLine("Credits after using Comparer: {0}", Metered.GetConsumptionQuantity());
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}
