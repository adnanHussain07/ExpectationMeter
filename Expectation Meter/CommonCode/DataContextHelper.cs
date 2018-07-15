using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpectationMeter.DataServices;
namespace ExpectationMeter.CommonCode
{
    public class DataContextHelper
    {


        public static ConStrExpectationMeterDB GetCPDataContext(bool enableAutoSelect = true)
         {
            return (GetNewDataContext("ConStrExpectationMeter", enableAutoSelect));
        }
        private static ConStrExpectationMeterDB GetNewDataContext(string connectionStringName, bool enableAutoSelect)
        {
            ConStrExpectationMeterDB repository = new ConStrExpectationMeterDB(connectionStringName);
            repository.EnableAutoSelect = enableAutoSelect;
            return (repository);
        }


    }
}
