#wait for the SQL Server to come up
#run the setup script to create the DB and the schema in the DB
#run the intial data script
sleep 15s; /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 0WFVJ3ADrAAj -d master -i Create.sql; /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 0WFVJ3ADrAAj -d master -i InitialData.sql;