﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.DbVirtualization.Interfaces;
using Toci.TraininigLibrary.Common.Interfaces.FileParser;

namespace Toci.TraininigLibrary.Common.FileParser
{
    public class FileEntityBase : IDbSave
    {
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public DateTime Date { get; protected set; }
        public string Account { get; protected set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Name, Surname, Date, Account);
        }

        public virtual string GetLine()
        {
            return string.Format("{0} {1} {2} {3}", Name, Surname, Date, Account);
        }

        public bool Save(FileEntityBase entry, IModel dataBaseModel)
        {
            throw new NotImplementedException();
        }
        
    }
}