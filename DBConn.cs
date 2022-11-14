using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace VDITechnicalTest
{
    public class DBConn
    {
        // Set the connection string with Windows Authentication
        string connString = ConfigurationManager.ConnectionStrings["SqlConnIntegratedSecurity"].ConnectionString;

        // Set the connection string with SQL Server Authentication
        // string connString = ConfigurationManager.ConnectionStrings["SqlConnWithAuthentication"].ConnectionString;

        string tableName = "TransactionHistory";
        public void CreateTable()
        {
            string sqlStatment = @$"IF NOT EXISTS (SELECT object_id  
                FROM sys.tables
                WHERE name = '{tableName}')
                BEGIN
                    CREATE TABLE {tableName}
                    (ID int IDENTITY(1,1) NOT NULL,
					 TransactionID varchar(50) NOT NULL,
					 BasePrice float NOT NULL,
					 MemberType varchar(50) NOT NULL,
					 MemberPoint int NOT NULL,
					 Discount float NOT NULL,
					 TotalPrice float NOT NULL
					)
                END";

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlStatment, sqlConn))
                    {
                        sqlConn.Open();
                        cmd.ExecuteNonQuery();
                        sqlConn.Close();
                    }
                }
                Console.WriteLine("Succeed to connect to SQL Server\n");
            }
            catch (SystemException e)
            {
                Console.WriteLine($"Failed to connect and create table to SQL Server: {e.Message}\n");
            }
        }

        public void NewTransaction(
            string basePrice,
            string memberType,
            int memberPoint,
            string discount,
            string totalPrice
        )
        {
            string sqlStatment = @$"IF EXISTS (SELECT TOP 1 ID FROM {tableName})
                BEGIN
		            INSERT INTO {tableName}
			            (TransactionID,
			            BasePrice,
			            MemberType,
			            MemberPoint,
			            Discount,
			            TotalPrice)
		            SELECT TOP 1 CONCAT(CONVERT(VARCHAR(8), GETDATE(), 112),'_', FORMAT(ISNULL(ID, 0) + 1, '0000')),
	                    {basePrice},
					    '{memberType}',
				        {memberPoint},
				        {discount},
				        {totalPrice}
	                FROM {tableName}
	                ORDER BY ID DESC
	            END
            ELSE
	            BEGIN
	                INSERT INTO {tableName}
		                (TransactionID,
			            BasePrice,
			            MemberType,
			            MemberPoint,
			            Discount,
		                TotalPrice)
		            VALUES(CONCAT(CONVERT(VARCHAR(8), GETDATE(), 112),'_', FORMAT(1, '0000')),
				        {basePrice},
				        '{memberType}',
				        {memberPoint},
				        {discount},
				        {totalPrice})
	            END";
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlStatment, sqlConn))
                    {
                        sqlConn.Open();
                        cmd.ExecuteNonQuery();
                        sqlConn.Close();
                    }
                }
                Console.WriteLine("Succeed to store transaction data to database\n");
            }
            catch (SystemException e)
            {
                Console.WriteLine($"Failed to insert database: {e.Message}\n");
            }
        }
    }
}