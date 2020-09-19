using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helper
{
    public class GlobalTransactions
    {
        public void TryIt(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                string ExStr = Newtonsoft.Json.JsonConvert.SerializeObject(ex);
                var logger = NLog.LogManager.GetCurrentClassLogger();
                logger.Log(LogLevel.Error, ExStr);
            }
        }
    }
}
