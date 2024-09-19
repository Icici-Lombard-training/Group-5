FROM mcr.microsoft.com/mssql/server:2019-latest

USER root

# Install SQL Server tools
RUN apt-get update \
    && apt-get install -y wget gnupg \
    && wget https://packages.microsoft.com/keys/microsoft.asc \
    && apt-key add microsoft.asc \
    && wget https://packages.microsoft.com/config/ubuntu/20.04/prod.list \
    && mv prod.list /etc/apt/sources.list.d/mssql-release.list \
    && apt-get update \
    && ACCEPT_EULA=Y apt-get install -y mssql-tools unixodbc-dev

USER mssql
