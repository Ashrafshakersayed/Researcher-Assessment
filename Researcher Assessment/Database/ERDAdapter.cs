using Researcher_Assessment.Research;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Researcher_Assessment.Database
{

    class ERDAdapter
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        public ERDAdapter()
        {
            try
            {
                sqlConnection = new SqlConnection(@"Server=.;Database=Research_Database;Trusted_Connection=True;MultipleActiveResultSets=true");
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

            }
            catch (Exception)
            {
                MessageBox.Show("can not connect to the database");
            }
        }

        public List<Researcher> fetchBasicResearcherDetails()
        {
            sqlCommand.CommandText = "select * from Researchers order by family_name";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);


            List<Researcher> researchers = new List<Researcher>();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row.Field<int>("type") == 0)
                {

                    researchers.Add(new Student
                    {

                        GivenName = row["given_name"].ToString(),
                        FamilyName = row["family_name"].ToString(),
                        Email = row["email"].ToString(),
                        Unit = row["unit"].ToString(),
                        Photo = row["photo"].ToString(),
                        Title = row["title"].ToString(),
                        Campus = row["campus"].ToString(),
                        Degree = row["degree"].ToString(),
                        Level = row.Field<EmploymentLevel>("level"),
                        id = row.Field<int>("id")


                    });
                }
                else
                {
                    researchers.Add(new Staff
                    {

                        GivenName = row["given_name"].ToString(),
                        FamilyName = row["family_name"].ToString(),
                        Email = row["email"].ToString(),
                        Photo = row["photo"].ToString(),
                        Unit = row["unit"].ToString(),
                        Title = row["title"].ToString(),
                        Campus = row["campus"].ToString(),
                        Level = row.Field<EmploymentLevel>("level"),
                        id = row.Field<int>("id")


                    });

                }
            }

            return researchers;
        }

        public Researcher fetchFullResearcherDetails(int id)
        {
            sqlCommand.CommandText = $"select * from position where id ={id}";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Researcher researcher = new Researcher();
            List<Position> positions = new List<Position>();

            foreach (DataRow row in dataTable.Rows)
            {

                positions.Add(new Position
                {
                    Start = row.Field<DateTime>("start"),
                    End = row.Field<DateTime>("end"),
                    Level = row.Field<EmploymentLevel>("level"),
                    Title = row.Field<string>("title")
                    
                });
            }

            researcher.positions = positions;
            return researcher;
        }

        public List<Publication> fetchBasicPublicationDetails(Researcher res)
        {
            sqlCommand.CommandText = $"select * from publication where researcherid ={res.id}";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            List<Publication> Publications = new List<Publication>();

            foreach (DataRow row in dataTable.Rows)
            {

                Publications.Add(new Publication
                {
                    DOI = row.Field<string>("doi"),
                    Authors = row.Field<string>("authors"),
                    CiteAs = row.Field<string>("cite_as"),
                    Title = row.Field<string>("title"),
                    Year = row.Field<int>("year"),
                    Available = row.Field<DateTime>("available"),
                    Type = row.Field<OutputType>("type"),


                });

            }
            return Publications;
        }


        public int fetchPublicationCounts(DateTime from, DateTime to)
        {
            sqlCommand.CommandText = $"select COUNT(*) as 'count' from publication where researcherid = 2 and year between {from} and {to}";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            int count = 0;
            foreach (DataRow row in dataTable.Rows)
            {

                count = row.Field<int>("count");


            }
            return count;
        }

    }
}
