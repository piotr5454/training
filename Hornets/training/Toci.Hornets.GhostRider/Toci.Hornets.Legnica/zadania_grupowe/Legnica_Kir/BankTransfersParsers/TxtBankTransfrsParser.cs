﻿using System.Collections.Generic;
using Toci.Hornets.GhostRider.Kir;

namespace Toci.Hornets.Legnica.zadania_grupowe.Legnica_Kir.BankTransfersParsers
{
    public class TxtBankTransfrsParser : BankTransfersParser
    {
        public TxtBankTransfrsParser(FileOperation bankFileOperation)
        {
            this.BankFileOperation = bankFileOperation;
        }

        public override List<BankTransfer> GetBankTransfers()
        {
            throw new System.NotImplementedException();
        }

        protected override BankTransfer GetTransferEntry(string entry)
        {
            throw new System.NotImplementedException();
        }
    }
}