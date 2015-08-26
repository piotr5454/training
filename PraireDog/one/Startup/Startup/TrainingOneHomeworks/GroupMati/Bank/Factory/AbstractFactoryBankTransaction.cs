﻿using System;
using System.Collections.Generic;

namespace Startup.TrainingOneHomeworks.GroupMati.Bank.Factory
{
    public class AbstractFactoryBankTransaction <T>
    {
        public Dictionary<string, Func<T, bool>> BankDictionary = new Dictionary<string, Func<T, bool>>();
    }
}