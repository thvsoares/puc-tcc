FROM microsoft/mssql-server-windows-developer
ENV ACCEPT_EULA=Y sa_password=0WFVJ3ADrAAj
COPY ./*.sql C:/sql/
RUN sqlcmd -S localhost -i C:\sql\Create.sql
RUN sqlcmd -S localhost -i C:\sql\InitialData.sql
