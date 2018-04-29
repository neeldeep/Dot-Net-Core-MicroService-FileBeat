#!/bin/bash
cd /app 
service filebeat start
dotnet MicroserviceTest.dll