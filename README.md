# Dot-Net-Core-MicroService-FileBeat

Docker File consists of Dot Net Core and FileBeat.

Multiple Processes are run in the same container using Supervisor

I am using Filebeat to directly send logs to Elastic Search without Log Stash. Filebeat.yml needs to be modified with the Elastic Search Server.
