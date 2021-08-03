#FROM microsoft/mssql-server-windows-developer
FROM mcr.microsoft.com/mssql/server:2019-CU11-ubuntu-20.04
ENV ACCEPT_EULA=Y sa_password=0WFVJ3ADrAAj MSSQL_SA_PASSWORD=0WFVJ3ADrAAj
WORKDIR /usr/data
COPY . ./
# RUN sqlcmd -S localhost -i C:\sql\Create.sql
# RUN sqlcmd -S localhost -i C:\sql\InitialData.sql

# Grant permissions for the import-data script to be executable
RUN /bin/bash ./entrypoint.sh
ENTRYPOINT [ "/opt/mssql/bin/sqlservr" ]