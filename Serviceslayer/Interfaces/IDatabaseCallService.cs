using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Serviceslayer.Interfaces
{
    public interface IDatabaseCallService
    {
        bool InsertDatawithStoredProcedure(string storedprocedureName, string storedprocedureparametername, string jsonvalue);
        public bool ExecuteCmdNonQuery(string CommandName, params object[] optionalParams);
    }
}
