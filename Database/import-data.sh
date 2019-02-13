#wait for the SQL Server to come up
sleep 15s

#run the setup script to create the DB and the schema in the DB
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 0WFVJ3ADrAAj -d master -i Create.sql

#run the data script
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 0WFVJ3ADrAAj -d master -i InitialData.sql