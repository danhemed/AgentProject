using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.DataBase;
using MySql.Data.MySqlClient;


namespace SQLEXE.models
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MySqlData sqlData = new MySqlData();
            Agent newAgent = new Agent(62, "3423", "dan hemed", "location", "Active", 3);
            AgentDAL agentDal = new AgentDAL(sqlData);
            agentDal.AddAgent(newAgent);
            sqlData.Connect();
            foreach (var agent in agentDal.GetAllAgents())
            {
                Console.WriteLine(agent);
            }
        }
    }
}
