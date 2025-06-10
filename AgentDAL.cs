using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.DataBase;
using MySql.Data.MySqlClient;

namespace SQLEXE.models
{
    public class AgentDAL
    {
        private MySqlData _sqlData;

        public AgentDAL(MySqlData sqlData)
        {
            _sqlData = sqlData;
        }


        public void AddAgent(Agent agent)
        {
            try
            {
                using (MySqlConnection conn = _sqlData.GetConnection())
                {
                    string query = "INSERT INTO agents (Id, CodeName, RealName, Location, Status, MissionsCompleted)" +
                        "VALUES (@Id, @CodeName, @RealName, @Location, @Status, @MissionsCompleted)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", agent.Id);
                    cmd.Parameters.AddWithValue("@CodeName", agent.CodeName);
                    cmd.Parameters.AddWithValue("@RealName", agent.RealName);
                    cmd.Parameters.AddWithValue("@Location", agent.Location);
                    cmd.Parameters.AddWithValue("@Status", agent.Status);
                    cmd.Parameters.AddWithValue("@MissionsCompleted", agent.MissionsCompleted);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error {ex.Message}");
            }
        }

        //public Agent GetIntelById(int id)
        //{

        //}

        public List<Agent> GetAllAgents()
        {
            try
            {
                var agents = new List<Agent>();
                MySqlConnection conn = _sqlData.GetConnection();
                var cmd = new MySqlCommand("SELECT * FROM agents", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Agent agent = new Agent(
                        reader.GetInt32("Id"),
                        reader.GetString("CodeName"),
                        reader.GetString("RealName"),
                        reader.GetString("Location"),
                        reader.GetString("Status"),
                        reader.GetInt32("MissionsCompleted")
                    );

                    agents.Add(agent);
                }
                return agents;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error {ex.Message}");
                return null;
            }
        }

        public void UpdateAgentLocation(int agentId, string newLocation)
        {

        }

        public void DeleteAgent(int agentId)
        {

        }
    }
}