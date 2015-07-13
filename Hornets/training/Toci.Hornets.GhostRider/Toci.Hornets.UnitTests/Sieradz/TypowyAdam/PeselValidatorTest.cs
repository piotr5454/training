﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Hornets.GhostRider.YourWork.TasksTrainingTwo;
using Toci.Hornets.Sieradz.Duch.Homework_2.PeselValidator;
using Toci.Hornets.Sieradz.Quicksilver.TasksTrainingTwoQs;
using Toci.Hornets.Sieradz.TypowyAdam.UndergroundTasks;
using Toci.Hornets.Sieradz.UCantTouchThis.TasksTrainingTwo;
using Toci.Hornets.Sieradz.UCantTouchThis.UndergroundTasks.PeselValidator;

namespace Toci.Hornets.UnitTests.Sieradz.TypowyAdam
{
    [TestClass]
    public class PeselValidatorTest
    {
        private static string testDirectory = @"..\..\Sieradz\TypowyAdam\";
        private static string assemblyName = "Toci.Hornets.Sieradz";
        private static int iterationValue = 100;
        private static List<object> peselValidatorsList = new List<object>();
        private static List<List<string>> peselListsList = new List<List<string>>();
        private static Dictionary<string, Func<string, bool>> validatorFactory = new Dictionary<string, Func<string, bool>>();
        private static Dictionary<string, long> benchmarkTimes = new Dictionary<string, long>();
        
        [TestMethod]
        public void TestMethod1()
        {
            Stopwatch benchmark = new Stopwatch();
            benchmark.Start();
            GenerateListOfPeselLists(testDirectory);
            GenerateObjectList(assemblyName);
            GenerateMethodFactory();
            benchmark.Stop();
            benchmarkTimes.Add("Generating structures takes: ", benchmark.ElapsedMilliseconds);
            foreach (var isPeselValid in validatorFactory)
            {
                benchmark.Reset();
                benchmark.Start();
                for (int j = 0; j < iterationValue; j++)
                {
                    foreach (var peselLists in peselListsList)
                    {
                        for (int i = 0; i < peselLists.Count - 1; i++) //foreach (var pesel in peselLists)
                        {
                            Assert.AreEqual(isPeselValid.Value(peselLists[i]), (peselLists.Last() == "true"));
                        }


                    }
                }
                benchmark.Stop();
                benchmarkTimes.Add(isPeselValid.Key, benchmark.ElapsedMilliseconds);
            }
            PrintBenchmarkTimes();
        }

        private static void PrintBenchmarkTimes()
        {
            foreach (var benchmarkTime in benchmarkTimes)
            {
                Debug.Print("{0}: {1}ms", benchmarkTime.Key,benchmarkTime.Value);
            }
        }

        private static void GenerateMethodFactory()
        {
            foreach (PeselValidator o in peselValidatorsList)
            {
                validatorFactory.Add(o.GetNick(), o.IsPeselValid);
            }
        }
        private static void GenerateListOfPeselLists(string initialDirectory)
        {
            List<string> fileNames = new List<string>(Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @initialDirectory)));
            fileNames= fileNames.Where(s => s.Contains(".txt")).Where(s => s.Contains("Pesel")).ToList();
            foreach (var fileName in fileNames)
            {
                peselListsList.Add(GeneratePeselList(fileName));
            }
        }
        private static List<string> GeneratePeselList(string patch)
        {
            List<string> peselList = new List<string>();

            using (StreamReader txtReader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @patch)))
            {
                while (txtReader.Peek() >= 0)
                {
                    peselList.Add(txtReader.ReadLine());
                }
            }
            return peselList;
        }

        private static void GenerateObjectList(string assemblyName)
        {

            Assembly myAssembly = AppDomain.CurrentDomain.Load(assemblyName);
            foreach (var type in myAssembly.GetTypes().Where(type => type.IsClass && type.IsSubclassOf(typeof(PeselValidator))))
            {
                peselValidatorsList.Add((PeselValidator) Activator.CreateInstance(type));
            }   
        }
    }


}
